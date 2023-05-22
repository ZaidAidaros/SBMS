CREATE TABLE [dbo].[ProdUnits]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(10) NOT NULL UNIQUE, 
    [symbole] NVARCHAR(5) NOT NULL, 
    [subUName] NVARCHAR(10) NOT NULL, 
    [subSymbole] NVARCHAR(5) NOT NULL, 
    [description] NVARCHAR(50) NOT NULL,
    [rateMB] INT NOT NULL
);
