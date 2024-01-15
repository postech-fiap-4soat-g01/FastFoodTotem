[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

# FIAP: Pós Tech - Software Architecture

[![FIAP Pós Tech](https://postech.fiap.com.br/imgs/imgshare.png)](https://postech.fiap.com.br/?gad_source=1&gclid=Cj0KCQjwhfipBhCqARIsAH9msbmkyFZTmYIBomPCo-sGkBPLiiZYAkvTmM1Kx-QjwmYs3_NhyPKvP44aAtdZEALw_wcB)

## Objetivo do projeto
Este projeto foi realizado como parte de um entregável para o curso 'Pós Tech - Software Architecture'.
O desafio proposto da fase 1 é realizar um projeto (MVP) monolito utilizando a arquitetura hexagonal para atender as necessidades de um autoatendimento de um fast food.
O desafio proposto da fase 2 é adicionar clean code no projeto e trabalhar com o k8s, usando escalabilidade.


Funcionalidades:
* Gerenciamento de produtos.
* Gerencimento de clientes.
* Realizar um pedido e acompanhar.
* Pagamento via QRCode do Mercado Pago.

## Pré-requisitos
* K8s							
	* O K8s é obrigatório ter instalado na máquina para subir o projeto e possíveis serviços adjacentes, para isso é recomendado utilizar o docker e habilitar o Kubernets nele, porém para isso ter várias outras maneiras de chegar no mesmo resultado, caso prefira consultar a [documentação](https://docs.docker.com/desktop/kubernetes/).
	* Recomendado criar um namespace próprio para o projeto.
* [Postman](https://www.postman.com/downloads/) (não obrigatório)

## Como rodar localmente
Para rodar o projeto localmente necessita abrir um terminal na pasta base, entrar na pasta k8s executar os seguintes comando:

Caso tenha seguido pela instalação do k8s junto com o docker desktop é possível utilizar o contexto dele da seguinte forma:
```kubectl config get-contexts```
```kubectl config use-context docker-desktop```

Para criar um namespace para o projeto e configurar como default:
```kubectl create -f ./namespace.yaml```
```kubectl config set-context --current --namespace fast-food-totem```

Para criar a secret do banco, seu deployment e o service para disponibilizar a porta somente dentro do cluster:
```kubectl create -f ./db-secret.yaml```
```kubectl create -f ./db-deployment.yaml```
```kubectl create -f ./db-service.yaml```

Por fim para subir a API, juntamente com seu secret, deployment, service para conectar externo e seu HPA, para escalar:
```kubectl create -f ./api-secret.yaml```
```kubectl create -f ./api-deployment.yaml```
```kubectl create -f ./api-service.yaml```

Para subir o HPA é necessário primeiro habilitar um metric server, para isso consultar a documentação do [k8s](https://github.com/kubernetes-sigs/metrics-server)
O comando utilizado para criar foi

```kubectl apply -f https://github.com/kubernetes-sigs/metrics-server/releases/latest/download/components.yaml```

Caso necessário desabilitar a validação de certificado, para isso é ncessário editar o deployment do metrics-server no namespace kube-system passando o seguinte comando no containers args:
```--kubelet-insecure-tls```

Após o metric server estar funcionando, só subir o HPA da aplicação.
```kubectl create -f ./api-hpa.yaml```

Sendo executado normalmente, irá subir um banco SQL Server e também a API do projeto, sendo possível utilizar o [swagger](http://localhost:8080/swagger/index.html) para fazer requisições.
Caso prefira, é possível realizar o download da [collection](https://github.com/postech-fiap-4soat-g01/FastFoodTotem/blob/main/FastFoodTotem%20-%20Jornada%20dos%20Usu%C3%A1rios.postman_collection.json) e utilizar no postman.

Link para documentação detalhada [aqui](https://docs.google.com/document/d/1YhRbWbEMPwUHi4J2lIz5dQMwZ6KrRzot/edit?usp=sharing&ouid=109865710704677504404&rtpof=true&sd=true).

## Subindo uma tag nova a imagem
Caso seja necessário entrar no root do projeto e rodar os seguintes comandos:

Necessário para realizar o build da imagem:
```docker build -t {user_docker_hub}/fast-food-totem:latest -t {user_docker_hub}/fast-food-totem:{tag} .```

Necessário para subir as alterações:
```docker push {user_docker_hub}/fast-food-totem:{tag}```
```docker push {user_docker_hub}/fast-food-totem:latest```

OBS: Subir a tag latest também

## K6 para validação do HPA
É possível rodar o k6 para realizar um load test e validar se o HPA está funcional, para isso entrar na pasta stress e rodar o seguinte comando:

```k6 run index.js```