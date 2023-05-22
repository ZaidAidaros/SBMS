CREATE PROCEDURE [dbo].[SearchProduct]
	@id int,
	@barCode int,
    @name nvarchar(50)
As
Begin
SELECT [dbo].[Products].[Id],
       [dbo].[Products].[barCode],
       [dbo].[Products].[name],
       [dbo].[Products].[description],
       [dbo].[ProductCategory].[name],
       [dbo].[ProdUnits].[name],
       [dbo].[Products].[defPrice],
       [dbo].[Products].[totalQuantity]
FROM [dbo].[Products]
INNER JOIN [dbo].[ProductCategory] ON [dbo].[Products].cateId = [dbo].[ProductCategory].Id
INNER JOIN [dbo].[ProdUnits] ON [dbo].[Products].unitId = [dbo].[ProdUnits].Id
WHERE [dbo].[Products].Id = @id OR [dbo].[Products].barCode = @barCode OR [dbo].[Products].[name] like @name+'%';
End
