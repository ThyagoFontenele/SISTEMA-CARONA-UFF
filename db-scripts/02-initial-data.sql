USE CaronaUFF;
GO
INSERT INTO Usuario (Nome, Email, Senha, CPF, DataNascimento, Telefone, CEP, Cidade, Bairro, Endereco, Administrador)
VALUES ('Administrador UFF', 'adm@gmail.com', '$2a$11$YQKi28DDcDYyLqwVho/wqeZ/WUU8Sn5niqEP5LshLAy2NoWp7z5ya', '123.456.789-00', '1990-05-15', '(11) 92234-5678', '12345-678', 'Niterói', 'Centro', 'Rua A, 123', 1);

INSERT INTO Veiculo(Marca, Modelo, Cor, Placa, Ano, UsuarioId)
VALUES ('Chevrolet', 'Camaro', 'Amarelo', '4D2FS4G', 2016,1);

INSERT INTO Carona(Origem, Destino, DataHora, Vagas, Observacoes, VeiculoId, RetornoId)
VALUES ('UFF', 'Casa', '2020-06-01 18:00:00', 3, NULL, 1, NULL);

INSERT INTO CaronaPassageiros(CaronaId, UsuarioId)
VALUES (1, 1);