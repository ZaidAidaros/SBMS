CREATE PROCEDURE [dbo].[AddPurchaseInvoice]
	@empId int,
	@suppId int,
	@invSuppName nvarchar(50),
	@total real,
	@monStateId int,
	@invTypeId int,
	@note nvarchar(50),
	@date DateTime,
	@ID int out
AS
Begin
SET NOCOUNT ON
INSERT INTO [dbo].PurchaseInvoices(
            [dbo].PurchaseInvoices.empId,
			[dbo].PurchaseInvoices.suppId,
			[dbo].PurchaseInvoices.invSuppName,
            [dbo].PurchaseInvoices.total,
			[dbo].PurchaseInvoices.monStateId,
			[dbo].PurchaseInvoices.invTypeId,
			[dbo].PurchaseInvoices.note,
			[dbo].PurchaseInvoices.opDate
			)
            VALUES (
			@empId,
			@suppId,
			@invSuppName,
			@total,
			@monStateId,
			@invTypeId,
			@note,
			@date
			);
SET @ID =  IDENT_CURRENT('PurchaseInvoices');
End