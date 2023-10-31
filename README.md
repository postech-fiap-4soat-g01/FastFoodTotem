[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

# FIAP: Pós Tech - Software Architecture

[![FIAP Pós Tech](https://postech.fiap.com.br/imgs/imgshare.png)](https://postech.fiap.com.br/?gad_source=1&gclid=Cj0KCQjwhfipBhCqARIsAH9msbmkyFZTmYIBomPCo-sGkBPLiiZYAkvTmM1Kx-QjwmYs3_NhyPKvP44aAtdZEALw_wcB)

## Objetivo do projeto
Este projeto foi realizado como parte de um entregável para o curso 'Pós Tech - Software Architecture'.
O desafio proposto da fase 1 é realizar um projeto (MVP) monolito utilizando a arquitetura hexagonal para atender as necessidades de um autoatendimento de um fast food.


Funcionalidades:
* Gerenciamento de produtos.
* Gerencimento de clientes.
* Realizar um pedido e acompanhar.
* Pagamento via QRCode do Mercado Pago.

## Pré-requisitos
* Docker							
	* O Docker é obrigatório ter instalado na máquina para subir as dependências e rodar o projeto corretamente, caso tenha dúvidas do procedimento consultar a [documentação](https://docs.docker.com/desktop/).
* [Postman](https://www.postman.com/downloads/) (não obrigatório)

## Como rodar localmente
Para rodar o projeto localmente é abrir um terminal na pasta base do projeto e executar o seguinte comando:

```docker-compose up -d```

Sendo executado normalmente, irá subir um banco SQL Server e também a API do projeto, sendo possível utilizar o [swagger](http://localhost:8080/swagger/index.html) para fazer requisições.
Caso prefira, é possível realizar o download da [collection](https://github.com/postech-fiap-4soat-g01/FastFoodTotem/blob/main/FastFoodTotem%20-%20Jornada%20dos%20Usu%C3%A1rios.postman_collection.json) e utilizar no postman.

Link para documentação detalhada [aqui](https://docs.google.com/document/d/1YhRbWbEMPwUHi4J2lIz5dQMwZ6KrRzot/edit?usp=sharing&ouid=109865710704677504404&rtpof=true&sd=true).
