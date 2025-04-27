using MinhaApp.Domain;
using MinhaApp.Repositories;

namespace MinhaApp.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AdicionarProduto(string nome, decimal preco, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido");

            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero");

            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Estoque = estoque
            };

            _produtoRepository.Add(produto);
        }
    }
}
