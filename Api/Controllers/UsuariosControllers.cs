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
        [HttpGet("{idusuarioProcurado}")]
        public async Task<ActionResult<UsuarioResponse>> ObterPelaId(Guid idusuarioProcurado) {
            //Implementação de consulta do usuário
            try{
                var usuarioProcurado = await _contexto.Usuarios
                                                .Include(tabelaUsuario => tabelaUsuario.Endereco)
                                                .FirstOrDefaultAsync(tabelaUsuario => tabelaUsuario.Id == idusuarioProcurado);
                bool usuarioNaoEncontrado = usuarioProcurado == null;

                if(usuarioNaoEncontrado){
                    return NotFound();
                }

                return Ok(
                    new UsuarioResponse {
                        Id          = usuarioProcurado.Id,
                        Nome        = usuarioProcurado.Nome,
                        Sobrenome   = usuarioProcurado.Sobrenome,
                        Telefone    = usuarioProcurado.Telefone,
                        Endereco    = new EnderecoResponse
                        {
                            Cep           = usuarioProcurado.Endereco.cep,
                            Rua           = usuarioProcurado.Endereco.rua,
                            Bairro        = usuarioProcurado.Endereco.bairro,
                            Numero        = usuarioProcurado.Endereco.numero,
                            Complemento   = usuarioProcurado.Endereco.complemento,
                            Estado        = usuarioProcurado.Endereco.estado,
                            Cidade        = usuarioProcurado.Endereco.cidade

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
