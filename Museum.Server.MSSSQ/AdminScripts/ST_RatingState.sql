--    public class RatingStateViewModel
--    {
--        public int TotlaPosts { get; set; }
--        public int AverageRating { get; set; }
--        public int Product { get; set; }
--    }
USE LouvreDatabase
GO
CREATE VIEW ST_RatingState
AS
	SELECT
    (
        SELECT COUNT(*) AS TotalPosts
        FROM GalleryObjects
    ) AS TotalPosts,
    (
        SELECT AVG(Rating) AS AverageRating
        FROM Raitings
    ) AS AverageRating,
    0 AS Product;

