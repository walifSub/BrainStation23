CREATE DATABASE DB_SALESFORCETEST;
USE DB_SALESFORCETEST;

CREATE TABLE SALES_Order (
OrderId INT PRIMARY KEY IDENTITY,
OrderDate DATETIME NOT NULL,
Customer NVARCHAR(50) NOT NULL,
EntryBy NVARCHAR(50) NOT NULL,
EntryDateTime DATETIME NOT NULL,
EditBy NVARCHAR(50),
EditDate DATETIME
);


CREATE TABLE SALES_OrderDetails
(
OrderDetailId INT PRIMARY KEY IDENTITY,
OrderId INT NOT NULL,
Product NVARCHAR(100) NOT NULL,
Qty FLOAT NOT NULL,
Unit NVARCHAR(50) NOT NULL,
Rate DECIMAL(18,2) NOT NULL,
Total DECIMAL(18,2) NOT NULL,
CONSTRAINT FK_Order_OrderId_OrderDetail_OrderId FOREIGN KEY (OrderId) REFERENCES SALES_Order(OrderId)
);