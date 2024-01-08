# [FIAP - Pos Tech] Fast Food - Pagamento API

FIAP Pos Tech - SOFTWARE ARCHITECTURE

SOAP2 - Grupo 7

#### Sumário
   * [O projeto](#o-projeto)
   * [Documentações](#documentações)
   * [Pré-requisitos](#pré-requisitos)
   * [Como rodar a aplicação <g-emoji class="g-emoji" alias="arrow_forward" fallback-src="https://github.githubassets.com/images/icons/emoji/unicode/25b6.png">▶️</g-emoji>](#como-rodar-a-aplicação-️)
   * [Tecnologias](#tecnologias)
   * [Arquitetura e Padrões](#arquitetura-e-padrões)
   * [Estrutura da solução](#estrutura-da-solução)
   * [Desenvolvedores <img class="emoji" title=":octocat:" alt=":octocat:" src="https://github.githubassets.com/images/icons/emoji/octocat.png" height="20" width="20" align="absmiddle">](#desenvolvedores-octocat)

## O projeto

O projeto consiste em um microservico responsável por gerar a cobrança de um pedido gerado anteriormente, parte de um sistema de autoatendimento de fastfood.

No projeto atual temos as seguintes funcionalidades:
- Criar um pagamento
- Webhook para recebimento da confirmação do pagamento
- Consultar situação do pagamento

## Banco de dados
Como o serviço de pagamento envolve transações financeiras, é crucial garantir a integridade e consistência dos dados, o sistema utiliza o banco de dados PostgreSQL.

## Pré-requisitos

- SDK do .NET 7.0: Baixe em https://dotnet.microsoft.com/pt-br/download/dotnet/7.0.
- Docker: https://docs.docker.com/engine/install/

- IDE de sua preferência: pode ser executado com o Visual Studio Code (Windows, Linux or MacOS).


## Como rodar a aplicação localmente ▶️

1. Suba os containers (aplicação e banco de dados) utilizando o docker compose

   `docker-compose up -d`

2. Teste o sistema através do swagger:

   http://localhost:8000/swagger/index.html

## Tecnologias

- Runtime do .NET 7.0.5
    - Suporte para o Visual Studio
        - Visual Studio 2022 (v17.6)
        - Visual Studio 2022 for Mac (v17.6)
    - C# 11.0
    - ASP.NET WebApi
    - Entity Framework
    - AutoMapper
    - Swagger UI
- PostgreSQL 
- Docker

## Arquitetura e Padrões

![Arquitetura](./docs/CleanArchitecture.png)

- Arquitetura Limpa (Clean Architecture)
- Domain Driven Design (DDD)
- Domain Events
- CQRS
- Unit of Work
- Repository

## Estrutura da solução

![Projeto](./docs/Projeto.png) 


## Desenvolvedores :octocat:

| [<img src="https://avatars.githubusercontent.com/u/62022498?v=4" width=115><br><sub>Wellerson Willon Reis</sub>](https://github.com/brwillon) | [<img src="https://avatars.githubusercontent.com/u/15663232?v=4" width=115><br><sub>Ana Luisa Bavati</sub>](https://github.com/analuisabavati) |  [<img src="https://avatars.githubusercontent.com/u/67171626?v=4" width=115><br><sub>Luis Fernando</sub>](https://github.com/luisfernandodass) | [<img src="https://avatars.githubusercontent.com/u/26546830?v=4" width=115><br><sub>Gabriel Belloni</sub>](https://github.com/belloniz) |
| :---: | :---: | :---: | :---:
