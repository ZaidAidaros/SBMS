CREATE PROCEDURE [dbo].[DeleteCustomer]
	@id int
AS
Begin
DELETE FROM [dbo].[Customers] WHERE [Id] = @id
End
