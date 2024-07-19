
namespace Models.HttpRequests
{
    public class EnderecoRequest
    {
        public required string Rua { get; set; }
        public required string Bairro { get; set; }
        public required string Numero { get; set; }
        public required string Cep { get; set; }
    }
    // public class Credencial
    // {
    //     public required string Email { get; set; }
    //     public required string Senha { get; set; }
    // }
    public class UsuarioRequest
    {
        public required string Nome { get; set; }

        public required string Sobrenome { get; set; }

        public required string Telefone { get; set; }

        public required Endereco Endereco { get; set; }
        public required Credencial Credencial { get; set; }
    }
}