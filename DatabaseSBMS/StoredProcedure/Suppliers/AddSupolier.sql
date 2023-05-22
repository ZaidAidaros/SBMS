CREATE PROCEDURE [dbo].[AddSupolier]
	@name nvarchar (50),
	@address nvarchar (50),
	@phone nvarchar (50),
	@cateId int
AS
Begin
INSERT INTO [dbo].[Suppliers] (
				  [name],
				  [address],
				  [phone],
				  [cateId]
				  )VALUES(
				  @name,
				  @address,
				  @phone,
				  @cateId
				  )
End
