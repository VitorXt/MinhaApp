namespace MinhaApp.Domain
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
