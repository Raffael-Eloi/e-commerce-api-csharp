# E-commerce Siteware

# Pré-requisitos

- MySQL
- Visual Studio

# Instalação do projeto

## No console do NuGet Package Manager

Executar o comando `Update-Database` 

Esse comando vai rodar os migrations e criar as tables no MySQL

# Pacotes instalados

| Pacote | Versão |
| --- | --- |
| Microsoft.EntityFrameworkCore | 5.0.5 |
| Microsoft.EntityFrameworkCore.Tools | 5.0.5 |
| MySql.Entity.FrameworkCore | 5.0.3 |
| AutoMapper.Extensions.Microsoft.DepencyInjection |  8.1.1 |

# Routes

prefix: `localhost:5000/api`

## Produtos

| Route | Method | Controller |
| --- | --- | --- |
| /produtos | get | ProdutosController |
| /produtos/{id} | get | ProdutosController |
| /produtos | post | ProdutosController |
| /produtos/{id} | put | ProdutosController |
| /produtos/{id} | delete | ProdutosController |

## Carrinho

| Route | Method | Controller |
| --- | --- | --- |
| /carrinho/todos | get | CarrinhoController |
| /carrinho/novo | post | CarrinhoController |
| /carrinho/excluir/{id} | delete | CarrinhoController |
| /carrinho/limpar-carrinho | post | CarrinhoController |
| /carrinho/total | get | CarrinhoController |

# Insomnia

Aqui vai ficar um arquivo do insomnia
