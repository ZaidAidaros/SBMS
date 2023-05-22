CREATE PROCEDURE [dbo].[AddCustCategory]
	@name nvarchar(50),
	@description nvarchar(50)
AS
Begin
INSERT INTO [dbo].[CustCategory] (
            [dbo].[CustCategory].[name],
			[dbo].[CustCategory].[description]
			) 
            VALUES (
			@name,
			@description
			)
End