USE stevesdoors;

DROP TABLE IF EXISTS `Supplier`;

DROP TABLE IF EXISTS `Employee`;

DROP TABLE IF EXISTS `Shipping`;

DROP TABLE IF EXISTS `QualityControl`;

DROP TABLE IF EXISTS `Invoice`;

DROP TABLE IF EXISTS `Product`;

DROP TABLE IF EXISTS `Order`;

DROP TABLE IF EXISTS `Customer`;


CREATE TABLE Product (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(255),
    Description VARCHAR(255),
    Material VARCHAR(255),
    Size VARCHAR(50),
    Color VARCHAR(50),
    Price DECIMAL(10, 2),
    StockQuantity INT
);

INSERT INTO Product (ProductName, Description, Material, Size, Color, Price, StockQuantity) VALUES
('Door1', 'Solid wood door', 'Wood', '36x80', 'Brown', 150.00, 50),
('Door2', 'Glass panel door', 'Glass/Wood', '32x80', 'White', 200.00, 30),
('Door3', 'Steel security door', 'Steel', '30x78', 'Gray', 180.00, 40),
('Door4', 'French double doors', 'Wood', '48x80', 'Natural', 250.00, 20),
('Door5', 'Fiberglass entry door', 'Fiberglass', '36x96', 'Red', 220.00, 25),
('Door6', 'Sliding barn door', 'Wood', '42x84', 'Natural', 180.00, 35),
('Door7', 'Aluminum patio door', 'Aluminum', '72x96', 'Silver', 300.00, 15),
('Door8', 'Classic panel door', 'Wood', '32x80', 'White', 160.00, 50),
('Door9', 'Iron entry door', 'Iron', '36x96', 'Black', 280.00, 20),
('Door10', 'PVC folding door', 'PVC', '24x80', 'Beige', 120.00, 40);




CREATE TABLE Customer (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(255),
    Phone VARCHAR(20),
    Address VARCHAR(255)
);

INSERT INTO Customer (FirstName, LastName, Email, Phone, Address) VALUES
('John', 'Doe', 'john.doe@email.com', '123-456-7890', '123 Main St'),
('Jane', 'Smith', 'jane.smith@email.com', '987-654-3210', '456 Oak Ave'),
('Bob', 'Johnson', 'bob.johnson@email.com', '555-123-4567', '789 Pine Ln'),
('Alice', 'Williams', 'alice.williams@email.com', '444-567-8901', '101 Elm St'),
('Charlie', 'Brown', 'charlie.brown@email.com', '777-888-9999', '202 Maple Ave'),
('Eva', 'Anderson', 'eva.anderson@email.com', '555-111-2222', '789 Cedar Blvd'),
('Samuel', 'Ward', 'samuel.ward@email.com', '111-333-4444', '234 Oak St'),
('Sophia', 'Garcia', 'sophia.garcia@email.com', '777-555-6666', '456 Pine Ln'),
('Lucas', 'Baker', 'lucas.baker@email.com', '999-888-7777', '678 Birch Ave'),
('Lily', 'Fisher', 'lily.fisher@email.com', '333-222-1111', '890 Maple Rd');


CREATE TABLE `Order` (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    ShipDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);


INSERT INTO `Order` (CustomerID, OrderDate, ShipDate, TotalAmount) VALUES
(1, '2023-01-01', '2023-01-10', 1500.00),
(2, '2023-02-01', '2023-02-12', 1200.00),
(3, '2023-03-01', '2023-03-15', 1800.00),
(4, '2023-04-01', '2023-04-20', 2000.00),
(5, '2023-05-01', '2023-05-18', 1600.00),
(6, '2023-06-01', '2023-06-10', 900.00),
(7, '2023-07-01', '2023-07-12', 1100.00),
(8, '2023-08-01', '2023-08-15', 1400.00),
(9, '2023-09-01', '2023-09-20', 1700.00),
(10, '2023-10-01', '2023-10-18', 2000.00);



CREATE TABLE Supplier (
    SupplierID INT AUTO_INCREMENT PRIMARY KEY,
    SupplierName VARCHAR(255),
    ContactPerson VARCHAR(100),
    Email VARCHAR(255),
    Phone VARCHAR(20),
    Address VARCHAR(255)
);

INSERT INTO Supplier (SupplierName, ContactPerson, Email, Phone, Address) VALUES
('Supplier1', 'John Supplier', 'john.supplier@email.com', '111-222-3333', 'Supplier St'),
('Supplier2', 'Jane Supplier', 'jane.supplier@email.com', '333-444-5555', 'Supplier Ave'),
('Supplier3', 'Bob Supplier', 'bob.supplier@email.com', '666-777-8888', 'Supplier Ln'),
('Supplier4', 'Alice Supplier', 'alice.supplier@email.com', '999-000-1111', 'Supplier Rd'),
('Supplier5', 'Charlie Supplier', 'charlie.supplier@email.com', '222-333-4444', 'Supplier Blvd'),
('Supplier6', 'Eva Supplier', 'eva.supplier@email.com', '111-222-9999', 'Supplier Blvd'),
('Supplier7', 'Samuel Supplier', 'samuel.supplier@email.com', '333-444-8888', 'Supplier Rd'),
('Supplier8', 'Sophia Supplier', 'sophia.supplier@email.com', '666-777-3333', 'Supplier Ave'),
('Supplier9', 'Lucas Supplier', 'lucas.supplier@email.com', '999-000-4444', 'Supplier St'),
('Supplier10', 'Lily Supplier', 'lily.supplier@email.com', '222-333-5555', 'Supplier Ln');

CREATE TABLE Invoice (
    PaymentID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    InvoiceDate DATE,
    TotalAmount DECIMAL(10, 2),
    IsPaid BOOLEAN,
    FOREIGN KEY (OrderID) REFERENCES `Order`(OrderID)
);

INSERT INTO Invoice (OrderID, InvoiceDate, TotalAmount, IsPaid) VALUES
(1, '2023-12-01', 1500.00, 0),
(2, '2023-12-03', 1800.00, 1),
(3, '2023-12-05', 2000.00, 0),
(4, '2023-12-08', 1600.00, 1),
(5, '2023-12-10', 1900.00, 0),
(6, '2023-12-01', 1500.00, 0),
(7, '2023-12-03', 1800.00, 1),
(8, '2023-12-05', 2000.00, 0),
(9, '2023-12-08', 1600.00, 1),
(10, '2023-12-10', 1900.00, 0);


CREATE TABLE QualityControl (
    ControlID INT AUTO_INCREMENT PRIMARY KEY,
    ProductID INT,
    DateChecked DATE,
    PassedQualityCheck BOOLEAN,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

INSERT INTO QualityControl (ProductID, DateChecked, PassedQualityCheck) VALUES
(1, '2023-11-05', 1),
(2, '2023-11-07', 0),
(3, '2023-11-09', 1),
(4, '2023-11-09', 0),
(5, '2023-11-09', 1),
(6, '2023-11-11', 1),
(7, '2023-11-11', 1),
(8, '2023-11-12', 1),
(9, '2023-11-18', 1),
(10, '2023-11-22', 1);


CREATE TABLE Shipping (
    ShippingID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    ShipDate DATE,
    ShipMethod VARCHAR(50),
    TrackingNumber VARCHAR(50),
    FOREIGN KEY (OrderID) REFERENCES `Order`(OrderID)
);

INSERT INTO Shipping (OrderID, ShipDate, ShipMethod, TrackingNumber) VALUES
(1, '2023-11-05', 'Express', 'ABC123'),
(2, '2023-11-06', 'Standard', 'DEF456'),
(3, '2023-11-08', 'Express', 'GHI789'),
(4, '2023-11-11', 'Standard', 'JKL012'),
(5, '2023-11-14', 'Express', 'MNO345'),
(6, '2023-11-16', 'Express', 'ABC567'),
(7, '2023-11-18', 'Standard', 'DEF123'),
(8, '2023-11-19', 'Express', 'GHI889'),
(9, '2023-11-21', 'Standard', 'JKL091'),
(10, '2023-11-22', 'Express', 'MNO534');


CREATE TABLE Employee (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Position VARCHAR(50),
    Email VARCHAR(255),
    Phone VARCHAR(20),
    HireDate DATE
);

INSERT INTO Employee (FirstName, LastName, Position, Email, Phone, HireDate) VALUES
('David', 'Miller', 'Manager', 'david.miller@email.com', '111-222-3333', '2022-01-15'),
('Emily', 'Johnson', 'Supervisor', 'emily.johnson@email.com', '333-444-5555', '2022-02-20'),
('Michael', 'Smith', 'Assembler', 'michael.smith@email.com', '666-777-8888', '2022-03-25'),
('Olivia', 'Davis', 'Designer', 'olivia.davis@email.com', '999-000-1111', '2022-04-30'),
('Daniel', 'Wilson', 'Technician', 'daniel.wilson@email.com', '222-333-4444', '2022-05-10'),
('Harper', 'Campbell', 'Manager', 'harper.campbell@email.com', '333-555-7777', '2022-06-15'),
('Owen', 'Perry', 'Supervisor', 'owen.perry@email.com', '888-777-5555', '2022-07-20'),
('Ella', 'Henderson', 'Assembler', 'ella.henderson@email.com', '444-666-8888', '2022-08-25'),
('Jackson', 'Barnes', 'Designer', 'jackson.barnes@email.com', '999-000-2222', '2022-09-30'),
('Aria', 'West', 'Technician', 'aria.west@email.com', '222-333-9999', '2022-10-10');