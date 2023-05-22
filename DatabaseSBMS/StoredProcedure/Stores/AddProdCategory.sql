CREATE PROCEDURE [dbo].[AddProdCategory]
	@name nvarchar(50),
	@description nvarchar(50)
AS
Begin
INSERT INTO [dbo].[ProductCategory](
            [dbo].[ProductCategory].[name],
			[dbo].[ProductCategory].[description]
			) 
            VALUES (
			@name,
			@description
			)
End