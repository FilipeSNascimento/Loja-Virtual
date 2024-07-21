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
                var buscarUsario = await _contexto.Usuarios
                                                .Include(tabelaUsuario => tabelaUsuario.Endereco)
                                                .FirstOrDefaultAsync(tabelaUsuario => tabelaUsuario.Id == id);
                bool usuarioNaoEncontrado = buscarUsario == null;

                if(usuarioNaoEncontrado){
                    return NotFound();
                }

                return Ok(
                    new UsuarioResponse {
                        Id          = buscarUsario.Id,
                        Nome        = buscarUsario.Nome,
                        Sobrenome   = buscarUsario.Sobrenome,
                        Telefone    = buscarUsario.Telefone,
                        Endereco    = new EnderecoResponse
                        {
                            Cep           = buscarUsario.Endereco.Cep,
                            Rua           = buscarUsario.Endereco.Rua,
                            Bairro        = buscarUsario.Endereco.Bairro,
                            Numero        = buscarUsario.Endereco.Numero,
                            Complemento   = buscarUsario.Endereco.Complemento,
                            Estado        = buscarUsario.Endereco.Estado,
                            Cidade        = buscarUsario.Endereco.Cidade

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
