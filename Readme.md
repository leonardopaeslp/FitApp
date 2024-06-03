
# FitApp

FitApp é uma API em desenvolvimento com .NET 8 e Entity Framework Core que gerencia exercícios físicos de usuários.


## Autores

- [@leonardopaeslp](https://github.com/leonardopaeslp)


## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- JWT (JSON Web Tokens) para autenticação

## Requisitos

- .NET 8 SDK
- SQL Server
- Visual Studio ou Visual Studio Code
## Configuração do Projeto

Clonar o Repositório

```bash
git clone https://github.com/leonardopaeslp/FitApp.git
cd WebApiExercicio

```
Configurar a String de Conexão
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
  },
  "Jwt": {
    "Key": "your_secret_key",
    "Issuer": "your_issuer",
    "Audience": "your_audience"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Executar Migrações e Atualizar o Banco de Dados
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Executar o Projeto
```bash
dotnet run
```
    