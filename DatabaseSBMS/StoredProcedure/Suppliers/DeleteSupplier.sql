CREATE PROCEDURE [dbo].[DeleteSupplier]
	@id int
AS
Begin
DELETE FROM [dbo].[Suppliers] WHERE [Id] = @id
End