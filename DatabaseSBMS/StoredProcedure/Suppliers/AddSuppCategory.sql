CREATE PROCEDURE [dbo].[AddSuppCategory]
	@name nvarchar(50),
	@description nvarchar(50)
AS
Begin
INSERT INTO [dbo].[SupCategory] (
            [dbo].[SupCategory].[name],
			[dbo].[SupCategory].[description]
			) 
            VALUES (
			@name,
			@description
			)
End