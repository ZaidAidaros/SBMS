CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [barCode] INT NOT NULL UNIQUE, 
    [name] NVARCHAR(50) NOT NULL UNIQUE, 
    [description] NVARCHAR(50) NOT NULL, 
    [defPrice] REAL NOT NULL,
    [totalQuantity] REAL NOT NULL,
    [unitId] INT NOT NULL, 
    [cateId] INT NOT NULL,
    CONSTRAINT [FK_Product_Unit] FOREIGN KEY([unitId]) REFERENCES [dbo].[ProdUnits] ([Id]),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY([cateId]) REFERENCES [dbo].[ProductCategory] ([Id])
);
