# B3 - Calculadora CDB

Este é um projeto de exemplo que demonstra a integração entre uma API .NET Core e um frontend Angular.

## Executando o Projeto

1 - Clone o repositório para o seu computador:

```bash
    git clone https://github.com/seu-usuario-git/b3-test.git
```

2 - Abra o arquivo de solução B3Test.sln no Visual Studio.

3 - Configure o projeto de inicialização para B3Test.Application.

4 - Pressione F5 ou clique no botão "Iniciar" para executar o projeto. A API será hospedada em https://localhost:7123/swagger.

5 - Abra um prompt de comando e navegue até o diretório ClientApp dentro do projeto B3Test.Application:

```bash
    cd B3Test.Application\ClientApp
```

7 - Ao executar o a solução ambos os projetos executam normalmente.

## Executando Testes de Unidade no Backend

No Visual Studio, vá ao menu "Teste" e selecione "Executar Todos os Testes" para executar os testes de unidade no backend.

## Executando Testes de Unidade no Frontend

1 - Abra um prompt de comando e navegue até o diretório ClientApp dentro do projeto B3Test.Application:

```bash
    cd B3Test.Application\ClientApp
```

2 - Execute o seguinte comando para executar os testes de unidade no frontend:

```bash
    npm test
```

## Documentação da API

#### Calculo de CDB

```http
    GET /api/calculatecdb/calculate?initialValue=${valorInicial}&mounths=${meses}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `initialValue` | `double` | Valor Inicial de Investimento |
| `months` | `int` | Meses de Investimento |

#### Retorna um item

```http
  {
  "rescueValue": 550.78,
  "tax": 10.16,
  "liquidValue": 540.62
}
```
