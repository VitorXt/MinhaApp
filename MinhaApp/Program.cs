using MinhaApp.Domain;
using MinhaApp.Repositories;
using MinhaApp.Services;
using Bogus;

var produtoRepo = new ProdutoRepositoryInMemory();
var vendaRepo = new VendaRepositoryInMemory();

var produtoService = new ProdutoService(produtoRepo);
var vendaService = new VendaService(produtoRepo, vendaRepo);

var faker = new Faker("pt_BR");

// Cria um cliente aleatório
var cliente = new Cliente
{
    Nome = faker.Name.FullName(),
    Email = faker.Internet.Email()
};

// Cria dois produtos aleatórios
produtoService.AdicionarProduto(faker.Commerce.ProductName(), faker.Random.Decimal(100, 5000), faker.Random.Int(5, 20));
produtoService.AdicionarProduto(faker.Commerce.ProductName(), faker.Random.Decimal(100, 5000), faker.Random.Int(5, 20));

// Listar produtos
var produtos = produtoRepo.GetAll();
Console.WriteLine("Produtos disponíveis:");
foreach (var p in produtos)
{
    Console.WriteLine($"{p.Nome} - Preço: {p.Preco:C} - Estoque: {p.Estoque}");
}

// Cria uma venda para o cliente
var venda = vendaService.CriarVenda(cliente, new Dictionary<Guid, int>
{
    { produtos[0].Id, 1 },
    { produtos[1].Id, 2 }
}, desconto: 100);

Console.WriteLine($"\nVenda criada para o cliente {cliente.Nome} com total: {venda.Total:C}");
