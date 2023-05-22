CREATE PROCEDURE [dbo].[UpdateSuppCategory]
    @id int,
    @name NVARCHAR(10) , 
    @description NVARCHAR(50)  
AS
Begin
UPDATE [dbo].[SupCategory] SET
             [name] = @name,  
             [description] = @description
       WHERE [Id] = @id;
End
