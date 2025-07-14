"""This script imports sports data from CSV files into a PostgreSQL database."""

import os
from datetime import datetime
import logging
import json
import sys
from pathlib import Path
import pandas as pd
from sqlalchemy import create_engine, text
from dotenv import load_dotenv


# Load environment variables
load_dotenv()

# Configure logging
logging.basicConfig(
    level=logging.INFO, format="%(asctime)s - %(levelname)s - %(message)s"
)
logger = logging.getLogger(__name__)

# Load column mappings
with open("column_mappings.json", "r") as f:
    COLUMN_MAPPINGS = json.load(f)

# File import order - respecting foreign key dependencies
IMPORT_ORDER = {
    "nfl": [
        ("Stadium.2024.csv", "Stadiums"),
        ("Team.2024.csv", "Teams"),
        ("Player.2024.csv", "Players"),
        ("Score.2024.csv", "Scores"),
        ("Quarter.2024.csv", "Quarters"),
        ("Standing.2024.csv", "Standings"),
        ("TeamSeason.2024.csv", "TeamSeasons"),
        ("TeamGame.2024.csv", "TeamGames"),
        ("PlayerSeason.2024.csv", "PlayerSeasons"),
        ("PlayerSeasonProjection.2024.csv", "PlayerSeasonProjections"),
        ("PlayerGame.2024.csv", "PlayerGames"),
        ("PlayerGameProjection.2024.csv", "PlayerGameProjections"),
        ("FantasyDefenseSeason.2024.csv", "FantasyDefenseSeasons"),
        ("FantasyDefenseSeasonProjection.2024.csv", "FantasyDefenseSeasonProjections"),
        ("FantasyDefenseGame.2024.csv", "FantasyDefenseGames"),
        ("FantasyDefenseGameProjection.2024.csv", "FantasyDefenseGameProjections"),
    ],
    "mlb": [
        ("Stadium.2024.csv", "Stadiums"),
        ("Team.2024.csv", "Teams"),
        ("Player.2024.csv", "Players"),
        ("Game.2024.csv", "Games"),
        ("Inning.2024.csv", "Innings"),
        ("TeamSeason.2024.csv", "TeamSeasons"),
        ("TeamGame.2024.csv", "TeamGames"),
        ("PlayerSeason.2024.csv", "PlayerSeasons"),
        ("PlayerSeasonProjection.2024.csv", "PlayerSeasonProjections"),
        ("PlayerGame.2024.csv", "PlayerGames"),
        ("PlayerGameProjection.2024.csv", "PlayerGameProjections"),
    ],
    "cfb": [
        ("Stadium.2024.csv", "Stadiums"),
        ("Team.2024.csv", "Teams"),
        ("Player.2024.csv", "Players"),
        ("Game.2024.csv", "Games"),
        ("Period.2024.csv", "Periods"),
        ("TeamSeason.2024.csv", "TeamSeasons"),
        ("TeamGame.2024.csv", "TeamGames"),
        ("PlayerSeason.2024.csv", "PlayerSeasons"),
        ("PlayerGame.2024.csv", "PlayerGames"),
        ("PlayerGameProjection.2024.csv", "PlayerGameProjections"),
    ],
}


class UniversalSportsImporter:
    def __init__(self):
        # Database configuration from environment
        self.connection_string = (
            f"postgresql://{os.getenv('USER')}:{os.getenv('PASSWORD')}"
            f"@{os.getenv('HOST')}:{os.getenv('PORT')}"
            f"/{os.getenv('DATABASE')}"
        )

        # Data paths
        self.data_base_path = Path(os.getenv("DATA_BASE_PATH"))
        self.batch_size = int(os.getenv("BATCH_SIZE", "1000"))

        # Create engine
        self.engine = create_engine(self.connection_string)

    def get_dtype_mapping(self, schema, table):
        """Get pandas dtype mapping for a specific table"""
        key = f"{schema}.{table}"
        if key not in COLUMN_MAPPINGS:
            logger.warning(f"No dtype mapping found for {key}")
            return {}

        # Convert database types to pandas read_csv dtypes
        dtype_map = {}
        for col, db_type in COLUMN_MAPPINGS[key].items():
            # Skip system columns
            if col.lower() in [
                "id",
                "createdat",
                "updatedat",
                "isdeleted",
                "accesscount",
            ]:
                continue

            # Map to pandas dtypes for read_csv
            if db_type == "Int64":
                dtype_map[col] = "Int64"  # Nullable integer
            elif db_type == "float64":
                dtype_map[col] = "float64"
            elif db_type == "bool":
                dtype_map[col] = "boolean"  # Nullable boolean
            elif db_type == "str":
                dtype_map[col] = "str"

        return dtype_map

    def process_numeric_columns(self, df, schema, table):
        """Convert string columns that should be numeric based on the database schema"""
        key = f"{schema}.{table}"
        if key not in COLUMN_MAPPINGS:
            return df

        mappings = COLUMN_MAPPINGS[key]

        for col in df.columns:
            # Skip if column doesn't exist in mappings
            if col not in mappings:
                continue

            db_type = mappings[col]

            # Convert columns that are stored as strings but should be numeric
            if col in df.columns and df[col].dtype == "object":
                if db_type in ["Int64", "float64"] or self.should_be_numeric(col):
                    logger.debug(f"Converting {col} from string to {db_type}")
                    if db_type == "Int64" or self.should_be_integer(col):
                        df[col] = pd.to_numeric(df[col], errors="coerce").astype(
                            "Int64"
                        )
                    else:
                        df[col] = pd.to_numeric(df[col], errors="coerce")

        return df

    def should_be_numeric(self, column_name):
        """Determine if a column should be numeric based on its name"""
        numeric_indicators = [
            "score",
            "yards",
            "attempts",
            "completions",
            "touchdowns",
            "points",
            "percentage",
            "rating",
            "average",
            "total",
            "made",
            "missed",
            "blocked",
            "returns",
            "tackles",
            "sacks",
            "hits",
            "defended",
            "forced",
            "recovered",
            "conversions",
            "wins",
            "losses",
            "ties",
            "rank",
        ]
        col_lower = column_name.lower()
        return any(indicator in col_lower for indicator in numeric_indicators)

    def should_be_integer(self, column_name):
        """Determine if a numeric column should be integer based on its name"""
        integer_indicators = [
            "id",
            "score",
            "points",
            "attempts",
            "completions",
            "touchdowns",
            "yards",
            "made",
            "tackles",
            "sacks",
            "hits",
            "defended",
            "forced",
            "recovered",
            "wins",
            "losses",
            "ties",
            "rank",
            "week",
            "season",
            "quarter",
        ]
        col_lower = column_name.lower()
        return any(indicator in col_lower for indicator in integer_indicators)

    def clean_column_names(self, df):
        """Clean column names to match database schema (lowercase)"""
        df.columns = [col.lower() for col in df.columns]
        return df

    def add_metadata_columns(self, df):
        """Add system columns if they don't exist"""
        if "isdeleted" not in df.columns:
            df["isdeleted"] = False
        if "accesscount" not in df.columns:
            df["accesscount"] = 0
        if "createdat" not in df.columns:
            df["createdat"] = datetime.now()
        if "updatedat" not in df.columns:
            df["updatedat"] = datetime.now()
        return df

    def import_file(self, file_path, schema, table, conn):
        """Import a single CSV file to a database table"""
        logger.info(f"Importing {file_path} to {schema}.{table}...")

        # Get dtype mappings
        dtype_map = self.get_dtype_mapping(schema, table)

        # Read CSV with proper dtypes
        try:
            # Read CSV - use dtype mappings for known columns, str for others
            if dtype_map:
                # Read with specific dtypes where we know them
                df = pd.read_csv(
                    file_path, dtype=dtype_map, na_values=["", "NULL", "null", "None"]
                )
            else:
                # Fall back to reading everything as strings
                df = pd.read_csv(file_path, dtype=str)

            logger.info(f"Read {len(df)} rows from {file_path}")

            # Clean column names
            df = self.clean_column_names(df)

            # Process any remaining string columns that should be numeric
            df = self.process_numeric_columns(df, schema, table)

            # Add metadata columns
            df = self.add_metadata_columns(df)

            # Handle date columns
            date_columns = ["birthdate", "gamedate", "date", "day", "datetime"]
            for col in date_columns:
                if col in df.columns:
                    df[col] = pd.to_datetime(df[col], errors="coerce")

            # Delete existing data
            conn.execute(text(f'DELETE FROM {schema}."{table}"'))
            logger.info(f"Cleared existing data from {schema}.{table}")

            # Import in batches
            total_rows = len(df)
            for i in range(0, total_rows, self.batch_size):
                batch = df.iloc[i : i + self.batch_size]
                batch.to_sql(
                    table,
                    conn,
                    schema=schema,
                    if_exists="append",
                    index=False,
                    method="multi",
                )
                logger.info(
                    f"Imported {min(i + self.batch_size, total_rows)}/{total_rows} rows..."
                )

            logger.info(f"Successfully imported {total_rows} rows to {schema}.{table}")

        except Exception as e:
            logger.error(f"Error importing {file_path}: {str(e)}")
            raise

    def import_sport(self, sport):
        """Import all data for a specific sport"""
        logger.info(f"\n{'='*60}")
        logger.info(f"Starting import for {sport.upper()}")
        logger.info(f"{'='*60}")

        # Get data directory for this sport
        sport_data_dir = self.data_base_path / os.getenv(
            f"{sport.upper()}_DATA_DIR", f"{sport}FantasyOdds.2024"
        )

        if not sport_data_dir.exists():
            logger.error(f"Data directory not found: {sport_data_dir}")
            return

        # Import files in order
        with self.engine.begin() as conn:
            try:
                # Disable foreign key checks
                conn.execute(text("SET session_replication_role = 'replica'"))

                for csv_file, table_name in IMPORT_ORDER[sport]:
                    file_path = sport_data_dir / csv_file
                    if file_path.exists():
                        self.import_file(file_path, sport, table_name, conn)
                    else:
                        logger.warning(f"File not found: {file_path}, skipping...")

                # Re-enable foreign key checks
                conn.execute(text("SET session_replication_role = 'origin'"))

                logger.info(f"Successfully completed import for {sport.upper()}")

            except Exception as e:
                logger.error(f"Error during {sport} import: {str(e)}")
                raise

    def verify_import(self, sport):
        """Verify row counts after import"""
        logger.info(f"\nVerifying {sport.upper()} import...")

        with self.engine.connect() as conn:
            for _, table_name in IMPORT_ORDER[sport]:
                try:
                    result = conn.execute(
                        text(f'SELECT COUNT(*) FROM {sport}."{table_name}"')
                    ).scalar()
                    logger.info(f"{sport}.{table_name}: {result:,} rows")
                except Exception as e:
                    logger.error(f"Error checking {sport}.{table_name}: {str(e)}")

    def import_all(self):
        """Import all sports data"""
        sports_to_import = []

        if os.getenv("IMPORT_NFL", "true").lower() == "true":
            sports_to_import.append("nfl")
        if os.getenv("IMPORT_MLB", "true").lower() == "true":
            sports_to_import.append("mlb")
        if os.getenv("IMPORT_CFB", "true").lower() == "true":
            sports_to_import.append("cfb")

        for sport in sports_to_import:
            try:
                self.import_sport(sport)
                self.verify_import(sport)
            except Exception as e:
                logger.error(f"Failed to import {sport}: {str(e)}")
                if os.getenv("STOP_ON_ERROR", "false").lower() == "true":
                    raise


def main():
    """Main entry point"""
    importer = UniversalSportsImporter()

    try:
        importer.import_all()
        logger.info("\n✅ All imports completed successfully!")

    except Exception as e:
        logger.error(f"\n❌ Import failed: {str(e)}")
        sys.exit(1)


if __name__ == "__main__":
    main()
