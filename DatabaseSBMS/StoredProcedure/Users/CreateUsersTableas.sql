CREATE PROCEDURE [dbo].[CreateUsersTableas]
AS
Begin

CREATE TABLE [dbo].[Permission]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(10) NOT NULL UNIQUE
);
INSERT INTO [dbo].[Permission] ([dbo].[Permission].name)VALUES('Owner');
INSERT INTO [dbo].[Permission] ([dbo].[Permission].name)VALUES('Admin');
INSERT INTO [dbo].[Permission] ([dbo].[Permission].name)VALUES('SaleSt');
INSERT INTO [dbo].[Permission] ([dbo].[Permission].name)VALUES('PurchaseSt');
CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(10) NOT NULL UNIQUE, 
    [password] NVARCHAR(10) NOT NULL UNIQUE, 
    [empId] INT NOT NULL UNIQUE, 
    [permId] INT NOT NULL,
    CONSTRAINT [FK_Users_Emp] FOREIGN KEY([empId]) REFERENCES [dbo].[Employees] ([Id]),
    CONSTRAINT [FK_Users_Perm] FOREIGN KEY([permId]) REFERENCES [dbo].[Permission] ([Id])
);
INSERT INTO [dbo].[Users] (
            [dbo].[Users].name,
            [dbo].[Users].password,
            [dbo].[Users].empId,
            [dbo].[Users].permId
            )VALUES(
            'Owner',
            'Owner',
            1,1
            );

End