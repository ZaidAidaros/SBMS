CREATE PROCEDURE [dbo].[DeleteUser] @id int
As
Begin
DELETE FROM Users WHERE Id = @id
End
