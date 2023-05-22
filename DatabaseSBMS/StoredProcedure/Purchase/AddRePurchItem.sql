CREATE PROCEDURE [dbo].[AddRePurchItem]
	@purchId int,
	@prodId int,
	@proddId int,
	@price real,
	@quantity real
AS
Begin
INSERT INTO [dbo].[PurchasesItems](
            [dbo].[PurchasesItems].purchId,
			[dbo].[PurchasesItems].prodId,
			[dbo].[PurchasesItems].proddId,
			[dbo].[PurchasesItems].price,
			[dbo].[PurchasesItems].quantity
			) 
			VALUES (
			@purchId,
			@prodId,
			@proddId,
			@price,
			@quantity
			);

SET @quantity = @quantity * -1
EXEC IncDecProdDQuantity @id=@proddId, @value=@quantity;
EXEC IncDecProdQuantity @proId=@prodId, @value=@quantity;
End
