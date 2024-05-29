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

<h3> INSTRUÇÕES PARA DESENVOLVEDORES:</h3>
<p>Requisitos: DOCKER e .NET SDK 8.0</p>
<ol>
    <li>Baixe e instale o Docker e o .NET SDK 8.0 no seu computador</li>
    <li>Abra um TERMINAL estando com o caminho no diretório do projeto</li>
    <li>RODE O COMANDO "docker-compose up"</li>
    <li>AGUARDE aparecer esta mensagem no log: "(1 rows affected)"</li>
    <li>Abra um TERMINAL no diretório com o caminho no CaronaUFF.Api</li>
    <li>Execute o comando "dotnet build" e depois "dotnet run" para executar a API</li>
    <li>Depois disso, para consultar a documentação da API acesse: <a href="http://localhost:5125/swagger/index.html">http://localhost:5125/swagger/index.html</a></li>
</ol>

<h2>Branches de trabalho</h2>
<p>Para realizar as alterações no código, utilizamos o padrão do Git Flow para criar branches.</p>
<ul>
    <li>Features - feat/nome-feature</li>
    <li>Release - release/numero-versao(Ex.: 2.2.0.0)</li>
    <li>Bugfix (correções feitas para integrar em dev ou em branchs de release e entrar no próximo deploy) - bugfix/nome-correcao</li>
    <li>Hotfix (correções feitas para integrar em main e fazer um deploy de emergência)- hotfix/nome-fix</li>
</ul>



