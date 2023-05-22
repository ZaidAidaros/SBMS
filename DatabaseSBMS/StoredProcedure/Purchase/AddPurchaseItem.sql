CREATE PROCEDURE [dbo].[AddPurchaseItem]
    @purchId int,
	@prodId int,
	@cost real,
	@price real,
	@quantity real,
	@exDate Date
AS
Begin
INSERT INTO [dbo].[ProductsDetails](
            [prodId],
			[purchId],
			[cost],
			[price],
			[quantity],
			[expireDate]
			) 
            VALUES (
			@prodId,
			@purchId,
			@cost,
	        @price,
			@quantity,
	        @exDate
			);
INSERT INTO [dbo].[PurchasesItems](
			[purchId],
            [proddId],
            [prodId],
			[price],
			[quantity]
			)
            VALUES (
			@purchId,
			IDENT_CURRENT('ProductsDetails'),
			@prodId,
			@cost,
			@Quantity
			);
EXEC IncDecProdQuantity @proId=@prodId,@value=@quantity;
End
