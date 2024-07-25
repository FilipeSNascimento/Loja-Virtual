namespace Models.HttpResponse
{   
    public class ProdutoResponse
    {
        public Guid Id {get; set;}
        public required string Nome {get; set;}
        public string Descricao { get; set;}
    }
}