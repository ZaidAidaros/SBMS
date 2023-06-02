﻿


use DatabaseSBMS;
INSERT INTO [dbo].[Gender]  VALUES(1,'Male');
INSERT INTO [dbo].[Gender]  VALUES(2,'FMale');
INSERT INTO [dbo].[MonyState]  VALUES(1,'Cash','نقدا');
INSERT INTO [dbo].[MonyState]  VALUES(2,'Later','آجل');
INSERT INTO [dbo].[InvoiceTypes]  VALUES('Normal Invoice');
INSERT INTO [dbo].[InvoiceTypes]  VALUES('Return Invoice');
INSERT INTO [dbo].[Offers]  VALUES('No Offer','there is no offer');


INSERT INTO [dbo].[JobTitle] VALUES ('Owner','Owner');
INSERT INTO [dbo].[JobTitle] VALUES ('Administrator','For Administration');
INSERT INTO [dbo].[JobTitle] VALUES ('Purchase Stuff','For Managing Purchases');
INSERT INTO [dbo].[JobTitle] VALUES ('Sales Stuff','For Managing Sales');
INSERT INTO [dbo].[Employees] (
            [dbo].[Employees].[name],
            [dbo].[Employees].[NIC],
            [dbo].[Employees].[birthDate],
            [dbo].[Employees].[address],
            [dbo].[Employees].[jobTitleId],
            [dbo].[Employees].[basicSalary],
            [dbo].[Employees].[genderId],
            [dbo].[Employees].[phone],
            [dbo].[Employees].[note]
            )VALUES(
            'Owner',
            1000001,
            '2000-1-1',
            'no place',
            1,
            0,
            1,
            '+967',
            'Owner'
            );


INSERT INTO [dbo].[Permission] VALUES('Admin');
INSERT INTO [dbo].[Permission] VALUES('SaleSt');
INSERT INTO [dbo].[Permission] VALUES('PurchaseSt');

INSERT INTO [dbo].[Users] (
            [dbo].[Users].name,
            [dbo].[Users].password,
            [dbo].[Users].empId,
            [dbo].[Users].permId
            )VALUES(
            'Owner',
            'Owner',
            1,1
            );

INSERT INTO dbo.SupCategory VALUES('VIP','UnKnown')
INSERT INTO dbo.Suppliers(name,phone,cateId,address) VALUES('UnKnown',8787876,1,'UnKnown')
INSERT INTO dbo.CustCategory VALUES('VIP','UnKnown')
INSERT INTO dbo.Customers(name,phone,address,cateId,genId) VALUES('UnKnown',8787876,'UnKnown',1,1)
INSERT INTO dbo.ProductCategory VALUES('Foods','Foods Foods')
INSERT INTO dbo.ProductCategory VALUES('Drinks','Drinks Drinks')
INSERT INTO dbo.ProdUnits (name,symbole,subUName,subSymbole,rateMB,description) VALUES('Kilo','K','gram','g',1000,'Kilo Kilo')
INSERT INTO dbo.Products(barCode,name,description,cateId,unitId,defPrice,totalQuantity) VALUES(278757,'Apple','Apple Apple Apple',1,1,300,0)
INSERT INTO dbo.Products(barCode,name,description,cateId,unitId,defPrice,totalQuantity) VALUES(72886,'Mango','Mango Mango Mango',1,1,300,0)
INSERT INTO dbo.Products(barCode,name,description,cateId,unitId,defPrice,totalQuantity) VALUES(7588,'Juse','Juse Juse Juse',2,1,200,0)
INSERT INTO dbo.Products(barCode,name,description,cateId,unitId,defPrice,totalQuantity) VALUES(2783757,'Watter','Watter Watter Watter',2,1,200,0)