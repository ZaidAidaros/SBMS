CREATE PROCEDURE [dbo].[UpdateEmployee]
	@id int,
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
UPDATE [dbo].Employees SET
            [dbo].Employees.name = @name,
			[dbo].Employees.NIC = @NIC,
			[dbo].Employees.birthDate = @birthDate,
			[dbo].Employees.address = @address,
			[dbo].Employees.phone = @phone,
			[dbo].Employees.basicSalary = @basicSalary,
			[dbo].Employees.genderId = @genderId,
			[dbo].Employees.jobTitleId = @jobTitleId,
			[dbo].Employees.note = @note
	  WHERE [dbo].Employees.Id = @id
End