--public class LastPostViewModel
--    {
--        public string? ImageUrl { get; set; }
			---          title
--        public int AverageRating { get; set; }
--        public string? Description { get; set; }
--    }
use LouvreDatabase
GO
CREATE VIEW ST_LastPostViewModel
AS
SELECT TOP 5
    Images.Image_Loc AS ImageUrl,
	GalleryObjects.title AS Title,
    SUM(Raitings.Rating) AS AverageRating,
    CAST(GalleryObjects.historical_notes AS NVARCHAR(MAX)) AS [Description]
FROM
    GalleryObjects
    JOIN Images ON GalleryObjects.Object_ID = Images.Object_ID
    LEFT JOIN Raitings ON GalleryObjects.Object_ID = Raitings.Object_ID
GROUP BY
    Images.Image_Loc,
    CAST(GalleryObjects.historical_notes AS NVARCHAR(MAX)),
	GalleryObjects.title,
	GalleryObjects.Object_ID
ORDER BY
    GalleryObjects.Object_ID DESC;
