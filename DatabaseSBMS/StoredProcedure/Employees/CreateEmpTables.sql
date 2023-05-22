CREATE PROCEDURE [dbo].[CreateEmpTables]
AS
Begin
CREATE TABLE [dbo].[JobTitle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [description] NVARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [NIC] INT NOT NULL, 
    [birthDate] DATE NOT NULL, 
    [address] NVARCHAR(50) NOT NULL, 
    [jobTitleId] INT NOT NULL, 
    [basicSalary] REAL NOT NULL,
    [genderId] INT NOT NULL,
    [phone] NVARCHAR(50) NOT NULL, 
    [note] NVARCHAR(50) NOT NULL,
    CONSTRAINT [FK_Employees_SalesOp] FOREIGN KEY([jobTitleId]) REFERENCES [dbo].[JobTitle] ([Id]),
    CONSTRAINT [FK_Employees_Gender] FOREIGN KEY([genderId]) REFERENCES [dbo].[Gender] ([Id])
);

INSERT INTO [dbo].[JobTitle] ([dbo].[JobTitle].[name],[dbo].[JobTitle].[description]) VALUES ('Owner','Owner');
INSERT INTO [dbo].[Employees] (
            [dbo].[Employees].[name],
            [dbo].[Employees].[NIC],
            [dbo].[Employees].[birthDate],
            [dbo].[Employees].[address],
            [dbo].[Employees].[jobTitleId],
            [dbo].[Employees].[basicSalary],
            [dbo].[Employees].[genderId],
            [dbo].[Employees].[phone],
            [dbo].[Employees].[note]
            )VALUES(
            'Owner',
            1000001,
            '2000-1-1',
            'no place',
            1,
            0,
            1,
            '+967',
            'Owner'
            );
End
