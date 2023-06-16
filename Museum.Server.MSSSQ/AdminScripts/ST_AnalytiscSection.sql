--CREATE TABLE AnalytiscSection (
--    Activity INT,
--    ConnectionStability INT,
--    Files INT,
--    Comments INT,
--    TotalDatabaseRows INT,
--    CPU INT,
--    DatabaseSize VARCHAR(255),
--    ActiveAdmins INT,
--    TotalBases INT,
--    TableCount INT
--);
use LouvreDatabase

GO
CREATE VIEW ST_AnalytiscSection
AS
SELECT
    Activity.TotalRows AS Activity,
    100 AS ConnectionStability,
    Files.FileCount AS Files,
    (SELECT COUNT(*) FROM Comments) AS Comments,
    TotalDatabaseRows.TotalRowCount AS TotalDatabaseRows,
    (SELECT cpu_count FROM sys.dm_os_sys_info) AS CPU,
    DatabaseSize.DatabaseName,
    DatabaseSize.SizeMB AS DatabaseSize,
    ActiveAdmins.AdminCount AS ActiveAdmins,
    1 AS TotalBases,
    TableCount.TableCount
FROM
    (
        SELECT COUNT(*) AS TotalRows
        FROM (
            SELECT COUNT(*) AS Row_Count
            FROM Raitings
            UNION ALL
            SELECT COUNT(*) AS Row_Count
            FROM Comments
        ) AS Subquery
    ) AS Activity,
    (
        SELECT COUNT(*) AS FileCount
        FROM sys.database_files
    ) AS Files,
    (
        SELECT SUM(p.rows) AS TotalRowCount
        FROM sys.tables t
        INNER JOIN sys.partitions p ON t.object_id = p.object_id
        WHERE p.index_id < 2
    ) AS TotalDatabaseRows,
    (
        SELECT
            DB_NAME(database_id) AS DatabaseName,
            SUM(size * 8 / 1024) AS SizeMB
        FROM
            sys.master_files
        WHERE
            type = 0 -- Data files
            AND DB_NAME(database_id) = 'LouvreDatabase'
        GROUP BY
            DB_NAME(database_id)
    ) AS DatabaseSize,
    (
        SELECT COUNT(*) AS AdminCount
        FROM sys.sysusers
        WHERE name IN ('ModeratorUser', 'AdminUser', 'OwnerUser')
    ) AS ActiveAdmins,
    (
        SELECT COUNT(*) AS TableCount
        FROM sys.tables
    ) AS TableCount;
