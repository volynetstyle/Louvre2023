-- Создание таблицы для записи последних изменений
CREATE TABLE LastChanges (
    TableName NVARCHAR(128),
    ChangeType NVARCHAR(50),
    Description NVARCHAR(MAX),
    LastModified DATETIME
);

GO
-- Создание триггера для записи последних изменений на определенной таблице
CREATE TRIGGER RecordLastChange_ApplicationRole
ON ApplicationRole -- Замените на имя нужной таблицы
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Определение типа изменения
    DECLARE @ChangeType NVARCHAR(50);
    SET @ChangeType = CASE 
        WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
        WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
        WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
    END;
    
    -- Определение описания изменения
    DECLARE @Description NVARCHAR(MAX);
    SET @Description = CASE
        WHEN @ChangeType = 'UPDATE' THEN 'Updated record(s) in YourTableName' -- Замените на имя нужной таблицы
        WHEN @ChangeType = 'INSERT' THEN 'Inserted record(s) into YourTableName' -- Замените на имя нужной таблицы
        WHEN @ChangeType = 'DELETE' THEN 'Deleted record(s) from YourTableName' -- Замените на имя нужной таблицы
    END;
    
    -- Запись последнего изменения в таблицу LastChanges
    INSERT INTO LastChanges (TableName, ChangeType, Description, LastModified)
    VALUES ('ApplicationRole', @ChangeType, @Description, GETDATE()); -- Замените на имя нужной таблицы
END