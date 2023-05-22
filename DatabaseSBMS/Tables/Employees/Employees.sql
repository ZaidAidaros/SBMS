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
    [note] NVARCHAR(50) NOT NULL, 
    [phone] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Employees_SalesOp] FOREIGN KEY([jobTitleId]) REFERENCES [dbo].[JobTitle] ([Id]),
    CONSTRAINT [FK_Employees_Gender] FOREIGN KEY([genderId]) REFERENCES [dbo].[Gender] ([Id])
)
