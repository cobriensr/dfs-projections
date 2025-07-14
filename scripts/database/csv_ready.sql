-- Get a CSV-ready format showing table.column = datatype
SELECT 
    table_schema || '.' || table_name || '.' || column_name as full_column_path,
    data_type,
    CASE 
        WHEN data_type IN ('character varying', 'varchar') THEN 'string'
        WHEN data_type IN ('integer', 'bigint', 'smallint') THEN 'int'
        WHEN data_type IN ('numeric', 'decimal', 'real', 'double precision') THEN 'float'
        WHEN data_type IN ('timestamp', 'timestamp without time zone', 'timestamp with time zone') THEN 'datetime'
        WHEN data_type = 'date' THEN 'date'
        WHEN data_type = 'boolean' THEN 'bool'
        WHEN data_type = 'text' THEN 'string'
        ELSE data_type
    END as pandas_dtype
FROM information_schema.columns
WHERE table_schema IN ('nfl', 'mlb', 'cfb')
    AND column_name NOT IN ('id', 'createdat', 'updatedat') -- Exclude auto-generated columns
ORDER BY table_schema, table_name, ordinal_position;