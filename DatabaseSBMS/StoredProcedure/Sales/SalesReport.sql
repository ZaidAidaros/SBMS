CREATE PROCEDURE [dbo].[SalesReport]
	@invTotal Real,
	@invTypId int,
	@monyStaeId int,
	@name nvarchar(50),
    @fromDate DateTime,
    @toDate DateTime
AS
Begin
SELECT [dbo].SaleInvoices.Id,
       [dbo].SaleInvoices.invCustName,
       [dbo].Customers.[name] as CustName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as MonyState,
       [dbo].SaleInvoices.total,
       [dbo].SaleInvoices.opDate,
       [dbo].SaleInvoices.note
FROM [dbo].SaleInvoices
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].SaleInvoices.empId
INNER JOIN [dbo].Customers ON [dbo].Customers.Id = [dbo].SaleInvoices.custId
INNER JOIN [dbo].MonyState ON [dbo].MonyState.Id = [dbo].SaleInvoices.monStateId
INNER JOIN [dbo].InvoiceTypes ON [dbo].InvoiceTypes.Id = [dbo].SaleInvoices.invTypeId
WHERE [dbo].SaleInvoices.invTypeId = @invTypId
And [dbo].SaleInvoices.monStateId = @monyStaeId
And [dbo].Customers.[name] LIKE '%'+@name+'%'
And [dbo].SaleInvoices.opDate >= @fromDate
And [dbo].SaleInvoices.opDate <= @toDate
And [dbo].SaleInvoices.total >= @invTotal
End