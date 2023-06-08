CREATE DATABASE StoreDBase
GO
USE StoreDBase

CREATE TABLE Categories (
    Id int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(30) NOT NULL
)

CREATE TABLE Products (
    Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,

    [Name] nvarchar(30) NOT NULL,
    Quantity int CHECK (Quantity > 0) NOT NULL DEFAULT(0),
	Price money CHECK (Price > 0) NOT NULL,
    CategoryId int FOREIGN KEY REFERENCES Categories(Id),
)

INSERT INTO Categories([Name])
VALUES('Computer'),('Phone'),('TV'),('Playstation')

INSERT INTO Products([Name],Quantity, Price, CategoryId)
VALUES('Asus', 10, 3000, 1),
('Toshiba', 8, 1200, 1),
('HP', 15, 1000, 1),
('Iphone', 10, 2700, 2),
('Xiaomi', 20, 1350, 2),
('Samsung', 15, 2000, 2),
('LG', 16, 2200, 3),
('Grundig', 13, 2500, 3),
('Philips', 10, 2800, 3),
('PS3', 25, 400, 4),
('PS4', 15, 600, 4),
('PS5', 5, 1200, 4)