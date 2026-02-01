SQL QUERY

---------------------------------------------------------------
CREATE DATABASE BankDB;
GO
USE BankDB;
GO
CREATE TABLE BankAccounts (
    AccountNumber UNIQUEIDENTIFIER PRIMARY KEY,
    Owner NVARCHAR(100),
    Balance DECIMAL(18,2)
);
GO
---------------------------------------------------------------

This application uses SQL Server LocalDB / SQL Express, so all data is stored locally on the testing machine.
Data is not shared across different systems.
The database must be created once before running the application, after which the project can be built and run normally using Visual Studio
