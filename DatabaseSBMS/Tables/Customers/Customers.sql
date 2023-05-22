CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [NIC] INT, 
    [birthDate] DATE, 
    [address] NVARCHAR(50), 
    [phone] NVARCHAR(50),
    [cateId] INT NOT NULL, 
    [genId] INT NOT NULL,
    CONSTRAINT [FK_Customers_Category] FOREIGN KEY([cateId]) REFERENCES [dbo].[CustCategory] ([Id]),
    CONSTRAINT [FK_Customers_Gender] FOREIGN KEY([genId]) REFERENCES [dbo].[Gender] ([Id])
)
