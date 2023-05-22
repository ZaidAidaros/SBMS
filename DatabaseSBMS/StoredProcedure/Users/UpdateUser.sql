CREATE PROCEDURE [dbo].[UpdateUser] 
	@name nchar(10),
	@password nchar(10),
	@empId int,
	@permId int,
	@id int
AS
BEGIN
	UPDATE Users SET name =@name, password= @password, empId= @empId, permId=@permId WHERE Id=@id
END
