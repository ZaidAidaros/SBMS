CREATE PROCEDURE [dbo].[UpdateJobT]
	@id int,
	@name nvarchar(50),
	@description nvarchar(50)
AS
Begin
UPDATE [dbo].[JobTitle] SET
            [dbo].[JobTitle].[name] = @name,
			[dbo].[JobTitle].[description] = @description
			WHERE [dbo].[JobTitle].Id = @id
End
