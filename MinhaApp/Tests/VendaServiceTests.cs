using Xunit;
using Moq;
using FluentAssertions;
using MinhaApp.Domain;
using MinhaApp.Repositories;
using MinhaApp.Services;
using System;
using System.Collections.Generic;

namespace MinhaApp.Tests
{
    public class VendaServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<IVendaRepository> _vendaRepositoryMock;
        private readonly VendaService _vendaService;

        public VendaServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _vendaRepositoryMock = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_produtoRepositoryMock.Object, _vendaRepositoryMock.Object);
        }

        [Fact]
        public void CriarVenda_DeveCriarVendaCorretamente()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "Mouse", Preco = 100, Estoque = 5 };
            _produtoRepositoryMock.Setup(r => r.GetById(produto.Id)).Returns(produto);

            var venda = _vendaService.CriarVenda(new Dictionary<Guid, int> { { produto.Id, 2 } }, 20);

            venda.Should().NotBeNull();
            venda.Itens.Should().HaveCount(1);
            venda.Total.Should().Be((100 * 2) - 20);

            _vendaRepositoryMock.Verify(v => v.Add(It.IsAny<Venda>()), Times.Once);
            _produtoRepositoryMock.Verify(p => p.Update(It.Is<Produto>(x => x.Estoque == 3)), Times.Once);
        }

        [Fact]
        public void CriarVenda_EstoqueInsuficiente_DeveLancarExcecao()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "Teclado", Preco = 150, Estoque = 1 };
            _produtoRepositoryMock.Setup(r => r.GetById(produto.Id)).Returns(produto);

            _vendaService.Invoking(v => v.CriarVenda(new Dictionary<Guid, int> { { produto.Id, 2 } }, 0))
                .Should().Throw<Exception>()
                .WithMessage("Estoque insuficiente para o produto: Teclado");
        }

        [Fact]
        public void CriarVenda_ProdutoNaoEncontrado_DeveLancarExcecao()
        {
            _produtoRepositoryMock.Setup(r => r.GetById(It.IsAny<Guid>())).Returns((Produto)null);

            _vendaService.Invoking(v => v.CriarVenda(new Dictionary<Guid, int> { { Guid.NewGuid(), 1 } }, 0))
                .Should().Throw<Exception>()
                .WithMessage("Produto não encontrado");
        }
    }
}
