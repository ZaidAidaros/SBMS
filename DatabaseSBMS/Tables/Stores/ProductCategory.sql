﻿CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [description]  NVARCHAR(50) NOT NULL
)
