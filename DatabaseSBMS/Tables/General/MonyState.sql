﻿CREATE TABLE [dbo].[MonyState]
(
	[Id] INT NOT NULL PRIMARY KEY , 
    [name] NVARCHAR(10) NOT NULL UNIQUE,
	[description] NVARCHAR(20) NOT NULL
)
