--------------------------------------------------
-- Це модифікований скрипт Інни Іванівни :)
USE LouvreDatabase
GO
CREATE VIEW ADMIN_Permission AS
SELECT
    DB_NAME() AS [Database],
    dbp.permission_name AS [Permission],
    STRING_AGG(p.name, ', ') AS [Users],
    p.type_desc AS [User Type],
    dbp.state_desc AS [State],
    CASE WHEN so.type_desc IS NULL THEN 'N/A' ELSE so.name END AS [Object],
    CASE WHEN so.type_desc IS NULL THEN 'N/A' ELSE so.type_desc END AS [Object Type]
FROM
    sys.database_permissions dbp
LEFT JOIN
    sys.objects so ON dbp.major_id = so.object_id
LEFT JOIN
    sys.database_principals p ON dbp.grantee_principal_id = p.principal_id
WHERE
    p.name IN ('ModeratorUser', 'AdminUser', 'OwnerUser')
GROUP BY
    p.type_desc,
    dbp.state_desc,
    dbp.permission_name,
    CASE WHEN so.type_desc IS NULL THEN 'N/A' ELSE so.name END,
    CASE WHEN so.type_desc IS NULL THEN 'N/A' ELSE so.type_desc END


SELECT *
FROM 
	ADMIN_Permission
ORDER BY 
	[Object], [Permission];

