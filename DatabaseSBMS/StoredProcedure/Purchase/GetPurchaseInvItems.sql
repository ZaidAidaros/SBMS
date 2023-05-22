CREATE PROCEDURE [dbo].[GetPurchaseInvItems]
	@purchId int
As
Begin
SELECT [dbo].[PurchasesItems].Id,
       [dbo].[Products].[barCode],
       [dbo].[Products].[name],
       [dbo].[ProdUnits].[name],
	   [dbo].[PurchasesItems].quantity,
	   [dbo].[PurchasesItems].price,
	   [dbo].[ProductsDetails].expireDate
FROM [dbo].[PurchasesItems] 
INNER JOIN [dbo].[Products] ON [dbo].[Products].Id = [dbo].[PurchasesItems].prodId
INNER JOIN [dbo].[ProdUnits] ON [dbo].[ProdUnits].Id = [dbo].[Products].unitId
INNER JOIN [dbo].[ProductsDetails] ON [dbo].[ProductsDetails].Id = [dbo].[PurchasesItems].proddId
WHERE [dbo].[PurchasesItems].purchId = @purchId
End