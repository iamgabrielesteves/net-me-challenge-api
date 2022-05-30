# net-me-challenge-api

Projeto de API com .NET Core 6

## Sobre o projeto

O proposito desse projeto é criar pedidos ("Orders") com alguns produtos já pre cadastrados na tabela ("Products").

Após a criação das orders você pode alterar os dados de `itensAprovados` e `valorAprovado`
que resultará em mudança de status da order.

```
public enum OrderStatus
{
    APROVADO = 1,
    APROVADO_VALOR_A_MENOR = 2,
    APROVADO_VALOR_A_MAIOR = 3,
    APROVADO_QTD_A_MAIOR = 4,
    APROVADO_QTD_A_MENOR = 5,
    REPROVADO = 6,
    CODIGO_PEDIDO_INVALIDO = 7
}
```

## Base de dados

Para simplificar o uso do projeto foi utilizado Ef Core 6 com Migrations em cima de uma banco Postgres.

`As migration são executadas junto com o projeto.`

![postgres image](https://github.com/gabrielesteveslima/net-me-challenge-api/blob/master/docs/postgres.PNG)

** Por padrão foram criados somente alguns Products para teste

## Estrutura do projeto

A solução possui alguns projetos, separando uma intenção de camada de dominio, digo intenção porque visto que é somente
para aprendizado e o projeto não possui alta complexidade de negocio.

Camadas de aplicação e infraestrutura e uma camada compartilhada chamada `SeedWorks`.

![project tree image](https://github.com/gabrielesteveslima/net-me-challenge-api/blob/master/docs/project-tree.PNG)

* As regras de negocios + contratos de infraestrutura estão na Camada de Dominio (evitando classes anemicas (somentes entidades com Get e Sets sem logicas))
* Dentro do Application estão a Orquestração entre Domain, Infra e UI (no caso uma API.. mas poderia ser uma console etc)
* Validações feitas com o FluentValidation para os Commands no seguinte padrão:

````
{
  "errors": [
    {
      "title": "Items[0].Qtd",
      "description": "'Qtd' must not be empty.",
      "code": 64257825,
      "type": "Error"
    }
  ],
  "type": "InvalidCommandRuleValidationExceptionProblemDetails",
  "status": 400
}

````

## Docker

Para simplificar o teste da solução criei os arquivos do containers do docker, junto com o docker-compose, portanto para
rodar a solução basta:

``` bash
docker-compose up -d --build --force-recreate
```

Feito isso o docker vai levantar os serviços configurados sendo eles:

* O banco de dados postgres; e
* A aplicação web api;

![docker running image](https://github.com/gabrielesteveslima/net-me-challenge-api/blob/master/docs/docker-running.PNG)


Assim temos os serviços de API e o banco rodando nas portas http/8080 e tcp/5432 respectivamente.

** Caso o container ``mechallenge-api`` apresente erro de comunicação com o banco você pode iniciar ele manualmente;

## Swagger
Pode ser acessado via: http://localhost:8080/swagger/index.html

## API

A api está rodando com o ```Microsoft.AspNetCore.Mvc.Versioning``` uma lib para versionamento de recursos.

Insira: `api-version = 1`

### GET api/products

Listagem de produtos

response:

```
[
  {
    "produto": "05077f8d-a577-47d6-9c92-6714332950e4",
    "nome": "Shorts",
    "descricao": "Lorem Ipsum",
    "precoUnitario": 95
  },
  {
    "produto": "09d92788-b384-4e6d-bce2-fcb9cf1928e9",
    "nome": "Glasses",
    "descricao": "Lorem Ipsum",
    "precoUnitario": 250
  },
]
```

### POST api/orders

Criação de pedidos

request:

```
{
  "itens": [
    {
      "produto": "05077f8d-a577-47d6-9c92-6714332950e4",
      "qtd": 20,
    }
  ]
}
```

response body:

````
{
  "pedido": "28dfd86c-b943-4da3-a521-f639a8cb4063",
  "itens": [
    {
      "produto": "05077f8d-a577-47d6-9c92-6714332950e4",
      "qtd": 20,
      "precoUnitario": 95
    }
  ]
}
````

### GET api/orders/{orderId}

Listagem de pedidos

response:

```
{
  "pedido": "28dfd86c-b943-4da3-a521-f639a8cb4063",
  "itens": [
    {
      "qtd": 20,
      "descricao": "Lorem Ipsum",
      "precoUnitario": 95
    }
  ]
}
```

### POST api/status

Alteração de status

request:

```
{
  "pedido": "182d151e-db1f-45df-a701-cf84e0f476b6",
  "itensAprovados": 6,
  "valorAprovado": 10
}
```

response:

```
{
  "pedido": "182d151e-db1f-45df-a701-cf84e0f476b6",
  "status": "APROVADO_QTD_A_MENOR"
}
```

É isso! Obrigado pela atenção.
