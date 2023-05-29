CREATE TABLE [dbo].[SaleInvoices]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [empId] INT NOT NULL, 
    [custId] INT NOT NULL, 
    [invCustName] NVARCHAR(50) NOT NULL, 
    [total] REAL NOT NULL, 
    [monStateId] INT NOT NULL, 
    [invTypeId] INT NOT NULL, 
    [opDate] DATETIME NOT NULL, 
    [note] nvarchar(50) NOT NULL, 
    CONSTRAINT [FK_SalesOp_Employees] FOREIGN KEY([empId]) REFERENCES [dbo].[Employees] ([Id]), 
    CONSTRAINT [FK_MonyStates_SaleInvoices] FOREIGN KEY([monStateId]) REFERENCES [dbo].[MonyState] ([Id]),
    CONSTRAINT [FK_InvoiceTypes_SaleInvoices] FOREIGN KEY([invTypeId]) REFERENCES [dbo].[InvoiceTypes] ([Id]),
    CONSTRAINT [FK_SalesOp_Customers] FOREIGN KEY ([custId]) REFERENCES [Customers]([Id])
)
