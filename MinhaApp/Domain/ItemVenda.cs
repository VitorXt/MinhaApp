namespace MinhaApp.Domain
{
    public class ItemVenda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal => Produto.Preco * Quantidade;
    }
}
