CREATE PROCEDURE [dbo].[DeleteJobT]
	@id int
AS
Begin
DELETE FROM [dbo].[JobTitle] WHERE [dbo].[JobTitle].[Id] = @id
End
