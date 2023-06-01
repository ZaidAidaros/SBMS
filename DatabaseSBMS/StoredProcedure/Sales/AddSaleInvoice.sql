CREATE PROCEDURE [dbo].[AddSaleInvoice]
	@empId int,
	@custId int,
	@invCustName nvarchar(50),
	@total real,
	@discountRate real,
	@monStateId int,
	@invTypeId int,
	@note nvarchar(50),
	@date DateTime,
    @ID int out
AS
Begin
SET NOCOUNT ON
INSERT INTO [dbo].SaleInvoices(
            [dbo].SaleInvoices.empId,
			[dbo].SaleInvoices.custId,
			[dbo].SaleInvoices.invCustName,
            [dbo].SaleInvoices.total,
            [dbo].SaleInvoices.discountRate,
			[dbo].SaleInvoices.monStateId,
			[dbo].SaleInvoices.invTypeId,
			[dbo].SaleInvoices.opDate,
			[dbo].SaleInvoices.note
			)
            VALUES (
			@empId,
			@custId,
			@invCustName,
			@total,
			@discountRate,
			@monStateId,
			@invTypeId,
			@date,
			@note
			);
SET @ID = IDENT_CURRENT('SaleInvoices');
End
