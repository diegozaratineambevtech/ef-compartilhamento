USE [master]
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'meu-banco')
BEGIN
    -- Display a message before dropping the database
    PRINT 'IceBev database already exists...'
	PRINT 'Dropping database meu-banco...'
    
    -- Drop the database if it exists
    DROP DATABASE [meu-banco];
END
ELSE
    PRINT 'The meu-banco database does not exist.'


-- Create the database
PRINT 'Creating database meu-banco...'
CREATE DATABASE [meu-banco];
GO

USE [meu-banco]
GO

-- Drop the Login if it already exists
IF EXISTS (SELECT * FROM sys.server_principals WHERE name = 'Admin')
BEGIN
    PRINT 'Dropping Admin login...'
    DROP LOGIN [Admin]
END

-- Drop the User if it already exists
IF EXISTS (SELECT * FROM sys.database_principals WHERE name = 'Admin')
BEGIN
    PRINT 'Dropping Admin user...'
    DROP USER [Admin]
END

-- Create the Login
PRINT 'Creating Admin login...'
CREATE LOGIN [Admin] WITH PASSWORD = 'SuperSenha2000!';
GO

-- Create the User
PRINT 'Creating Admin user...'
CREATE USER [Admin] FOR LOGIN [Admin] WITH DEFAULT_SCHEMA=[dbo]
GO

-- Grant database-level privileges
PRINT 'Granting privileges to Admin...'
ALTER ROLE [db_owner] ADD MEMBER [Admin];
GO

PRINT 'All tasks completed!'
GO