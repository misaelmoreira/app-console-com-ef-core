# Projeto .NET Core 5 com Entity Framework

Este repositório contém um projeto de console em .NET Core 5 que utiliza o Entity Framework Core para acesso e manipulação de dados. O objetivo é demonstrar como configurar e usar o Entity Framework Core em uma aplicação de console .NET5.

## Tecnologias Utilizadas

- **.NET Core 5**
- **Entity Framework Core** para acesso a dados
- **SQL Server** (ou qualquer outro banco de dados suportado)

## Estrutura do Projeto

- **Program.cs**: Ponto de entrada da aplicação.
- **Models/**: Contém as classes de modelo (entidades) utilizadas pelo Entity Framework.
- **Data/**: Contém o contexto do banco de dados e configurações relacionadas.
- **Migrations/**: Contém as migrações do Entity Framework.

## Como Executar

1. **Clone este repositório**:

    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. **Navegue até o diretório do projeto**:

    ```bash
    cd nome-do-repositorio
    ```

3. **Restaure as dependências do projeto**:

    ```bash
    dotnet restore
    ```

4. **Crie e aplique as migrações**:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. **Execute o projeto**:

    ```bash
    dotnet run
    ```

## Funcionalidades Implementadas

- **Configuração do Entity Framework Core** com o contexto do banco de dados.
- **Criação e aplicação de migrações** para o banco de dados.
- **Exemplos de operações básicas utilizando o Entity Framework Core.

## Contribuições

Este é um projeto de exemplo, então **sugestões e contribuições** são bem-vindas!

---

