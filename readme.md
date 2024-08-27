# Projeto .NET Core 5 com Entity Framework

Este reposit�rio cont�m um projeto de console em .NET Core 5 que utiliza o Entity Framework Core para acesso e manipula��o de dados. O objetivo � demonstrar como configurar e usar o Entity Framework Core em uma aplica��o de console .NET5.

## Tecnologias Utilizadas

- **.NET Core 5**
- **Entity Framework Core** para acesso a dados
- **SQL Server** (ou qualquer outro banco de dados suportado)

## Estrutura do Projeto

- **Program.cs**: Ponto de entrada da aplica��o.
- **Models/**: Cont�m as classes de modelo (entidades) utilizadas pelo Entity Framework.
- **Data/**: Cont�m o contexto do banco de dados e configura��es relacionadas.
- **Migrations/**: Cont�m as migra��es do Entity Framework.

## Como Executar

1. **Clone este reposit�rio**:

    ```bash
    git clone https://github.com/seu-usuario/nome-do-repositorio.git
    ```

2. **Navegue at� o diret�rio do projeto**:

    ```bash
    cd nome-do-repositorio
    ```

3. **Restaure as depend�ncias do projeto**:

    ```bash
    dotnet restore
    ```

4. **Crie e aplique as migra��es**:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. **Execute o projeto**:

    ```bash
    dotnet run
    ```

## Funcionalidades Implementadas

- **Configura��o do Entity Framework Core** com o contexto do banco de dados.
- **Cria��o e aplica��o de migra��es** para o banco de dados.
- **Exemplos de opera��es b�sicas utilizando o Entity Framework Core.

## Contribui��es

Este � um projeto de exemplo, ent�o **sugest�es e contribui��es** s�o bem-vindas!

---

