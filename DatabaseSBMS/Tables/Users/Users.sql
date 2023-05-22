CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(10) NOT NULL UNIQUE, 
    [password] NVARCHAR(10) NOT NULL UNIQUE, 
    [empId] INT NOT NULL UNIQUE, 
    [permId] INT NOT NULL,
    CONSTRAINT [FK_Users_Emp] FOREIGN KEY([empId]) REFERENCES [dbo].[Employees] ([Id]),
    CONSTRAINT [FK_Users_Perm] FOREIGN KEY([permId]) REFERENCES [dbo].[Permission] ([Id])
)
