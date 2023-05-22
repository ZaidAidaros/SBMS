CREATE PROCEDURE [dbo].[AddProduct]
	@barCode int,
	@name nvarchar(50),
	@description nvarchar(50),
	@defPrice real,
	@cateId int,
	@unitId int
AS
Begin
INSERT INTO [dbo].[Products](
			[dbo].[Products].[barCode],
            [dbo].[Products].[name],
			[dbo].[Products].[description],
			[dbo].[Products].[defPrice],
			[dbo].[Products].[totalQuantity],
			[dbo].[Products].[cateId],
			[dbo].[Products].[unitId]
			) 
            VALUES (
	        @barCode,
			@name,
			@description,
			@defPrice,
			0,
	        @cateId,
	        @unitId
			);
End
