CREATE TABLE [dbo].[PurchasesItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [purchId] INT NOT NULL,
    [proddId] INT NOT NULL,
    [prodId] INT NOT NULL,
    [price] REAL NOT NULL, 
    [quantity] REAL NOT NULL,
    CONSTRAINT [FK_PurchasesItems_PurchaseInv] FOREIGN KEY([purchId]) REFERENCES [dbo].[PurchaseInvoices] ([Id]),
    CONSTRAINT [FK_PurchasesItems_ProductsDetails] FOREIGN KEY([proddId]) REFERENCES [dbo].[ProductsDetails] ([Id]),
    CONSTRAINT [FK_PurchasesItems_Products] FOREIGN KEY([prodId]) REFERENCES [dbo].[Products] ([Id])
)
