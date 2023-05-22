CREATE PROCEDURE [dbo].[DeleteEmployee]
	@id int
AS
Begin
DELETE FROM [dbo].[Employees] WHERE [dbo].[Employees].[Id] = @id
End