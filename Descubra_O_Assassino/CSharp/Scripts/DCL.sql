
CREATE LOGIN Clouseau
    WITH PASSWORD = 'In$pet0r',
	DEFAULT_DATABASE = Misterio;
GO  

Use Misterio;
-- Creates a database user for the login created above.  
CREATE USER Clouseau FOR LOGIN Clouseau;
GO

GRANT SELECT ON SCHEMA::dbo TO Clouseau;
GRANT INSERT ON SCHEMA::dbo TO Clouseau;  
GRANT UPDATE ON SCHEMA::dbo TO Clouseau;  
GRANT DELETE ON SCHEMA::dbo TO Clouseau;  
GO 

