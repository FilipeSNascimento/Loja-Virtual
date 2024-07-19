using Contexts;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.HttpRequests;
using System.ComponentModel.DataAnnotations;
using System.Net;


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

        //POST: api/contas/autenticar
        [HttpPost("autenticar")]
        public void Autenticar(CredencialRequest credencial) {

        }

        // POST: api/contas/registrar
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar([FromBody] UsuarioRequest usuario) {
        //Implementação de cadastro do usuário
        var registro = await _contexto.Database.BeginTransactionAsync();
       
           
            try
            {
                _contexto.Enderecos.Add(new Endereco {
                    bairro      = usuario.Endereco.Bairro,
                    numero       = usuario.Endereco.Numero,
                    cep          = usuario.Endereco.Cep,
                    rua          = usuario.Endereco.Rua
                });
            
                await _contexto.SaveChangesAsync();

                
                    _contexto.Credenciais.Add(new Credencial {
                        email = usuario.Credencial.Email,
                        senha = usuario.Credencial.Senha,
                    });

                await _contexto.SaveChangesAsync();
                
                
                    _contexto.Usuarios.Add(new Usuario {
                        Nome = usuario.Nome,
                        Sobrenome = usuario.Sobrenome,
                        Telefone = usuario.Telefone
                    });

                    await _contexto.SaveChangesAsync();

                    await registro.CommitAsync();

                    return Ok();
            }

            catch(Exception)
            {
                registro.Rollback();

                return StatusCode(500, "Não foi possivel realizar o cadastro!");
            }
        

        
        //Banco = _contexto
        //Tabela = Usuario
        //Add = Operação
        
        }
    }
}