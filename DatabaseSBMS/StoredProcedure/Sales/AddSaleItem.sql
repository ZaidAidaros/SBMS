CREATE PROCEDURE [dbo].[AddSaleItem]
	@saleId int,
	@prodId int,
	@proddId int,
	@price real,
	@quantity real,
	@offerId int,
	@one int
AS
Begin
INSERT INTO [dbo].SalesItems(
            [dbo].SalesItems.saleId,
			[dbo].SalesItems.prodId,
			[dbo].SalesItems.proddId,
			[dbo].SalesItems.price,
			[dbo].SalesItems.quantity,
			[dbo].SalesItems.offerId
			) 
			VALUES (
			@saleId,
			@prodId,
			@proddId,
			@price,
			@quantity,
			@offerId
			);
SET @quantity = @quantity * @one;
EXEC IncDecProdDQuantity @id=@proddId,@value=@quantity;
EXEC IncDecProdQuantity @proId=@prodId,@value=@quantity;
End
