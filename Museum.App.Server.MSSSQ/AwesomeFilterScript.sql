use LouvreDatabase

SELECT
    Categories.Category_ID AS Box_ID,
    CategoryName AS Label,
    COUNT(*) AS Count,
	0 as IsChecked
FROM
    Categories
LEFT JOIN
    GalleryObjects ON Categories.Category_ID = GalleryObjects.Category_ID
GROUP BY
    Categories.Category_ID, CategoryName;

SELECT
    Collections.Collection_ID AS Box_ID,
    department AS Label,
    COUNT(*) AS Count,
	0 as IsChecked
FROM
    Collections
LEFT JOIN
    GalleryObjects ON Collections.Collection_ID = GalleryObjects.Collection_ID
GROUP BY
    Collections.Collection_ID, department;


GO
CREATE PROCEDURE GetFilterSideBarCollection
    @tableName NVARCHAR(50),
    @tablePK NVARCHAR(50),
	@GalleryObjectFK NVARCHAR(50),
    @labelName NVARCHAR(50)
AS
BEGIN
    DECLARE @sqlScript NVARCHAR(MAX) = '
        SELECT
            ' + @tableName + '.' + @tablePK + ' AS Box_ID,
            ' + @tableName + '.' + @labelName + ' AS Label,
            COUNT(GalleryObjects.' + @tablePK + ') AS Count,
            0 AS IsChecked
        FROM
            ' + @tableName + '
        LEFT JOIN
            GalleryObjects ON ' + @tableName + '.' + @tablePK + ' = GalleryObjects.' + @GalleryObjectFK + '
        GROUP BY
            ' + @tableName + '.' + @tablePK + ', ' + @tableName + '.' + @labelName

    EXEC sp_executesql @sqlScript;
END


exec GetFilterSideBarCollection 'Artists', 'Artist_ID', 'Artist_ID', 'FullName'