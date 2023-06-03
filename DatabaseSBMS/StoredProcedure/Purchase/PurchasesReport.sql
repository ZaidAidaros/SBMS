CREATE PROCEDURE [dbo].[PurchasesReport]
	@invTotal Real,
	@invTypId int,
	@monyStaeId int,
	@name nvarchar(50),
    @fromDate DateTime,
    @toDate DateTime
AS
Begin
SELECT [dbo].PurchaseInvoices.Id,
       [dbo].PurchaseInvoices.invSuppName,
       [dbo].Suppliers.[name] as SuppName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as MonyState,
       [dbo].PurchaseInvoices.total,
       [dbo].PurchaseInvoices.note,
       [dbo].PurchaseInvoices.opDate
FROM [dbo].PurchaseInvoices
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].PurchaseInvoices.empId
INNER JOIN [dbo].Suppliers ON [dbo].Suppliers.Id = [dbo].PurchaseInvoices.suppId
INNER JOIN [dbo].MonyState ON [dbo].MonyState.Id = [dbo].PurchaseInvoices.monStateId
INNER JOIN [dbo].InvoiceTypes ON [dbo].InvoiceTypes.Id = [dbo].PurchaseInvoices.invTypeId
WHERE [dbo].PurchaseInvoices.invTypeId = @invTypId
And [dbo].PurchaseInvoices.monStateId = @monyStaeId
And [dbo].Suppliers.[name] LIKE '%'+@name+'%'
And [dbo].PurchaseInvoices.opDate >= @fromDate
And [dbo].PurchaseInvoices.opDate <= @toDate
And [dbo].PurchaseInvoices.total >= @invTotal
End
