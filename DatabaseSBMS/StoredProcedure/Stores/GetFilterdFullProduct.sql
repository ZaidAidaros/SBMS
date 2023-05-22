﻿CREATE PROCEDURE [dbo].[GetFilterdFullProduct]
	@cateId int
As
Begin
SELECT [dbo].[ProductsDetails].[Id],
       [dbo].[Products].[Id] as ProdId,
	   [dbo].[Products].[barCode],
	   [dbo].[Products].[name],
	   [dbo].[Products].[description],
	   [dbo].[ProductCategory].[name] as Category,
	   [dbo].[ProdUnits].[name] as Unit,
	   [dbo].[Products].defPrice,
	   [dbo].[Products].totalQuantity,
	   [dbo].[ProductsDetails].cost,
	   [dbo].[ProductsDetails].price,
	   [dbo].[ProductsDetails].quantity,
	   [dbo].[ProductsDetails].[expireDate],
	   [dbo].[PurchaseInvoices].opDate as Store_Date
FROM [dbo].[ProductsDetails]
INNER JOIN [dbo].[Products] ON [dbo].[ProductsDetails].prodId = [dbo].[Products].Id
INNER JOIN [dbo].[ProductCategory] ON [dbo].[Products].cateId = [dbo].[ProductCategory].Id
INNER JOIN [dbo].[ProdUnits] ON [dbo].[Products].unitId = [dbo].[ProdUnits].Id
INNER JOIN [dbo].[PurchaseInvoices] ON [dbo].[ProductsDetails].purchId = [dbo].[PurchaseInvoices].Id
WHERE [dbo].[Products].cateId = @cateId;
End