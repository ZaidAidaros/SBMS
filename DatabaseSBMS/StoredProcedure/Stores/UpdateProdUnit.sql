CREATE PROCEDURE [dbo].[UpdateProdUnit]
    @id int,
    @name NVARCHAR(10) , 
    @symbole NVARCHAR(5), 
    @subUName NVARCHAR(10), 
    @subSymbole NVARCHAR(5), 
    @description NVARCHAR(50),
    @rateMB int
AS
Begin
UPDATE [dbo].[ProdUnits] SET
             [name] = @name, 
             [symbole] = @symbole, 
             [subUName] = @subUName, 
             [subSymbole] = @subSymbole, 
             [description] = @description,
             [rateMB] = @rateMB
       WHERE [Id] = @id;
End
