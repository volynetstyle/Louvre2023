USE LouvreDatabase
USE msdb;

SELECT
    bs.database_name AS DatabaseName,
    bmf.physical_device_name AS BackupFile,
    bs.backup_start_date AS BackupStartDate,
    bs.backup_finish_date AS BackupFinishDate,
    bs.backup_size / 1048576 AS BackupSizeMB,
    CASE bs.type
        WHEN 'D' THEN 'Full'
        WHEN 'I' THEN 'Differential'
        WHEN 'L' THEN 'Transaction Log'
        WHEN 'F' THEN 'File/Filegroup'
        WHEN 'G' THEN 'Differential file'
        WHEN 'P' THEN 'Partial'
        WHEN 'Q' THEN 'Differential partial'
    END AS BackupType,
    bs.is_copy_only AS IsCopyOnly
FROM
    dbo.backupset AS bs
    INNER JOIN dbo.backupmediafamily AS bmf ON bs.media_set_id = bmf.media_set_id
ORDER BY
    bs.backup_finish_date DESC;

