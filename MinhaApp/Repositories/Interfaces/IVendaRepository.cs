using MinhaApp.Domain;
using System;

namespace MinhaApp.Repositories
{
    public interface IVendaRepository
    {
        void Add(Venda venda);
        Venda GetById(Guid id);
    }
}
