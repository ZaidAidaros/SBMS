CREATE PROCEDURE [dbo].[AddSaleInvoice]
	@empId int,
	@custId int,
	@invCustName nvarchar(50),
	@total real,
	@monStateId int,
	@invTypeId int,
	@note nvarchar(50),
    @ID int out
AS
Begin
SET NOCOUNT ON
INSERT INTO [dbo].SaleInvoices(
            [dbo].SaleInvoices.empId,
			[dbo].SaleInvoices.custId,
			[dbo].SaleInvoices.invCustName,
            [dbo].SaleInvoices.total,
			[dbo].SaleInvoices.monStateId,
			[dbo].SaleInvoices.invTypeId,
			[dbo].SaleInvoices.note
			)
            VALUES (
			@empId,
			@custId,
			@invCustName,
			@total,
			@monStateId,
			@invTypeId,
			@note
			);
SET @ID = IDENT_CURRENT('SaleInvoices');
End
