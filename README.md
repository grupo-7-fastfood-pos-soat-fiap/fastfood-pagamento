# [FIAP - Pos Tech] Fast Food - Pagamento API

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
- Consultar situação do pagamento
- Webhook de confirmação ou recusa de um pagamento 

## Banco de dados
Como o serviço de pagamento envolve transações financeiras, é crucial garantir a integridade e consistência dos dados, o sistema utiliza o banco de dados PostgreSQL.


## Tecnologias

- Runtime do .NET 6
    - C# 11.0
    - ASP.NET WebApi
    - Entity Framework
    - AutoMapper
    - Swagger UI
    - Moq
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
