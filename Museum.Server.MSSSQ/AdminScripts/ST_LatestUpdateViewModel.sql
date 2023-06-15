--public class LatestUpdateViewModel
--    {
--        public DateTime TimeUpdate { get; set; }
--        public string? UpdateContext { get; set; }
--        public string? UpdateDesc { get; set; }
--    }

USE LouvreDatabase
GO
CREATE VIEW ST_LatestUpdateViewModel
AS
select LastModified AS TimeUpdate,
	   ChangeType AS UpdateContext,
	   CONCAT([Description], ' which ', TableName) AS UpdateDesc
from LastChanges

