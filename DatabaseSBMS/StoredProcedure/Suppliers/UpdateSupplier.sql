CREATE PROCEDURE [dbo].[UpdateSupplier]
	@id int,
	@name nvarchar (50),
	@address nvarchar (50),
	@phone nvarchar (50),
	@cateId int
AS
Begin
UPDATE [dbo].[Suppliers] SET
				  [name] = @name,
				  [address] = @address,
				  [phone] = @phone,
                  [cateId] = @cateId
			WHERE [Id] = @id
End
