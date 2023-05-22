CREATE PROCEDURE [dbo].[AddProdUnit]
    @name NVARCHAR(10) , 
    @symbole NVARCHAR(5), 
    @subUName NVARCHAR(10), 
    @subSymbole NVARCHAR(5), 
    @description NVARCHAR(50),
    @rateMB int
AS
Begin
INSERT INTO [dbo].[ProdUnits](
            [name], 
            [symbole], 
            [subUName], 
            [subSymbole], 
            [description],
            [rateMB]
            )VALUES(
            @name, 
            @symbole, 
            @subUName, 
            @subSymbole, 
            @description,
            @rateMB
            );
End
