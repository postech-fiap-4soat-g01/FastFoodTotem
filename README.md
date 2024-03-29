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
* [AWS Cloud](https://aws.amazon.com/)							
	* É necessário ter uma conta na AWS para subir a infraestrutura necessária para o projeto.
* [Terraform](https://www.terraform.io/)
	* Para subir a infraesturura mantida no repositório: [Repositório Terraform](https://github.com/postech-fiap-4soat-g01/aws-infrastructure-live)
* [K9s](https://k9scli.io/) - Não obrigatório porém aconselhado por ser mais intuitivo.
* [Postman](https://www.postman.com/downloads/) - Não obrigatório.

## Github Actions
### Necessário
* Configurar no GitHub as *Secrets and variables*, entrando em *Actions* e adicionando na parte *Repository secrets* a seguinte:
  * AWS_ACCESS_KEY_ID 
  * AWS_SECRET_ACCESS_KEY
* Rodar a primeira run no [Repositório Terraform](https://github.com/postech-fiap-4soat-g01/aws-infrastructure-live), para criação do ECR e RDS do SQL
* Após criado, necessário atualizar o arquivo api-secret.yaml dentro da pasta k8s, alterando a *ConnectionStrings__SqlServerConnection* para qual foi criada o RDS.

Esse projeto tem um workflow ao realizar o merge para a branch main preparado para subir a imagem ao ECR e realizar o deploy ao EKS, ambos sendo criados anteriormente na RUN 1: [Repositório Terraform](https://github.com/postech-fiap-4soat-g01/aws-infrastructure-live).

Fluxo:
* RUN 1 do terraform
* Alterar *ConnectionStrings__SqlServerConnection* no arquivo [api-secret](https://github.com/postech-fiap-4soat-g01/FastFoodTotem/blob/main/k8s/api-secret.yaml) de acordo com o RDS criado pelo Terraform
* Alterar o endereço do ECR no arquivo [api-deployment](https://github.com/postech-fiap-4soat-g01/FastFoodTotem/blob/main/k8s/api-deployment.yaml) de acordo com o *ecr-fast_food_totem* criado pelo Terraform
* Workflow para subir a imagem no ECR e deploy no EKS

Links úteis:
* [Documentação detalhada](https://docs.google.com/document/d/1YhRbWbEMPwUHi4J2lIz5dQMwZ6KrRzot/edit?usp=sharing&ouid=109865710704677504404&rtpof=true&sd=true).

## Arquitetura do projeto
O projeto foi desenvolvido utilizando o .NET 6, tendo como SGBD o Sql Server e utilizando a Clean Architecture, conforme foi solicitado.

Diagrama de arquitetura do projeto:

![Arquitetura Projeto](./images/CleanArchitetureImage.png)

Observando o desenho da arquitetura utilizada, é possível diferenciar o projeto em 3 camadas: Presentation, Core e Infrastructure.

O Core é a parte central do projeto, existe para isolar as regras de negócio da aplicação e garantir o funcionamento da mesma independente das integrações utilizadas. O core não depende de nenhuma outra camada da aplicação. No core de nossa API, implementamos duas Libraries, Application e Domain.

A camada Application é responsável por trabalhar com todos os DTO’s da API, trafegar os dados entre a API e o Domain, validar os dados de entrada e implementar as regras do negócio com UseCases. 

A camada de Domain é responsável por mapear todas as entidades do negócio. Essa camada também faz o mapeamento dos contratos(interfaces) utilizados para chamar operações de outras camadas, mas não faz a implementação desses contratos, tendo em vista que isso é de responsabilidade das camadas específicas que seguirão esses contratos. É importante ressaltar que essa camada não depende de nenhuma outra, e a camada Application depende apenas da camada Domain. Com essa dependência, a camada Application consegue se integrar com outras camadas através das interfaces implementadas na camada Domain.

A camada de Infrastructure pode ser subdividida em três subcamadas no nosso projeto: SqlServer(integração com sgbd, execução de queries), MercadoPago(integração para gerar QR code e fazer fake checkout) e IoC(injeção de dependências). Nessa camada, são implementados alguns dos contratos especificados na camada Domain. Utilizando os contratos(interfaces) e a injeção de dependências, conseguimos isolar o funcionamento de cada um dos pacotes na infrastructure sem a necessidade do Core ter qualquer dependência deles.

A camada Presentation é responsável por controlar as requisições externas ao domínio e encaminhá-las ao mesmo. Nossa aplicação possui apenas uma camada de apresentação, que é nossa Api.

É possível perceber pela imagem da arquitetura utilizada que ela está um pouco diferente da imagem tradicional da Clean Architecture, mas deixamos dessa forma para tentar deixar mais explicito como que ocorrem as comunicações entre as camadas. As dependências entres os projetos foram desenvolvidas de acordo com a Clean Architecture, que é o mais importante.

## Arquitetura Cloud
A seguinte seção tem por objetivo explicar como arquitetamos a infra do produto.

### Diagrama da arquitetura
![Arquitetura Kubernetes](./images/Fase3_ArquiteturaAtual.png)

Caso prefira, é possível realizar o download da [collection](https://github.com/postech-fiap-4soat-g01/FastFoodTotem/blob/main/FastFoodTotem%20-%20Jornada%20dos%20Usu%C3%A1rios.postman_collection.json) e utilizar no postman.

## K6 para validação do HPA
É possível rodar o k6 para realizar um load test e validar se o HPA está funcional, para isso ***entrar na pasta stress*** e rodar o seguinte comando:
```Batchfile
k6 run index.js
```

## Swagger

A API é dividida se baseando em 2 entidades básicas: Order(Pedidos) e Product(Produtos). Nos endpoints da aplicação não é diferente. Os 2 contextos principais são:

### Contexto Product

![swagger3](./images/swagger3.png)

O contexto de Product(produto) é utilizado para gerenciar os produtos que ficam disponíveis para a clientela da lanchonete. Esse contexto possui as 4 operações básicas, POST, DELETE, PUT e GET. O GET foi desenvolvido utilizando um filtro por tipo de produto, dessa forma fica fácil utilizar esse endpoint em uma tela que tem o foco de exibir os produtos de apenas um determinado tipo.

### Contexto Order

![swagger4](./images/swagger4.png)

O contexto Order(pedido) é utilizado para gerenciar os pedidos realizados pelos clientes da lanchonete. É possível criar um pedido utilizando o primeiro POST, dessa forma o usuário consegue informar os dados do pedido e chamar esse endpoint para registrar um pedido.

O endpoint PATCH é utilizado unicamente para atualizar os status dos pedidos, dessa forma a equipe da lanchonete pode atualizar os status dos pedidos sempre que necessário. Possíveis status:

1. Aguardando pagamento
2. Recebido
3. Em preparação
4. Pronto
5. Finalizado

Esse contexto possui 5 GET's distintos. O primeiro GET é utilizado para obter todos os pedidos. O segundo GET é utilizado para obter os dados de um pedido específico, informando seu ID, que pode ser utilizado pela cozinha para visualizar os dados dos pedidos para realizar o preparo de acordo com o que foi solicitado pelos clientes. O terceiro GET é utilizado para obter todos os pedidos que estão em um status específico, que pode ser utilizado para a cozinha para visualizar todos os pedidos que estão aguardando o preparo, ou seja, no status “Recebido”. O quarto GET é utilizado para visualizar todos os pedidos que estão pendentes, ou seja, não estão nos status “Aguardando Pagamento” e nem “Finalizado”. Esse endpoint será utilizado pelos clientes para visualizar os pedidos que já foram pagos e não foram finalizados, para que consigam acompanhar o andamento dos pedidos. O último GET é utilizado para visualizar o status de pagamento dos pedidos realizados, sendo possível retorno de “Aguardando Pagamento”, “Pago” e “Pagamento rejeitado”.

O último POST se refere ao recebimento de webhook do Mercado Pago mediante ao pagamento do QRCode.

### Collection do postman
Foi desenvolvida uma collection para testar o projeto inteiro via postman, ela se encontra na pasta raiz do repositório. A collection se chama “FastFoodTotem - Jornada dos Usuários.postman_collection”. Lembrando que para usá-la corretamente, será necessário ter a ifnra inteira do produto sendo executada na nuvem, não é uma collection apenas para o projeto deste repositório.

A collection  “FastFoodTotem - Jornada dos Usuários.postman_collection” visa simular os passos que o cliente e que a lanchonete podem utilizar desde o cadastro do cliente até a finalização do pedido. Nessa collection, nem todos os endpoints são utilizados, e ela será detalhada a seguir.

Essa collection possui os seguintes passos, subdivididos em dois grupos, jornada do cliente, e jornada da lanchonete:

![collections](./images/collections.png)

Jornada do cliente:
1. O primeiro passo feito pelo cliente pode ser o cadastro, o acesso anônimo ou o login. O primeiro endpoint utilizado nessa etapa é o de realizar cadastro do cliente. O login é feito apenas acessando um endpoint onde o cpf do cliente é informado ou utilizando o endpoint para ser autenticado de forma anônima. É importante que seja autenticado de forma anônima ou com cpf, pois esses endpoints geram um token de acesso aos endpoints posteriores. Após obter esse token, basta apenas colocar como um header chamado "Authorization" no request da requisição, ou utilizar a aba correta do postman para isso.
2. Após ter o cadastro/login realizado, o cliente começa a montar seu pedido. Para montar seu pedido, ele precisa escolher o burguer, o acompanhamento e a bebida. Para isso, são executados 3 endpoints em ordem para exibir os dados necessários e o cliente selecionar o que deseja. 
3. Após o cliente selecionar cada um dos itens de seu pedido, nada é feito. O pedido só é enviado para a API após o cliente selecionar sua bebida, que é o último item que pode ser escolhido. O pedido é enviado pelo request “5 - Envio pedido”. Lembrando que, caso seja acessado com usuário, os campos "userCpf" e "userName" devem ser preenchidos, caso seja autenticado de forma anônima, basta apenas enviar o "userName" para identificação do cliente para o mesmo retirar o pedido sendo chamado pelo nome.
4. Após o pedido ser cadastrado no sistema, a API retorna o Id do pedido, a sequência de caracteres utilizados para montar o QR Code do mercado pago, o status do pedido(que inicialmente é “Aguardando pagamento”) e o preço total. O cliente consegue realizar o pagamento com o QR Code do Mercado Pago. Essa integração está funcionando, a chave pode ser utilizada em algum aplicativo bancário, mas pedimos para que não finalize o pagamento.
5. Para simular o pagamento realizado, criamos a etapa “6 - Fake Checkout”, que é um endpoint para recebimento do webhook após o pagamento do QRCode, onde é realizada a alteração de status do pedido para o “2 - Recebido”. Dessa forma fica simulado que o pedido foi pago.
6. O request “7 - Visualizar pedidos pendentes” será utilizado para exibir os pedidos pendentes para os clientes poderem acompanhar os status de seus pedidos.

Jornada da lanchonete:

1. O primeiro endpoint acessado pela lanchonete é o de visualizar todos os pedidos que foram pagos, ou seja, estão no status “Recebido”.
2. O segundo endpoint acessado pela lanchonete é o de visualizar os dados do pedido, para que a lanchonete saiba o que o cliente solicitou.
3. Os endpoints restantes são apenas para a lanchonete modificar os status dos pedidos, levando-os até o status final “Finalizado”.

Observe que nessas jornadas básicas não há a utilização dos endpoints do contexto Product, pois não são necessários para o gerenciamento de um pedido desde a sua criação até sua finalização. Os endpoints do contexto Product são necessários para a lanchonete gerenciar os produtos disponíveis e seus preços. Para facilitar a utilização da API, alguns dados de produtos são inseridos na base de dados quando a aplicação é “startada”. Dessa forma não será necessário se preocupar em cadastrar os produtos antes de utilizar os endpoints de criação e gerenciamento de pedidos simulando um cliente da lanchonete.

Lembrando que, para usar essa collection, é necessário mudar a variável "{{base_url}}" da collection no postman. A url base sempre muda quando subimos um api gateway diferente, pois não especificamos um domínio para ela. Após subir o projeto com terraform e git actions, pegue a url_base no stage do api gateway da aws e substitua nessa variável._

Além dessa collection, foi desenvolvida uma outra collection que possui todos os endpoints para serem acessados de forma livre, ela se chama "FastFoodTotem - Complete Api".


As url's para os outros repositórios do projeto são:

Terraform: https://github.com/postech-fiap-4soat-g01/aws-infrastructure-live

Lambda Function Autenticação usuário: https://github.com/postech-fiap-4soat-g01/FastFoodUserManagement
