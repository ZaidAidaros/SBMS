CREATE PROCEDURE [dbo].[CreateSuppliersTables]
AS
Begin
CREATE TABLE [dbo].[SupCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(10) NOT NULL UNIQUE, 
    [description] NVARCHAR(50) NOT NULL
);
CREATE TABLE [dbo].[Suppliers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [cateId] INT NOT NULL, 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [address] NVARCHAR(50) NOT NULL, 
    [phone] NVARCHAR(50) NOT NULL,
    CONSTRAINT [FK_Suppliers_Category] FOREIGN KEY([cateId]) REFERENCES [dbo].[SupCategory] ([Id])
)
End