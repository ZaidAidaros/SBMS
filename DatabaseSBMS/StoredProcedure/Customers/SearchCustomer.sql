CREATE PROCEDURE [dbo].[SearchCustomer]
	@id int,
	@name nvarchar (50)
AS
Begin
SELECT [dbo].[Customers].[Id],
       [dbo].[Customers].[name],
       [dbo].[Customers].[NIC],
       [dbo].[Customers].[birthDate],
       [dbo].[Customers].[address],
       [dbo].[Customers].[phone],
       [dbo].[Gender].[name],
       [dbo].[CustCategory].[name]
FROM [dbo].[Customers]
INNER JOIN [dbo].[Gender] ON [dbo].[Customers].genId = [dbo].[Gender].Id
INNER JOIN [dbo].[CustCategory] ON [dbo].[Customers].cateId = [dbo].[CustCategory].Id
WHERE [dbo].[Customers].[Id] = @id 
OR [dbo].[Customers].[name] LIKE @name+'%'
OR [dbo].[CustCategory].[Id] = @id;
End