using MinhaApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MinhaApp.Repositories
{
    public class VendaRepositoryInMemory : IVendaRepository
    {
        private readonly List<Venda> _vendas = new List<Venda>();

        public void Add(Venda venda) => _vendas.Add(venda);

        public Venda GetById(Guid id) => _vendas.FirstOrDefault(v => v.Id == id);
    }
}
