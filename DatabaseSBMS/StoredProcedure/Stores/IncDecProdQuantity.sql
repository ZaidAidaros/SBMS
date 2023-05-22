CREATE PROCEDURE [dbo].[IncDecProdQuantity]
	@proId int,
	@value int
AS
Begin
UPDATE dbo.Products SET dbo.Products.totalQuantity = dbo.Products.totalQuantity + @value WHERE dbo.Products.Id = @proId;
End