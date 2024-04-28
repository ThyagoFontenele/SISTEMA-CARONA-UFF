# SISTEMA-CARONA-UFF ![UFF](https://www.uff.br/sites/default/files/imagens-das-paginas/logo-uff-branco-site_0.png)
<p><strong>Trabalho de Gerência de Projetos e Manutenção de Software - UFF</strong></p>

<p><strong>Grupo:</strong></p>
<ul>
    <li>Daniel Iglesias Garrido</li>
    <li>João Omar Mendes Claudino</li>
    <li>Lucca Franca Possas</li>
    <li>Palloma da Silva Machado Nunes</li>
    <li>Rodrigo Freire Machado</li>
    <li>Thyago Fontenele da Silva</li>
</ul>
<a href="https://leomurta.github.io/courses/es2/trabalho_carona.pdf">Escopo do sistema</a>
<br />

<h3> INSTRUÇÕES PARA SUBIR O SERVIDOR COM DOCKER:</h3>
<p>Requisitos: DOCKER</p>
<ol>
    <li>Abra um TERMINAL estando com o caminho no diretório do projeto</li>
    <li>RODE O COMANDO "docker-compose up"</li>
    <li>AGUARDE aparecer esta mensagem no log: "(1 rows affected)"</li>
    <li>Depois disso, para consultar a documentação da API acesse: <a href="http://localhost:5125/swagger/index.html">http://localhost:5125/swagger/index.html</a></li>
</ol>
<h3> INSTRUÇÕES PARA DESENVOLVEDORES BACKEND:</h3>
<p>Requisitos: DOCKER e .NET SDK 8.0</p>
<ol>
    <li>Comente a parte do serviço caronauff.api do docker-comopose.yml
    <li>Abra um TERMINAL estando com o caminho no diretório do projeto
    <li>RODE O COMANDO "docker-compose up"
    <li>AGUARDE aparecer esta mensagem no log: "(1 rows affected)"
    <li>Dentro do CaronaUFF.Api altere o arquivo appsettings.Development.json, de "Server=carona_db" para "Server=localhost"
    <li>Abra um TERMINAL no diretório com o caminho no CaronaUFF.Api
    <li>Execute o comando "dotnet build" e depois "dotnet run" para executar a API
    <li>Toda vez que alterar o projeto cancelar a execução da API e rode denovo
    <li>voce pode debugar dentro da IDE
</ol>
