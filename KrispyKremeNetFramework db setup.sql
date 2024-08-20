CREATE DATABASE KrispyKremeNetFramework;
GO

CREATE TABLE KrispyKremeNetFramework.dbo.Customers (
    [Id]		INT IDENTITY(1,1) PRIMARY KEY,
    [Name]		NVARCHAR(50) NOT NULL,
	[Address]	NVARCHAR(100) NOT NULL
); 
GO

CREATE TABLE KrispyKremeNetFramework.dbo.Donuts (
    [Id]		INT IDENTITY(1,1) PRIMARY KEY,
    [Name]		NVARCHAR(50) NOT NULL,
); 
GO

CREATE TABLE KrispyKremeNetFramework.dbo.Sale (
    [Id]            INT IDENTITY(1,1) PRIMARY KEY,
    [SaleDate]      DATETIME NOT NULL,
    [CustomerId]    INT NOT NULL,
    [DonutId]       INT NOT NULL,
    [Quantity]      INT NOT NULL,
    CONSTRAINT FK_Sale_Customer FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    CONSTRAINT FK_Sale_Donut FOREIGN KEY (DonutId) REFERENCES Donuts(Id)
); 
GO


INSERT INTO KrispyKremeNetFramework.dbo.Donuts (Name) 
VALUES 
('Original Glazed Doughnut'),
('Chocolate Iced Glazed Doughnut'),
('Glazed Raspberry Filled Doughnut'),
('Glazed Lemon Filled Doughnut'),
('Pumpkin Spice Cake Doughnut');
GO

-- Create Db for Net Core exercise
CREATE DATABASE KrispyKremeNetCore;
GO