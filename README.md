# SISTEMA-CARONA-UFF
Trabalho de Gerência de Projetos e Manutenção de Software - UFF

INSTRUÇÕES PARA SUBIR O SERVIDOR COM DOCKER:
Requisitos: DOCKER
    1 - Abra um TERMINAL estando com o caminho no diretório do projeto
    2 - RODE O COMANDO "docker-compose up"
    3 - AGUARDE aparecer esta mensagem no log: "(1 rows affected)"
    4 - Depois disso, para consultar a documentação da API acesse: http://localhost:5125/swagger/index.html

INSTRUÇÕES PARA DESENVOLVEDORES BACKEND:
Requisitos: DOCKER e .NET SDK 8.0
    1 - Comente a parte do serviço caronauff.api do docker-comopose.yml
    2 - Abra um TERMINAL estando com o caminho no diretório do projeto
    3 - RODE O COMANDO "docker-compose up"
    4 - AGUARDE aparecer esta mensagem no log: "(1 rows affected)"
    5 - Dentro do CaronaUFF.Api altere o arquivo appsettings.Development.json, de "Server=carona_db" para "Server=localhost"
    5 - Abra um TERMINAL no diretório com o caminho no CaronaUFF.Api
    6 - Execute o comando "dotnet build" e depois "dotnet run" para executar a API
    7 - Toda vez que alterar o projeto cancelar a execução da API e rode denovo
    8 - voce pode debugar dentro da IDE