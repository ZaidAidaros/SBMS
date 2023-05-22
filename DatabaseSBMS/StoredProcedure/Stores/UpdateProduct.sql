CREATE PROCEDURE [dbo].[UpdateProduct]
    @id int,
    @barCode int,
    @name NVARCHAR(10),
    @description NVARCHAR(50),
	@defPrice real, 
	@cateId int,
	@unitId int
AS
Begin
UPDATE [dbo].[Products] SET
             [barCode] = @barCode,
             [name] = @name, 
             [description] = @description,
             [defPrice] = @defPrice,
             [cateId] = @cateId,
             [unitId] = @unitId
       WHERE [Id] = @id;
End
