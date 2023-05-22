CREATE PROCEDURE [dbo].[AddCustomer]
	@name nvarchar (50),
	@nic int,
	@birthDate Date,
	@address nvarchar (50),
	@phone nvarchar (50),
	@genId int,
	@cateId int
AS
Begin
INSERT INTO [dbo].[Customers] (
                  [name],
				  [NIC],
				  [birthDate],
				  [address],
				  [phone],
				  [genId],
				  [cateId]
				  )VALUES(
				  @name,
				  @nic,
				  @birthDate,
				  @address,
				  @phone,
				  @genId,
				  @cateId
				  )
End
	