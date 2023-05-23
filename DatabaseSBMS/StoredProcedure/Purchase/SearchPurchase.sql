CREATE PROCEDURE [dbo].[SearchPurchaseInv]
	@id int,
	@invTypeId int,
	@name nvarchar(50),
    @date DateTime
AS
Begin
SELECT [dbo].PurchaseInvoices.Id,
       [dbo].Suppliers.[name] as SupplierName,
       [dbo].PurchaseInvoices.invSuppName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as InvType,
       [dbo].PurchaseInvoices.total,
       [dbo].PurchaseInvoices.note,
       [dbo].PurchaseInvoices.opDate
FROM [dbo].PurchaseInvoices
INNER JOIN [dbo].Employees ON [dbo].PurchaseInvoices.empId = [dbo].Employees.Id
INNER JOIN [dbo].Suppliers ON [dbo].PurchaseInvoices.suppId = [dbo].Suppliers.Id
INNER JOIN [dbo].MonyState ON [dbo].PurchaseInvoices.monStateId = [dbo].MonyState.Id
INNER JOIN [dbo].InvoiceTypes ON [dbo].PurchaseInvoices.invTypeId = [dbo].InvoiceTypes.Id
WHERE [dbo].PurchaseInvoices.Id = @id 
OR [dbo].PurchaseInvoices.invTypeId = @invTypeId 
OR [dbo].Suppliers.[name] LIKE '%'+@name+'%'
OR [dbo].Employees.[name] LIKE '%'+@name+'%'
OR [dbo].MonyState.[name] LIKE '%'+@name+'%'
OR [dbo].PurchaseInvoices.opDate = @date
End