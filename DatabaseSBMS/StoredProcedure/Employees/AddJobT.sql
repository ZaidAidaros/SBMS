CREATE PROCEDURE [dbo].[AddJobT]
	@name nvarchar(50),
	@description nvarchar(50)
AS
Begin
INSERT INTO [dbo].JobTitle(
            [dbo].[JobTitle].[name],
			[dbo].[JobTitle].[description]
			) 
            VALUES (
			@name,
			@description
			)
End