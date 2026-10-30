CREATE DATABASE SocietixDB;
GO

USE SocietixDB;
GO

CREATE TABLE Societies (
    SocietyId   INT IDENTITY(1,1) PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL UNIQUE,
    Category    NVARCHAR(50)  NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME2     NOT NULL DEFAULT SYSDATETIME()
);
GO