CREATE PROCEDURE [dbo].[SearchEmployee]
	@id int,
	@name nvarchar(50)
AS
Begin
SELECT [dbo].[Employees].[Id],
       [dbo].[Employees].[name],
       [dbo].[Employees].[NIC],
       [dbo].[Employees].[birthDate],
       [dbo].[Employees].[address],
       [dbo].[Employees].[phone],
       [dbo].[Employees].[basicSalary],
       [dbo].[Gender].[name] as Gender,
       [dbo].[JobTitle].[name] as JTitle,
       [dbo].[Employees].[note]
FROM [dbo].[Employees]
INNER JOIN [dbo].JobTitle ON [dbo].Employees.jobTitleId = [dbo].JobTitle.Id
INNER JOIN [dbo].Gender ON [dbo].Employees.genderId = [dbo].Gender.Id
WHERE [dbo].[Employees].[Id] = @id OR [dbo].[Employees].[name] LIKE @name+'%';
End