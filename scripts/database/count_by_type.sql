-- Count columns by type for each table for validation
SELECT 
    table_schema,
    table_name,
    data_type,
    COUNT(*) as column_count
FROM information_schema.columns
WHERE table_schema IN ('nfl', 'mlb', 'cfb')
GROUP BY table_schema, table_name, data_type
ORDER BY table_schema, table_name, data_type;