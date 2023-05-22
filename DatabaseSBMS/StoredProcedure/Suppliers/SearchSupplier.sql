CREATE PROCEDURE [dbo].[SearchSupplier]
	@id int,
	@name nvarchar (50)
AS
Begin
SELECT [dbo].[Suppliers].[Id],
       [dbo].[Suppliers].[name],
       [dbo].[Suppliers].[address],
       [dbo].[Suppliers].[phone],
       [dbo].[SupCategory].[name]
FROM [dbo].[Suppliers]
INNER JOIN [dbo].[SupCategory] ON [dbo].[Suppliers].cateId = [dbo].[SupCategory].Id
WHERE [dbo].[Suppliers].[Id] = @id 
OR [dbo].[Suppliers].[name] LIKE @name+'%';
End