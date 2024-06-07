# Contas API

![GitHub repo size](https://img.shields.io/github/repo-size/pbgollo/contas-api?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/pbgollo/contas-api?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/pbgollo/contas-api?style=for-the-badge)

# <img src="imagem.png" alt="Print do Postman">

> Este projeto é uma API RESTful desenvolvida utilizando o framework .NET Core 8 e a linguagem de programação C#. A API permite aos usuários realizar operações de inclusão e listagem de contas a pagar, seguindo as regras de negócio especificadas.

## 🔧 Tecnologias Utilizadas

No projeto, as principais tecnologias adotadas foram o .NET Core 8 e a linguagem de programação C#.

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

## 💻 Pré-requisitos

Antes de começar, verifique se você atende aos seguintes requisitos:

- Você tem uma máquina com o .NET Core SDK instalado
- Você tem um editor de código compatível com o .NET Core, como o Visual Studio ou o Visual Studio Code
- Você tem um banco de dados MySQL configurado e acessível pela aplicação

## 🚀 Instalando a API
Para instalar e configurar a API de Lista de Contas, siga estas etapas:

- Clone este repositório para o seu ambiente local
- Abra o projeto no seu editor de código preferido
- Configure o banco de dados MySQL no arquivo appsettings.json
- Execute os seguintes comandos no terminal do projeto para aplicar as migrações e atualizar o banco de dados:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Após configurar o projeto, você pode executá-lo para iniciar a API, utilizando o seguinte comando:
```
dotnet run
```

## 🤝 Colaboradores

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/pbgollo" title="Perfil do Pedro Gollo no GitHub">
        <img src="https://avatars.githubusercontent.com/u/130512644" width="100px;" alt="Foto do Pedro Gollo no GitHub"/><br>
        <sub>
          <b>Pedro Gollo</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
