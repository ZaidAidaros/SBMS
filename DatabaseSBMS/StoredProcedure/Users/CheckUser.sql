CREATE PROCEDURE [dbo].[CheckUser] @name nchar(10), @password nchar(10)
As
Begin
SELECT [dbo].Users.Id,
       [dbo].Users.name,
       [dbo].Employees.name as EmpName,
       [dbo].Permission.name as Permission,
       [dbo].Users.empId,
       [dbo].Users.permId
FROM [dbo].Users 
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].Users.empId
INNER JOIN [dbo].Permission ON [dbo].Permission.Id = [dbo].Users.permId
WHERE [dbo].Users.name = @name AND [dbo].Users.password = @password
End