USE BookShop
INSERT INTO Manufacturer ( Name, Address ) 
VALUES 
('manufacturer1', 'address...'),
('manufacturer2', 'address...'),
('manufacturer3', 'address...')

INSERT INTO Category ( Name, Description ) 
VALUES 
('category1', 'description...'),
('category2', 'description...'),
('category3', 'description...')

INSERT INTO Product ( Name, Price, Description, Category, Manufacturer ) 
VALUES 
('product1', 2000.35, 'description...', 1, 1),
('product2', 3000.45, 'description...', 2, 2),
('product3', 4000.55, 'description...', 3, 3)

INSERT INTO Image ( Path, Product, IsMain ) 
VALUES 
('\images\690825.jpg', 1, DEFAULT),
('\images\690825.jpg', 2, 1),
('\images\690825.jpg', 3, DEFAULT)

INSERT INTO ProductSale ( Product, Count, DateTime ) 
VALUES 
(1, 2, '2023-07-05 10:32:00'),
(2, 3, '2023-07-06 9:31:00'),
(3, 4, '2023-07-07 8:30:00')

SELECT Name, Price, Description, Category, Manufacturer FROM Product
	WHERE Price < 4000 AND Price > 1000;

SELECT Name, Price, Description, Category, Manufacturer FROM Product
	WHERE Name LIKE 'product%';

SELECT Name, Price, Description, Category, Manufacturer FROM Product
	WHERE Id IN (1, 3);

SELECT Name, Price, Description, Category, Manufacturer FROM Product
	WHERE Category NOT IN (SELECT Id FROM Category WHERE Id = 3);

SELECT * FROM ProductSale WHERE Count BETWEEN 1 AND 3;

SELECT TOP 2 * FROM Category;

SELECT * FROM ProductSale ORDER BY DateTime DESC;

SELECT Category, Name FROM Product GROUP BY Category, Name;

SELECT Category, COUNT(Id) as 'ProductsCount' FROM Product GROUP BY Category;

UPDATE Category SET Description = 'new description...' WHERE Name = 'category1';
UPDATE Manufacturer SET Address = 'new address...' WHERE Id = 1;
UPDATE Product SET Price = 2100 WHERE Id IN (2, 3);
UPDATE Image SET Path = '\images\693424.jpg' WHERE NOT IsMain = 1;
UPDATE ProductSale SET Product = 1 WHERE DateTime BETWEEN '2023-07-05' AND '2023-07-06';

DELETE Product WHERE Id = 1;

SELECT P.Id AS 'ProductId', Name, Price, Description, 
Category, Manufacturer, PS.Id AS 'ProductSaleId', DateTime, Count 
FROM Product AS P
INNER JOIN ProductSale AS PS
ON P.Id = PS.Product;

SELECT I.Path FROM IMAGE AS I LEFT JOIN Product P ON P.Id = I.Product;

SELECT M.Name as 'ManufacturerName', P.Name 
FROM Product AS P RIGHT JOIN Manufacturer M ON P.Manufacturer = M.Id;