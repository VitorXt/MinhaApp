namespace MinhaApp.Domain
{
    public class Venda
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Cliente Cliente { get; set; }
        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
        public decimal Desconto { get; set; } = 0;
        public decimal Total => Itens.Sum(i => i.ValorTotal) - Desconto;
    }
}
