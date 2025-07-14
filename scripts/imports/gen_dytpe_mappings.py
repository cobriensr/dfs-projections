"""This script generates data type mappings for columns in specific PostgreSQL schemas."""

import json
import os
import logging
import pandas as pd
from sqlalchemy import create_engine
from dotenv import load_dotenv

# Load .env file from current directory
load_dotenv()

# Configure logging
logging.basicConfig(
    level=logging.INFO, format="%(asctime)s - %(levelname)s - %(message)s"
)
logger = logging.getLogger(__name__)

# Database configuration
DB_CONFIG = {
    "host": os.getenv("HOST"),
    "database": os.getenv("DATABASE"),
    "user": os.getenv("USER"),
    "password": os.getenv("PASSWORD"),
    "port": 5432,
}


# Create connection
def create_connection() -> create_engine:
    """Create database connection"""
    connection_string = (
        f"postgresql://{DB_CONFIG['user']}:{DB_CONFIG['password']}"
        f"@{DB_CONFIG['host']}:{DB_CONFIG['port']}/{DB_CONFIG['database']}"
    )
    engine = create_engine(connection_string)
    return engine


# Query to get all columns and types
QUERY = """
SELECT
    table_schema,
    table_name,
    column_name,
    data_type,
    is_nullable
FROM information_schema.columns
WHERE table_schema IN ('nfl', 'mlb', 'cfb')
    AND column_name NOT IN ('id', 'createdat', 'updatedat')
ORDER BY table_schema, table_name, ordinal_position
"""

# Create a connection to the database
engine = create_connection()

# Get the data
df_columns = pd.read_sql(QUERY, engine)

# Create dtype mappings for each table
dtype_mappings = {}

for (schema, table), group in df_columns.groupby(["table_schema", "table_name"]):
    TABLE_KEY = f"{schema}.{table}"
    dtype_mappings[TABLE_KEY] = {}

    for _, row in group.iterrows():
        col_name = row["column_name"]
        data_type = row["data_type"]

        # Map PostgreSQL types to pandas types
        if data_type in ["character varying", "text"]:
            dtype_mappings[TABLE_KEY][col_name] = "str"
        elif data_type in ["integer", "bigint", "smallint"]:
            dtype_mappings[TABLE_KEY][col_name] = "Int64"  # Nullable integer
        elif data_type in ["numeric", "decimal", "real", "double precision"]:
            dtype_mappings[TABLE_KEY][col_name] = "float64"
        elif data_type in ["timestamp", "timestamp without time zone"]:
            dtype_mappings[TABLE_KEY][col_name] = "datetime64[ns]"
        elif data_type == "boolean":
            dtype_mappings[TABLE_KEY][col_name] = "bool"

# Print mappings for use in import script
# print(json.dumps(dtype_mappings, indent=2))

# save to file
with open("../data/column_mappings.json", "w", encoding="utf-8") as f:
    json.dump(dtype_mappings, f, indent=2)
