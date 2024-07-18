using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.HttpRequests;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly LojaDbContext database;
        public ContasController(LojaDbContext contexto)
        {
            database = contexto;
        }

        //POST: api/contas/autenticar
        [HttpPost("autenticar")]
        public void Autenticar(CredencialRequest credencial) {

        }

        // POST: api/contas/registrar
        [HttpPost]
        public void Registrar([FromBody] UsuarioRequest usuario) {
        //Implementação de cadastro do usuário

        //Banco = _contexto
        //Tabela = Usuario
        //Add = Operação
        database.Usuarios.Add(usuario);
        }
    }
}