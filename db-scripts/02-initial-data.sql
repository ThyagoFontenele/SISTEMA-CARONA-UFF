USE CaronaUFF;
GO
INSERT INTO Usuario (Nome, Email, Senha, CPF, DataNascimento, Telefone, CEP, Cidade, Bairro, Endereco, Administrador)
VALUES ('Administrador UFF', 'adm@gmail.com', 'senha123', '123.456.789-00', '1990-05-15', '(11) 92234-5678', '12345-678', 'Niterói', 'Centro', 'Rua A, 123', 1);

INSERT INTO Usuario (Nome, Email, Senha, CPF, DataNascimento, Telefone, CEP, Cidade, Bairro, Endereco, Administrador)
VALUES ('Usuario X', 'user@gmail.com', 'senha123', '122.456.789-00', '1990-05-15', '(11) 91234-5678', '12345-678', 'Rio de Janeiro', 'Centro', 'Rua A, 123', 0);

INSERT INTO Veiculo(Marca, Modelo, Cor, Placa, Ano, UsuarioId)
VALUES ('Chevrolet', 'Camaro', 'Amarelo', '4D2FS4G', 2016, 2);