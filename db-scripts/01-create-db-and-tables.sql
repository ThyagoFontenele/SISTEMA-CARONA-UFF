CREATE DATABASE CaronaUFF;
GO
USE CaronaUFF;
GO
CREATE TABLE Usuario (
    Id             INT           NOT NULL IDENTITY,
    Nome           NVARCHAR(255) NOT NULL,
    Email          NVARCHAR(255) NOT NULL CONSTRAINT UNIQUE_Usuario_Email UNIQUE,
    Senha          NVARCHAR(255) NOT NULL,
    CPF            NVARCHAR(20)  NOT NULL CONSTRAINT UNIQUE_Usuario_CPF UNIQUE,
    DataNascimento DATE          NOT NULL,
    Telefone       NVARCHAR(50)  NOT NULL CONSTRAINT UNIQUE_Usuario_Telefone UNIQUE,
    CEP            NVARCHAR(20)  NOT NULL,
    Cidade         NVARCHAR(50)  NOT NULL,
    Bairro         NVARCHAR(50)  NOT NULL,
    Endereco       NVARCHAR(50)  NOT NULL,
    Administrador  BIT           NOT NULL CONSTRAINT Usuario_Administrador DEFAULT 0,
    CONSTRAINT PK_Usuario PRIMARY KEY (Id)
)
GO
CREATE TABLE Veiculo (
    Id        INT           NOT NULL IDENTITY,
    Marca     NVARCHAR(100) NOT NULL,
    Modelo    NVARCHAR(100) NOT NULL,
    Cor       NVARCHAR(20)  NOT NULL,
    Placa     NVARCHAR(20)  NOT NULL,
    Ano       INT           NOT NULL,
    UsuarioId INT           NOT NULL,
    CONSTRAINT PK_Veiculo PRIMARY KEY (Id),
    CONSTRAINT FK_Veiculo_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario (Id) 
)