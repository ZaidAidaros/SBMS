CREATE PROCEDURE [dbo].[DeleteProdCategory]
	@id int
AS
Begin
DELETE FROM [dbo].[ProductCategory] WHERE [Id] = @id;
End
