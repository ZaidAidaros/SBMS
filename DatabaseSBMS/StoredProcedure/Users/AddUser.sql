CREATE PROCEDURE [dbo].[AddUser] 
	@name nchar(10),
	@password nchar(10),
	@empId int,
	@permId int
	
AS
BEGIN
INSERT INTO Users (name,password,empId,permId) VALUES(@name,@password,@empId,@permId)
END