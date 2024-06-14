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
GO
CREATE TABLE Carona (
	Id          INT           NOT NULL IDENTITY,
	Origem      NVARCHAR(100) NOT NULL,
	Destino     NVARCHAR(100) NOT NULL,
	DataHora    DATETIME      NOT NULL,
	Vagas       INT           NOT NULL,
	Observacoes NVARCHAR(255) NULL,
    Encerrada   BIT           NOT NULL CONSTRAINT Carona_Encerrada DEFAULT 0,
    Cancelada   BIT           NOT NULL CONSTRAINT Carona_Cancelada DEFAULT 0,
	VeiculoId   INT           NOT NULL,
	CONSTRAINT PK_Carona PRIMARY KEY (Id),
	CONSTRAINT FK_Carona_Veiculo FOREIGN KEY (VeiculoId) REFERENCES Veiculo (Id)
)
GO
CREATE TABLE CaronaPassageiros (
    CaronaId  INT NOT NULL,
    UsuarioId INT NOT NULL,
    CONSTRAINT PK_CaronaPassageiros PRIMARY KEY (CaronaId, UsuarioId),
    CONSTRAINT FK_CaronaPassageiros_Carona FOREIGN KEY (CaronaId) REFERENCES Carona (Id),
    CONSTRAINT FK_CaronaPassageiros_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario (Id)
)