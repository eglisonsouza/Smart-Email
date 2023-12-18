# Smart Email Service

O Smart Email é um serviço dedicado a receber conteúdos de e-mails de uma fila do RabbitMQ e realizar o disparo desses e-mails.

## Visão Geral do Projeto

O sistema foca exclusivamente no envio de e-mails para um serviço SMTP configurável.

## Instruções de Instalação

1. Clone o repositório.
2. Abra o projeto no Visual Studio.
3. Execute o projeto para realizar a instalação automática dos pacotes.
4. Configure o Docker Compose e execute o arquivo docker-compose.

## Requisitos do Sistema

- .NET 8
- RabbitMQ para mensageria

## Como Utilizar o Serviço

O projeto segue uma arquitetura de microservices, onde a API lida com a integração com o banco de dados. Um serviço monitora a fila do RabbitMQ, enviando e-mails conforme necessário.

## Configuração

É necessário configurar:

- RabbitMQ
- Serviço de e-mail SMTP

## Contato

Desenvolvido por Eglison Henrique da Silva de Souza,
LinkedIn: [Eglison Souza](https://www.linkedin.com/in/eglisonsouza/)
