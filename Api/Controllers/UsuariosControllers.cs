using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        // POST: api/usuarios
        [HttpPost]
        public void Registrar([FromBody] Usuario usuario) {
            //Implementação de cadastro do usuário
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public void ObterPelaId(Guid id) {
            //Implementação de consulta do usuário
        }

        // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public void AtualizarPelaId(Guid id) {

        }

        //DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public void DeletarPelaId(Guid id) {

        }
    }
}
