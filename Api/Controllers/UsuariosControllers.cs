using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HttpResponse;
using Microsoft.EntityFrameworkCore;
using Contexts;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosControllers : ControllerBase
    {
        private readonly LojaDbContext _contexto;
        public UsuariosControllers(LojaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> ObterPelaId(Guid id) {
            //Implementação de consulta do usuário
            try{
                var usuarioQueEstaBuscando = await _contexto.Usuarios
                                                .Include(tabelaUsuario => tabelaUsuario.Endereco)
                                                .FirstOrDefaultAsync(tabelaUsuario => tabelaUsuario.Id == id);
                bool usuarioNaoEncontrado = usuarioQueEstaBuscando == null;

                if(usuarioNaoEncontrado){
                    return NotFound();
                }

                return Ok(
                    new UsuarioResponse {
                        Id = usuarioQueEstaBuscando.Id,
                        Nome = usuarioQueEstaBuscando.Nome,
                        Sobrenome = usuarioQueEstaBuscando.Sobrenome,
                        Telefone= usuarioQueEstaBuscando.Telefone,
                        Endereco = new EnderecoResponse
                        {
                            Bairro = usuarioQueEstaBuscando.Endereco.bairro,
                            Rua = usuarioQueEstaBuscando.Endereco.rua,
                            Cep = usuarioQueEstaBuscando.Endereco.cep,
                            Numero = usuarioQueEstaBuscando.Endereco.numero

                        }
                    }
                );
                
            }
            catch(Exception){
                  return StatusCode(500, "Não foi possível realizar a consulta.");
            }
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
