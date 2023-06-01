﻿/*
Deployment script for DatabaseSBMS

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DatabaseSBMS"
:setvar DefaultFilePrefix "DatabaseSBMS"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[SaleInvoices].[discountRate] on table [dbo].[SaleInvoices] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[SaleInvoices])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping Foreign Key [dbo].[FK_MonyStates_SaleInvoices]...';


GO
ALTER TABLE [dbo].[SaleInvoices] DROP CONSTRAINT [FK_MonyStates_SaleInvoices];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_SalesOp_Employees]...';


GO
ALTER TABLE [dbo].[SaleInvoices] DROP CONSTRAINT [FK_SalesOp_Employees];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_InvoiceTypes_SaleInvoices]...';


GO
ALTER TABLE [dbo].[SaleInvoices] DROP CONSTRAINT [FK_InvoiceTypes_SaleInvoices];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_SalesOp_Customers]...';


GO
ALTER TABLE [dbo].[SaleInvoices] DROP CONSTRAINT [FK_SalesOp_Customers];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_SalesItems_SalesInv]...';


GO
ALTER TABLE [dbo].[SalesItems] DROP CONSTRAINT [FK_SalesItems_SalesInv];


GO
PRINT N'Starting rebuilding table [dbo].[SaleInvoices]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_SaleInvoices] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [empId]        INT           NOT NULL,
    [custId]       INT           NOT NULL,
    [invCustName]  NVARCHAR (50) NOT NULL,
    [total]        REAL          NOT NULL,
    [discountRate] REAL          NOT NULL,
    [monStateId]   INT           NOT NULL,
    [invTypeId]    INT           NOT NULL,
    [opDate]       DATETIME      NOT NULL,
    [note]         NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[SaleInvoices])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_SaleInvoices] ON;
        INSERT INTO [dbo].[tmp_ms_xx_SaleInvoices] ([Id], [empId], [custId], [invCustName], [total], [monStateId], [invTypeId], [opDate], [note])
        SELECT   [Id],
                 [empId],
                 [custId],
                 [invCustName],
                 [total],
                 [monStateId],
                 [invTypeId],
                 [opDate],
                 [note]
        FROM     [dbo].[SaleInvoices]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_SaleInvoices] OFF;
    END

DROP TABLE [dbo].[SaleInvoices];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_SaleInvoices]', N'SaleInvoices';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating Foreign Key [dbo].[FK_MonyStates_SaleInvoices]...';


GO
ALTER TABLE [dbo].[SaleInvoices] WITH NOCHECK
    ADD CONSTRAINT [FK_MonyStates_SaleInvoices] FOREIGN KEY ([monStateId]) REFERENCES [dbo].[MonyState] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_SalesOp_Employees]...';


GO
ALTER TABLE [dbo].[SaleInvoices] WITH NOCHECK
    ADD CONSTRAINT [FK_SalesOp_Employees] FOREIGN KEY ([empId]) REFERENCES [dbo].[Employees] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_InvoiceTypes_SaleInvoices]...';


GO
ALTER TABLE [dbo].[SaleInvoices] WITH NOCHECK
    ADD CONSTRAINT [FK_InvoiceTypes_SaleInvoices] FOREIGN KEY ([invTypeId]) REFERENCES [dbo].[InvoiceTypes] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_SalesOp_Customers]...';


GO
ALTER TABLE [dbo].[SaleInvoices] WITH NOCHECK
    ADD CONSTRAINT [FK_SalesOp_Customers] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customers] ([Id]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_SalesItems_SalesInv]...';


GO
ALTER TABLE [dbo].[SalesItems] WITH NOCHECK
    ADD CONSTRAINT [FK_SalesItems_SalesInv] FOREIGN KEY ([saleId]) REFERENCES [dbo].[SaleInvoices] ([Id]);


GO
PRINT N'Altering Procedure [dbo].[AddSaleInvoice]...';


GO
ALTER PROCEDURE [dbo].[AddSaleInvoice]
	@empId int,
	@custId int,
	@invCustName nvarchar(50),
	@total real,
	@discountRate real,
	@monStateId int,
	@invTypeId int,
	@note nvarchar(50),
	@date DateTime,
    @ID int out
AS
Begin
SET NOCOUNT ON
INSERT INTO [dbo].SaleInvoices(
            [dbo].SaleInvoices.empId,
			[dbo].SaleInvoices.custId,
			[dbo].SaleInvoices.invCustName,
            [dbo].SaleInvoices.total,
            [dbo].SaleInvoices.discountRate,
			[dbo].SaleInvoices.monStateId,
			[dbo].SaleInvoices.invTypeId,
			[dbo].SaleInvoices.opDate,
			[dbo].SaleInvoices.note
			)
            VALUES (
			@empId,
			@custId,
			@invCustName,
			@total,
			@discountRate,
			@monStateId,
			@invTypeId,
			@date,
			@note
			);
SET @ID = IDENT_CURRENT('SaleInvoices');
End
GO
PRINT N'Altering Procedure [dbo].[GetSales]...';


GO
ALTER PROCEDURE [dbo].[GetSales]
As
Begin
SELECT [dbo].SaleInvoices.Id,
       [dbo].SaleInvoices.invCustName,
       [dbo].Customers.[name] as CustName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as MonyState,
       [dbo].SaleInvoices.total,
       [dbo].SaleInvoices.discountRate,
       [dbo].SaleInvoices.opDate,
       [dbo].SaleInvoices.note
FROM [dbo].SaleInvoices
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].SaleInvoices.empId
INNER JOIN [dbo].Customers ON [dbo].Customers.Id = [dbo].SaleInvoices.custId
INNER JOIN [dbo].MonyState ON [dbo].MonyState.Id = [dbo].SaleInvoices.monStateId
INNER JOIN [dbo].InvoiceTypes ON [dbo].InvoiceTypes.Id = [dbo].SaleInvoices.invTypeId
End
GO
PRINT N'Altering Procedure [dbo].[SalesReport]...';


GO
ALTER PROCEDURE [dbo].[SalesReport]
	@invTotal Real,
	@invTypId int,
	@monyStaeId int,
	@name nvarchar(50),
    @fromDate DateTime,
    @toDate DateTime
AS
Begin
SELECT [dbo].SaleInvoices.Id,
       [dbo].SaleInvoices.invCustName,
       [dbo].Customers.[name] as CustName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as MonyState,
       [dbo].SaleInvoices.total,
       [dbo].SaleInvoices.discountRate,
       [dbo].SaleInvoices.opDate,
       [dbo].SaleInvoices.note
FROM [dbo].SaleInvoices
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].SaleInvoices.empId
INNER JOIN [dbo].Customers ON [dbo].Customers.Id = [dbo].SaleInvoices.custId
INNER JOIN [dbo].MonyState ON [dbo].MonyState.Id = [dbo].SaleInvoices.monStateId
INNER JOIN [dbo].InvoiceTypes ON [dbo].InvoiceTypes.Id = [dbo].SaleInvoices.invTypeId
WHERE [dbo].SaleInvoices.invTypeId = @invTypId
And [dbo].SaleInvoices.monStateId = @monyStaeId
And [dbo].Customers.[name] LIKE '%'+@name+'%'
And [dbo].SaleInvoices.opDate >= @fromDate
And [dbo].SaleInvoices.opDate <= @toDate
And [dbo].SaleInvoices.total >= @invTotal
End
GO
PRINT N'Altering Procedure [dbo].[SearchSales]...';


GO
ALTER PROCEDURE [dbo].[SearchSales]
	@id int,
	@invTypId int,
	@name nvarchar(50),
    @date DateTime
AS
Begin
SELECT [dbo].SaleInvoices.Id,
       [dbo].SaleInvoices.invCustName,
       [dbo].Customers.[name] as CustName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as MonyState,
       [dbo].SaleInvoices.total,
       [dbo].SaleInvoices.discountRate,
       [dbo].SaleInvoices.opDate,
       [dbo].SaleInvoices.note
FROM [dbo].SaleInvoices
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].SaleInvoices.empId
INNER JOIN [dbo].Customers ON [dbo].Customers.Id = [dbo].SaleInvoices.custId
INNER JOIN [dbo].MonyState ON [dbo].MonyState.Id = [dbo].SaleInvoices.monStateId
INNER JOIN [dbo].InvoiceTypes ON [dbo].InvoiceTypes.Id = [dbo].SaleInvoices.invTypeId
WHERE [dbo].SaleInvoices.Id = @id 
OR [dbo].SaleInvoices.invTypeId = @invTypId
OR [dbo].Customers.[name] LIKE '%'+@name+'%'
OR [dbo].Employees.[name] LIKE '%'+@name+'%'
OR [dbo].MonyState.[name] LIKE '%'+@name+'%'
OR [dbo].SaleInvoices.opDate >= @date
End
GO
PRINT N'Creating Procedure [dbo].[PurchasesReport]...';


GO
CREATE PROCEDURE [dbo].[PurchasesReport]
	@invTotal Real,
	@invTypId int,
	@monyStaeId int,
	@name nvarchar(50),
    @fromDate DateTime,
    @toDate DateTime
AS
Begin
SELECT [dbo].PurchaseInvoices.Id,
       [dbo].PurchaseInvoices.invSuppName,
       [dbo].Suppliers.[name] as CustName,
       [dbo].Employees.[name] as EmpName,
       [dbo].MonyState.[name] as MonyState,
       [dbo].InvoiceTypes.[name] as MonyState,
       [dbo].PurchaseInvoices.total,
       [dbo].PurchaseInvoices.opDate,
       [dbo].PurchaseInvoices.note
FROM [dbo].PurchaseInvoices
INNER JOIN [dbo].Employees ON [dbo].Employees.Id = [dbo].PurchaseInvoices.empId
INNER JOIN [dbo].Suppliers ON [dbo].Suppliers.Id = [dbo].PurchaseInvoices.suppId
INNER JOIN [dbo].MonyState ON [dbo].MonyState.Id = [dbo].PurchaseInvoices.monStateId
INNER JOIN [dbo].InvoiceTypes ON [dbo].InvoiceTypes.Id = [dbo].PurchaseInvoices.invTypeId
WHERE [dbo].PurchaseInvoices.invTypeId = @invTypId
And [dbo].PurchaseInvoices.monStateId = @monyStaeId
And [dbo].Suppliers.[name] LIKE '%'+@name+'%'
And [dbo].PurchaseInvoices.opDate >= @fromDate
And [dbo].PurchaseInvoices.opDate <= @toDate
And [dbo].PurchaseInvoices.total >= @invTotal
End
GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[SaleInvoices] WITH CHECK CHECK CONSTRAINT [FK_MonyStates_SaleInvoices];

ALTER TABLE [dbo].[SaleInvoices] WITH CHECK CHECK CONSTRAINT [FK_SalesOp_Employees];

ALTER TABLE [dbo].[SaleInvoices] WITH CHECK CHECK CONSTRAINT [FK_InvoiceTypes_SaleInvoices];

ALTER TABLE [dbo].[SaleInvoices] WITH CHECK CHECK CONSTRAINT [FK_SalesOp_Customers];

ALTER TABLE [dbo].[SalesItems] WITH CHECK CHECK CONSTRAINT [FK_SalesItems_SalesInv];


GO
PRINT N'Update complete.';


GO
