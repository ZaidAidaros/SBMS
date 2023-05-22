CREATE PROCEDURE [dbo].[AddEmployee]
	@name nvarchar(50),
	@NIC int,
	@birthDate Date,
	@address  nvarchar(50),
	@phone nvarchar(50),
	@basicSalary real,
	@genderId int,
	@jobTitleId int,
	@note nvarchar(50)
AS
Begin
INSERT INTO [dbo].[Employees] (
            [dbo].[Employees].[name],
			[dbo].[Employees].[NIC],
			[dbo].[Employees].[birthDate],
			[dbo].[Employees].[address],
			[dbo].[Employees].[phone],
			[dbo].[Employees].[basicSalary],
			[dbo].[Employees].[genderId],
			[dbo].[Employees].[jobTitleId],
			[dbo].[Employees].[note]
            )
			VALUES (
		    @name,
			@NIC,
			@birthDate,
			@address,
			@phone,
			@basicSalary,
			@genderId,
			@jobTitleId,
			@note
			)
End
