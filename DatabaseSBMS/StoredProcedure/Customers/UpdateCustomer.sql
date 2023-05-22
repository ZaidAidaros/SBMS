CREATE PROCEDURE [dbo].[UpdateCustomer]
	@id int,
	@name nvarchar (50),
	@nic int,
	@birthDate Date,
	@address nvarchar (50),
	@phone nvarchar (50),
	@genId int,
	@cateId int
AS
Begin
UPDATE [dbo].[Customers] SET
                  [name] = @name,
				  [NIC] = @nic,
				  [birthDate] = @birthDate,
				  [address] = @address,
				  [phone] = @phone,
				  [genId] = @genId,
				  [cateId] = @cateId
			WHERE [Id] = @id
End