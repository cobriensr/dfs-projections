-- This gives you a comprehensive list of all columns with their data types
SELECT
    table_schema,
    table_name,
    column_name,
    data_type,
    character_maximum_length,
    numeric_precision,
    numeric_scale,
    is_nullable,
    column_default,
    ordinal_position
FROM information_schema.columns
WHERE table_schema IN ('nfl', 'mlb', 'cfb')
ORDER BY table_schema, table_name, ordinal_position;