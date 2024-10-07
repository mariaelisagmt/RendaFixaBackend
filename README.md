# RendaFixaBackend

Projeto desenvolvido para realizar investimentos em renda fixa. No qual, o cliente possui uma conta e pode realizar aportes escolhendo um produto de renda fixa.

## Visão Geral

**Desafio proposto pela Toro Investimento para o cargo de Desenvolvedor de Software.**

O projeto foi segmentado em três partes: 
- BACKEND: WebApi
- FRONTEND: Angular 
- BANCO DE DADOS: Sql Server

## Funcionalidades

**User Storie:**
> Eu, como investidor, gostaria de ter acesso a uma lista de 6 ou mais produtos de Renda Fixa, com seus respectivos nomes, preços unitários, taxas e lastro(estoque), para que eu possa comprar. A cada produto escolhido durante a compra desejo informar as quantidades. Além disso, gostaria de ver meu saldo da minha conta Toro. Minhas compras devem respeitar o limite de saldo e lastro do produto, para que assim eu possa adquirir produtos de Renda Fixa com sucesso.Eu, como investidor, gostaria de ter acesso a uma lista de 6 ou mais produtos de Renda Fixa, com seus respectivos nomes, preços unitários, taxas e lastro(estoque), para que eu possa comprar. A cada produto escolhido durante a compra desejo informar as quantidades. Além disso, gostaria de ver meu saldo da minha conta Toro. Minhas compras devem respeitar o limite de saldo e lastro do produto, para que assim eu possa adquirir produtos de Renda Fixa com sucesso.

**Restrições:**

Para efeito de simplificação do desafio, os 6 produtos e a conta Toro com o Saldo podem ser definidos utilizando algum recurso predefinido no backend (uma coleção no banco de dados ou arquivo JSON).

**Critérios de Aceite:**
- A lista de produtos deve vir com a ordenação decrescente do campo taxa (Melhores taxas primeiro).
- Cada produto de Renda Fixa, deve apresentar, nome do ativo, indexador, preço unitário, taxa e botão comprar.
- A cada compra, o estoque do produto deve ser debitado. 
- O saldo da conta Toro deve ser validado. 
- O estoque do Produto deve ser validado. 
- Após a compra, o saldo da conta Toro deve ser debitado .

## Informações Técnicas
**Tecnologias utilizadas:**
- **C#**: Linguagem de Programação
- **.Net Core**: FrameWork multiplataforma.
- **SQL Server **: Banco de dados relacional usado.

**Bibliotecas:**
- **EntityFramework**: ORM utilizado para gerenciar conexão com o banco de dados.
- **MediaR**: Biblioteca para aplicar o padrão mediator.
- **Fluent Assertion**: Biblioteca para validação de testes.
- **Fluent Validation**: Validações das "viewModels".
- **NUnit**: Biblioteca para teste.
- **AutoMapper**: Biblioteca para mapear as "viewModels" para "entidades".

**Boas Práticas:**
- Padrões de Projeto: Respository
- Testes de Unidade;
- CQRS;
- Arquitetura Limpa;
- Código Limpo;
- SOLID;

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

- [.Net](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) (versão 8)
- [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### Configuração do Banco de Dados
:fa-mail-forward: As configurações do banco estão setadas no arquivo appsettings.

## Instalação

1. Clone o repositório:

    ```bash
    git clone https://github.com/mariaelisagmt/RendaFixaBackend.git
    ```

2. Instalar as dependências e bibliotecas

    ```bash
    dotnet add package <PACAGE_NAME>
    ```
3. Configure o servidor de banco de dados conforme o appsettings.

4. Aplicar alterações de banco de dados no console Package Manager:

    ```
    update-database
    ```

## Uso

Inicie o servidor:

```bash
dotnet run
```
