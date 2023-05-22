CREATE PROCEDURE [dbo].[GetSaleItems] 
      @saleId int
AS
Begin
SELECT  [dbo].SalesItems.Id,
        [dbo].Products.[name],
        [dbo].[ProdUnits].[name],
        [dbo].SalesItems.quantity,
        [dbo].SalesItems.price,
        [dbo].ProductsDetails.[expireDate],
        [dbo].Offers.[name]
FROM [dbo].SalesItems 
INNER JOIN [dbo].Products ON [dbo].Products.Id = [dbo].SalesItems.prodId
INNER JOIN [dbo].ProductsDetails ON [dbo].ProductsDetails.Id = [dbo].SalesItems.proddId
INNER JOIN [dbo].[ProdUnits] ON [dbo].[ProdUnits].Id = [dbo].[Products].unitId
INNER JOIN [dbo].Offers ON [dbo].Offers.Id = [dbo].SalesItems.offerId
WHERE [dbo].SalesItems.saleId = @saleId
End
