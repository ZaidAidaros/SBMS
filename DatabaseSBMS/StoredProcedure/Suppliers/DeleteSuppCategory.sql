CREATE PROCEDURE [dbo].[DeleteSuppCategory]
	@id int
AS
Begin
DELETE FROM [dbo].[SupCategory] WHERE [Id] = @id;
End
