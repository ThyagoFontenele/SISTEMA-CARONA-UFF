CREATE DATABASE CaronaUFF;
GO
USE CaronaUFF;
GO
CREATE TABLE [User] (
    Id         INT           NOT NULL IDENTITY,
    Name       NVARCHAR(255) NOT NULL,
    Email      NVARCHAR(255) NOT NULL,        
    Password   NVARCHAR(255) NOT NULL,
    Cpf        NVARCHAR(11)  NOT NULL,
    BirthDate  DATE          NOT NULL,
    CONSTRAINT PK_User PRIMARY KEY (Id)
);