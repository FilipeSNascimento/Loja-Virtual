namespace Models.HttpRequests
{   
    public class ProdutoRequest
    {
        public Guid Id {get; set;}
        public required string Nome {get; set;}
        public string Descricao { get; set;}
    }
}