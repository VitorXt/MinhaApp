using MinhaApp.Domain;
using System;
using System.Collections.Generic;

namespace MinhaApp.Repositories
{
    public interface IProdutoRepository
    {
        Produto GetById(Guid id);
        void Update(Produto produto);
        void Add(Produto produto);
        List<Produto> GetAll();
    }
}
