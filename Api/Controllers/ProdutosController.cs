using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HttpRequests;
using Models.HttpResponse;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly LojaDbContext _contexto;
        public ProdutosController(LojaDbContext contexto)
        {
            _contexto = contexto;
        }
        [HttpPost]
        public async Task<ActionResult> Registrar([FromBody] ProdutoRequest novoProduto) {
            try{
                var produto = new Produto 
                {
                    Nome = novoProduto.Nome,
                    Descricao = novoProduto.Descricao
                };

                await _contexto.Produtos.AddAsync(produto);

                await _contexto.SaveChangesAsync();

                novoProduto.Id = produto.Id;

                return StatusCode(201, new { idProduto = novoProduto.Id });
            }
            catch(Exception) {
                return StatusCode(500, "Não foi possível realizar o cadastro do produto!");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponse>>> ObterLista(){
            try {
                var produtos = await _contexto.Produtos.ToListAsync();

                return Ok(produtos);
            }
            catch(Exception) {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }
        [HttpGet("idDoProdutoQueEstaBuscanco")]
        public async Task<ActionResult<ProdutoResponse>> ObterPelaId(Guid idDoProdutoQueEstaBuscando){
            try {
                var produtoQueEstamosBuscando = await _contexto.Produtos
                                                .FirstOrDefaultAsync(tabelaProdutos => tabelaProdutos.Id == idDoProdutoQueEstaBuscando);
                bool produtoNaoEncontrado = produtoQueEstamosBuscando == null;

                if(produtoNaoEncontrado){
                    return NotFound();
                }

                return Ok(
                    new ProdutoResponse {
                        Id = produtoQueEstamosBuscando.Id,
                        Nome = produtoQueEstamosBuscando.Nome,
                        Descricao = produtoQueEstamosBuscando.Descricao
                    }
                );
            }
            catch(Exception) {
                return StatusCode(500, "Não foi possível realizar a consulta.");
            }
        }
    }
}