-- Generate Python dictionary format for each schema
SELECT 
    '    "' || column_name || '": "' || 
    CASE 
        WHEN data_type IN ('character varying', 'varchar', 'text') THEN 'str'
        WHEN data_type IN ('integer', 'bigint', 'smallint') THEN 'int'
        WHEN data_type IN ('numeric', 'decimal', 'real', 'double precision') THEN 'float'
        WHEN data_type IN ('timestamp', 'timestamp without time zone', 'timestamp with time zone') THEN 'datetime64[ns]'
        WHEN data_type = 'date' THEN 'datetime64[ns]'
        WHEN data_type = 'boolean' THEN 'bool'
        ELSE data_type
    END || '",'
FROM information_schema.columns
WHERE table_schema = 'nfl' 
    AND table_name = 'NFLTeamSeasons'  -- Change this for each table
    AND column_name NOT IN ('id', 'createdat', 'updatedat')
ORDER BY ordinal_position;