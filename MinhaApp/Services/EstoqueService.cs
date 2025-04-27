using MinhaApp.Domain;
using MinhaApp.Repositories;

namespace MinhaApp.Services
{
    public class EstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AtualizarEstoque(Guid produtoId, int novoEstoque)
        {
            var produto = _produtoRepository.GetById(produtoId);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            if (novoEstoque < 0)
                throw new ArgumentException("Estoque não pode ser negativo.");

            produto.Estoque = novoEstoque;
            _produtoRepository.Update(produto);
        }
    }
}
