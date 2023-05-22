CREATE PROCEDURE [dbo].[DeleteCustCategory]
	@id int
AS
Begin
DELETE FROM [dbo].[CustCategory] WHERE [Id] = @id;
End

