CREATE PROCEDURE [dbo].[UpdateCustCategory]
    @id int,
    @name NVARCHAR(10) , 
    @description NVARCHAR(50)  
AS
Begin
UPDATE [dbo].[CustCategory] SET
             [name] = @name,  
             [description] = @description
       WHERE [Id] = @id;
End
