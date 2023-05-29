CREATE TABLE [dbo].[PurchaseInvoices]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[empId] INT NOT NULL, 
    [suppId] INT NOT NULL, 
    [invSuppName] NVARCHAR(50) NOT NULL, 
    [total] REAL NOT NULL, 
    [monStateId] INT NOT NULL, 
    [invTypeId] INT NOT NULL, 
    [opDate] DATETIME NOT NULL, 
    [note] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_PurchaseInvoices_Employee] FOREIGN KEY([empId]) REFERENCES [dbo].[Employees] ([Id]), 
    CONSTRAINT [FK_MonyStates_PurchaseInvoices] FOREIGN KEY([monStateId]) REFERENCES [dbo].[MonyState] ([Id]),
    CONSTRAINT [FK_PurchaseInvoices_InvoiceTypes] FOREIGN KEY([invTypeId]) REFERENCES [dbo].[InvoiceTypes] ([Id]), 
    CONSTRAINT [FK_PurchaseInvoices_Suppliers] FOREIGN KEY([suppId]) REFERENCES [dbo].[Suppliers] ([Id])
)
