CREATE TABLE [dbo].[SalesItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [saleId] INT NOT NULL, 
    [prodId] INT NOT NULL,
    [proddId] INT NOT NULL,
    [price] REAL NOT NULL, 
    [quantity] REAL NOT NULL, 
    [offerId] INT NOT NULL, 
    CONSTRAINT [FK_SalesItems_SalesInv] FOREIGN KEY([saleId]) REFERENCES [dbo].[SaleInvoices] ([Id]),
    CONSTRAINT [FK_SalesItems_Products] FOREIGN KEY([prodId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_SalesItems_ProductsDetails] FOREIGN KEY([proddId]) REFERENCES [dbo].[ProductsDetails] ([Id]),
    CONSTRAINT [FK_SalesItems_Offers] FOREIGN KEY([offerId]) REFERENCES [dbo].[Offers] ([Id])
)
