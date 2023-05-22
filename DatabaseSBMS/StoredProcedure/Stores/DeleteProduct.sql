CREATE PROCEDURE [dbo].[DeleteProduct]
	@id int
AS
Begin
DELETE FROM [dbo].[Products] WHERE [Id] = @id;
End
