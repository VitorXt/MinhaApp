using MinhaApp.Domain;
using MinhaApp.Repositories;
using System.Collections.Generic;

namespace MinhaApp.Services
{
    public class VendaService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IProdutoRepository produtoRepository, IVendaRepository vendaRepository)
        {
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
        }

        public Venda CriarVenda(Cliente cliente, Dictionary<Guid, int> produtosComQuantidade, decimal desconto)
        {
            if (produtosComQuantidade == null || !produtosComQuantidade.Any())
                throw new ArgumentException("Venda deve conter pelo menos um item.");

            if (cliente == null)
                throw new ArgumentException("Cliente inválido.");

            var venda = new Venda { Cliente = cliente, Desconto = desconto };

            foreach (var item in produtosComQuantidade)
            {
                var produto = _produtoRepository.GetById(item.Key);

                if (produto == null)
                    throw new Exception("Produto não encontrado");

                if (produto.Estoque < item.Value)
                    throw new Exception("Estoque insuficiente para o produto: " + produto.Nome);

                produto.Estoque -= item.Value;
                _produtoRepository.Update(produto);

                venda.Itens.Add(new ItemVenda
                {
                    Produto = produto,
                    Quantidade = item.Value
                });
            }

            _vendaRepository.Add(venda);
            return venda;
        }
    }
}
