CREATE PROCEDURE [dbo].[IncDecProdDQuantity]
	@id int,
	@value int
AS
Begin
UPDATE dbo.ProductsDetails SET dbo.ProductsDetails.quantity = dbo.ProductsDetails.quantity + @value WHERE dbo.ProductsDetails.Id = @id;
End