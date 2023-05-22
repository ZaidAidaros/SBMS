CREATE TABLE [dbo].[ProductsDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [prodId] INT NOT NULL, 
    [purchId] INT NOT NULL, 
    [cost] REAL NOT NULL, 
    [price] REAL NOT NULL, 
    [quantity] REAL NOT NULL,
    [expireDate] DATE NOT NULL,
    CONSTRAINT [FK_ProductDetails_Products] FOREIGN KEY([prodId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_ProductDetails_Purchases] FOREIGN KEY([purchId]) REFERENCES [dbo].[PurchaseInvoices] ([Id]),
)
