CREATE PROCEDURE [dbo].[CreateCustomersTables]
AS
Begin
CREATE TABLE [dbo].[CustCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(10) NOT NULL UNIQUE, 
    [description] NVARCHAR(50) NOT NULL
);
CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [NIC] INT NOT NULL, 
    [birthDate] DATE NOT NULL, 
    [address] NVARCHAR(50) NOT NULL, 
    [phone] NVARCHAR(50) NOT NULL,
    [cateId] INT NOT NULL, 
    [genId] INT NOT NULL,
    CONSTRAINT [FK_Customers_Category] FOREIGN KEY([cateId]) REFERENCES [dbo].[CustCategory] ([Id]),
    CONSTRAINT [FK_Customers_Gender] FOREIGN KEY([genId]) REFERENCES [dbo].[Gender] ([Id])
);
End