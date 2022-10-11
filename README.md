# E-commerce Siteware

# Pré-requisitos

- MySQL
- Visual Studio

# Instalação do projeto

## No console do NuGet Package Manager

Executar o comandos:

```bash
Update-Database -Context ProdutoContext
Update-Database -Context PromocaoContext
Update-Database -Context ItemContext
Update-Database -Context CarrinhoDeComprasContext
```

Esses comando vão rodar os migrations e criar as tables no MySQL

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
| /produtos | post | ProdutosController |
| /produtos/{id} | get | ProdutosController |
| /produtos/{id} | put | ProdutosController |
| /produtos/{id} | delete | ProdutosController |

## Promoção

| Route | Method | Controller |
| --- | --- | --- |
| /promocao | get | PromocaoController |
| /promocao | post | PromocaoController |
| /promocao/{id} | get | PromocaoController |
| /promocao/{id} | put | PromocaoController |
| /promocao/{id} | delete | PromocaoController |

## Item

| Route | Method | Controller |
| --- | --- | --- |
| /item | get | ItemController |
| /item | post | ItemController |
| /item/{id} | get | ItemController |
| /item/{id} | put | ItemController |
| /item/{id} | delete | ItemController |

## Carrinho

| Route | Method | Controller |
| --- | --- | --- |
| /carrinho | get | CarrinhoController |
| /carrinho | post | CarrinhoController |
| /carrinho/{id} | get | CarrinhoController |
| /carrinho/limpar-carrinho | post | CarrinhoController |
| /carrinho/total | delete | CarrinhoController |

# Insomnia

[https://drive.google.com/drive/folders/1pwnftjbIf9FtZn6lhK7pOnrPt6KR6woQ?usp=sharing](https://drive.google.com/drive/folders/1pwnftjbIf9FtZn6lhK7pOnrPt6KR6woQ?usp=sharing)
