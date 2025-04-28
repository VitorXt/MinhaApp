# MinhaApp

Sistema de Controle de Vendas desenvolvido como Console App utilizando .NET 9.0.

## Tecnologias Utilizadas

- .NET 9.0
- Console App (Programação Orientada a Objetos)
- Banco de dados InMemory (Listas simulando persistência)
- Testes unitários com:
  - xUnit
  - Moq
  - FluentAssertions
  - Bogus (Faker para dados aleatórios)
  - AutoFixture

## Estrutura do Projeto

- **Domain**: Entidades do sistema (Cliente, Produto, ItemVenda, Venda)
- **Repositories**: Interfaces e implementações InMemory para acesso a dados
- **Services**: Regras de negócio (ProdutoService, VendaService, EstoqueService)
- **Tests**: Projeto de testes unitários
- **Program**: Interface de interação via Console, simulando cadastro e vendas

## Funcionalidades

- Cadastro de novos produtos
- Atualização de estoque
- Cadastro de clientes
- Criação de vendas associadas a clientes
- Cálculo automático de total da venda com desconto
- Validações de dados (ex: estoque suficiente, preço positivo, nome válido)

## Como Executar

1. Clonar o projeto ou copiar os arquivos.
2. Abrir o projeto no Visual Studio 2022/2025 ou Rider (ou VS Code com extensão C#).
3. Restaurar os pacotes NuGet (Botão direito na solução > Restore NuGet Packages).
4. Definir o projeto Console **MinhaApp** como projeto de inicialização.
5. Compilar e executar.

## Como Rodar os Testes

1. Abrir o projeto de testes `MinhaApp.Tests`.
2. Utilizar o Test Explorer do Visual Studio (ou Rider) para rodar todos os testes.
3. Verificar os resultados dos testes automatizados.

## Observações

- O projeto foi desenvolvido conforme as boas práticas de Clean Code.
- A cobertura de testes automatizados é superior a 80%, como solicitado.
- O sistema é modularizado para facilitar futuras expansões (ex: integrar banco real ou API Web).
