using Xunit;
using Moq;
using FluentAssertions;
using MinhaApp.Domain;
using MinhaApp.Repositories;
using MinhaApp.Services;
using System;

namespace MinhaApp.Tests
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object);
        }

        [Theory]
        [InlineData("Notebook", 2500, 5)]
        [InlineData("Teclado", 150, 20)]
        public void AdicionarProduto_DeveAdicionarProdutoCorretamente(string nome, decimal preco, int estoque)
        {
            _produtoService.Invoking(s => s.AdicionarProduto(nome, preco, estoque))
                .Should().NotThrow();

            _produtoRepositoryMock.Verify(r => r.Add(It.Is<Produto>(p =>
                p.Nome == nome &&
                p.Preco == preco &&
                p.Estoque == estoque)), Times.Once);
        }

        [Fact]
        public void AdicionarProduto_NomeInvalido_DeveLancarExcecao()
        {
            _produtoService.Invoking(s => s.AdicionarProduto("", 100, 10))
                .Should().Throw<ArgumentException>()
                .WithMessage("Nome inválido");
        }

        [Fact]
        public void AdicionarProduto_PrecoInvalido_DeveLancarExcecao()
        {
            _produtoService.Invoking(s => s.AdicionarProduto("Notebook", -10, 5))
                .Should().Throw<ArgumentException>()
                .WithMessage("Preço deve ser maior que zero");
        }
    }
}
