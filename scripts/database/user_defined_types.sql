-- Get a more detailed view with user-defined types expanded
SELECT 
    c.table_schema,
    c.table_name,
    c.column_name,
    CASE 
        WHEN c.data_type = 'USER-DEFINED' THEN c.udt_name
        ELSE c.data_type
    END as data_type,
    c.character_maximum_length,
    c.numeric_precision,
    c.is_nullable
FROM information_schema.columns c
WHERE c.table_schema IN ('nfl', 'mlb', 'cfb')
ORDER BY c.table_schema, c.table_name, c.ordinal_position;