CREATE PROCEDURE [dbo].[DeleteProdUnit]
	@id int
AS
Begin
DELETE FROM [dbo].[ProdUnits] WHERE [Id] = @id;
End