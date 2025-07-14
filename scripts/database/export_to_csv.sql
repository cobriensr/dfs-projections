-- Export results to CSV file-- This will create a CSV file with all the column information
COPY (
    SELECT
        table_schema,
        table_name,
        column_name,
        data_type,
        is_nullable
    FROM information_schema.columns
    WHERE table_schema IN ('nfl', 'mlb', 'cfb')
    ORDER BY table_schema, table_name, ordinal_position
) TO '/tmp/schema_columns.csv' WITH CSV HEADER;