CREATE PROCEDURE [dbo].[UpdateProdCategory]
    @id int,
    @name NVARCHAR(10) , 
    @description NVARCHAR(50)  
AS
Begin
UPDATE [dbo].[ProductCategory] SET
             [name] = @name,  
             [description] = @description
       WHERE [Id] = @id;
End
