using Contexts;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.HttpRequests;
using Models.HttpResponse;
using Microsoft.EntityFrameworkCore;


namespace Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly LojaDbContext _contexto;
        public ContasController(LojaDbContext contexto)
        {
            _contexto = contexto;
        }

        // POST: api/contas/registrar
        [HttpPost("registrar")]
        public async Task<ActionResult> RegistrarUsuario([FromBody] UsuarioRequest novoUsuario) 
        {
        //Implementação de cadastro do usuário
            var transacaoDeCadastro = await _contexto.Database.BeginTransactionAsync();
       
            try
            {
                var endereco = new Endereco
                {
                    Bairro       = novoUsuario.Endereco.Bairro,
                    Numero       = novoUsuario.Endereco.Numero,
                    Cep          = novoUsuario.Endereco.Cep,
                    Complemento  = novoUsuario.Endereco.Complemento,
                    Cidade       = novoUsuario.Endereco.Cidade,
                    Estado       = novoUsuario.Endereco.Estado
                };
                _contexto.Enderecos.Add(endereco);

                await _contexto.SaveChangesAsync();

                var usuario = new Usuario
                {
                    Nome = novoUsuario.Nome,
                    Sobrenome = novoUsuario.Sobrenome,
                    Telefone = novoUsuario.Telefone,
                    EnderecoId = endereco.Id
                };

                _contexto.Usuarios.Add(usuario);

                await _contexto.SaveChangesAsync();

                novoUsuario.Id = usuario.Id;
                
                var credencial = new Credencial
                {
                    Email = novoUsuario.Credencial.Email,
                    Senha = novoUsuario.Credencial.Senha,
                    UsuarioId = novoUsuario.Id
                };
                
                _contexto.Credenciais.Add(credencial);

                await _contexto.SaveChangesAsync();
                
                await transacaoDeCadastro.CommitAsync();

                return StatusCode(201, new { idUsuario = novoUsuario.Id });
            }

            catch(Exception)
            {
                transacaoDeCadastro.Rollback();

                return StatusCode(500, "Não foi possivel realizar o cadastro!");
            }
        }

        [HttpGet("{idDoUsuarioQueEstamosBuscando}")]
        public async Task<ActionResult<UsuarioResponse>> ObterUsuarioPelaId(Guid idDoUsuarioQueEstamosBuscando) {
            //Implementação de consulta do usuário
            try{
                var usuarioQueEstamosBuscando = await _contexto.Usuarios
                                                .Include(tabelaUsuario => tabelaUsuario.Endereco)
                                                .FirstOrDefaultAsync(tabelaUsuario => tabelaUsuario.Id == idDoUsuarioQueEstamosBuscando);
                bool usuarioNaoEncontrado = usuarioQueEstamosBuscando == null;

                if(usuarioNaoEncontrado){
                    return NotFound();
                }

                return Ok(
                    new UsuarioResponse {
                        Id          = usuarioQueEstamosBuscando.Id,
                        Nome        = usuarioQueEstamosBuscando.Nome,
                        Sobrenome   = usuarioQueEstamosBuscando.Sobrenome,
                        Telefone    = usuarioQueEstamosBuscando.Telefone,
                        Endereco    = new EnderecoResponse
                        {
                            Cep           = usuarioQueEstamosBuscando.Endereco.Cep,
                            Rua           = usuarioQueEstamosBuscando.Endereco.Rua,
                            Bairro        = usuarioQueEstamosBuscando.Endereco.Bairro,
                            Numero        = usuarioQueEstamosBuscando.Endereco.Numero,
                            Complemento   = usuarioQueEstamosBuscando.Endereco.Complemento,
                            Estado        = usuarioQueEstamosBuscando.Endereco.Estado,
                            Cidade        = usuarioQueEstamosBuscando.Endereco.Cidade

                        }
                    }
                );
                
            }
            catch(Exception){
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }   
    }
}           //Banco = _contexto
        //Tabela = Usuario
        //Add = Operação