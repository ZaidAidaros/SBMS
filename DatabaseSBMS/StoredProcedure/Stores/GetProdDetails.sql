CREATE PROCEDURE [dbo].[GetProdDetails]
	@prodId int
As
Begin
SELECT * FROM [dbo].[ProductsDetails] WHERE [dbo].[ProductsDetails].prodId = @prodId
End