[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

# FIAP: P�s Tech - Software Architecture

[![FIAP P�s Tech](https://postech.fiap.com.br/imgs/imgshare.png)](https://postech.fiap.com.br/?gad_source=1&gclid=Cj0KCQjwhfipBhCqARIsAH9msbmkyFZTmYIBomPCo-sGkBPLiiZYAkvTmM1Kx-QjwmYs3_NhyPKvP44aAtdZEALw_wcB)

## Objetivo do projeto
Este projeto foi realizado como parte de um entreg�vel para o curso 'P�s Tech - Software Architecture'.
O desafio proposto da fase 1 � realizar um projeto (MVP) monolito utilizando a arquitetura hexagonal para atender as necessidades de um autoatendimento de um fast food.


Funcionalidades:
* Gerenciamento de produtos.
* Gerencimento de clientes.
* Realizar um pedido e acompanhar.
* Pagamento via QRCode do Mercado Pago.

## Pr�-requisitos
* Docker							
	* O Docker � obrigat�rio ter instalado na m�quina para subir as depend�ncias e rodar o projeto corretamente, caso tenha d�vidas do procedimento consultar a [documenta��o](https://docs.docker.com/desktop/).
* [Postman](https://www.postman.com/downloads/) (n�o obrigat�rio)

## Como rodar localmente
Para rodar o projeto localmente � abrir um terminal na pasta base do projeto e executar o seguinte comando:

```docker-compose up -d```

Sendo executado normalmente, ir� subir um banco SQL Server e tamb�m a API do projeto, sendo poss�vel utilizar o [swagger](http://localhost:8080/swagger/index.html) para fazer requisi��es.
Caso prefira, � poss�vel realizar o download da [collection](https://github.com/postech-fiap-4soat-g01/FastFoodTotem/blob/main/FastFoodTotem%20-%20Jornada%20dos%20Usu%C3%A1rios.postman_collection.json) e utilizar no postman.

Link para documenta��o detalhada [aqui](https://docs.google.com/document/d/1YhRbWbEMPwUHi4J2lIz5dQMwZ6KrRzot/edit?usp=sharing&ouid=109865710704677504404&rtpof=true&sd=true).

## Subindo uma tag nova a imagem
Caso seja necessário entrar no root do projeto e rodar os seguintes comandos:

Necessário para realizar o build da imagem:
```docker build -t {user_docker_hub}/fast-food-totem:{tag} .```

Necessário para subir as alterações:
```docker push {user_docker_hub}/fast-food-totem:{tag}```