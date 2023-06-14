USE LouvreDatabase;
-- Создание учетной записи и логина для модератора
USE LouvreDatabase;
CREATE LOGIN ModeratorLogin WITH PASSWORD = '12345678';
CREATE USER ModeratorUser FOR LOGIN ModeratorLogin;

-- Создание учетной записи и логина для администратора
USE LouvreDatabase;
CREATE LOGIN AdminLogin WITH PASSWORD = '12345678';
CREATE USER AdminUser FOR LOGIN AdminLogin;

-- Создание учетной записи и логина для владельца
USE LouvreDatabase;
CREATE LOGIN OwnerLogin WITH PASSWORD = '12345678';
CREATE USER OwnerUser FOR LOGIN OwnerLogin;

--Предоставление соответствующих прав доступа каждой роли:
USE LouvreDatabase;
GRANT SELECT ON SCHEMA::dbo TO ModeratorUser;
-- Предоставление прав доступа администратору
USE LouvreDatabase;
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO AdminUser;
-- Предоставление прав доступа владельцу
USE LouvreDatabase;
GRANT CONTROL, ALTER, SELECT, INSERT ON SCHEMA::dbo TO OwnerUser;

-- Проверка наличия учетных записей и логинов
SELECT name FROM sys.sql_logins;

-- Проверка прав доступа для модератора
SELECT permission_name, state_desc FROM sys.database_permissions WHERE grantee_principal_id = USER_ID('ModeratorUser');

-- Проверка прав доступа для администратора
SELECT permission_name, state_desc FROM sys.database_permissions WHERE grantee_principal_id = USER_ID('AdminUser');

-- Проверка прав доступа для владельца
SELECT permission_name, state_desc FROM sys.database_permissions WHERE grantee_principal_id = USER_ID('OwnerUser');

