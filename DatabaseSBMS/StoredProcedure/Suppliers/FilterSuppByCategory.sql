CREATE PROCEDURE [dbo].[FilterSuppByCategory]
	@cateId int
AS
Begin
SELECT [dbo].[Suppliers].[Id],
       [dbo].[Suppliers].[name],
       [dbo].[Suppliers].[address],
       [dbo].[Suppliers].[phone],
       [dbo].[SupCategory].[name]
FROM [dbo].[Suppliers]
INNER JOIN [dbo].[SupCategory] ON [dbo].[Suppliers].cateId = [dbo].[SupCategory].Id
WHERE [dbo].[SupCategory].[Id] = @cateId;
End
