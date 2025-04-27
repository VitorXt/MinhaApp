using MinhaApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MinhaApp.Repositories
{
    public class ProdutoRepositoryInMemory : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new List<Produto>();

        public Produto GetById(Guid id) => _produtos.FirstOrDefault(p => p.Id == id);

        public void Update(Produto produto)
        {
            var index = _produtos.FindIndex(p => p.Id == produto.Id);
            if (index >= 0)
                _produtos[index] = produto;
        }

        public void Add(Produto produto) => _produtos.Add(produto);

        public List<Produto> GetAll() => _produtos;
    }
}
