using WebApi.Application.Interfaces;
using WebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostingEnvironment;
        IProdutoAppService _produtoAppService;
        public ProdutosController(IProdutoAppService produtoAppService, IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
            _produtoAppService = produtoAppService;
        }

        [HttpGet("ListarTodosProdutos", Name = "ListarTodosProdutos")]
        public IActionResult GetAll()
        {
            return Ok(_produtoAppService.GetAll());
        }

        [HttpPost("CadastrarProduto", Name = "CadastrarProduto")]
        public async Task<IActionResult> Insert([FromForm] ProdutoDTO produtoDTO)
        {
            try
            {
                produtoDTO = await _produtoAppService.Insert(produtoDTO);
                return Ok(produtoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpPut("AtualizarProduto", Name = "AtualizarProduto")]
        public async Task<IActionResult> Update([FromForm] ProdutoDTO produtoDTO)
        {
            try
            {
                await _produtoAppService.Update(produtoDTO);
                return Ok(produtoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeletarProduto", Name = "DeletarProduto")]
        public IActionResult Delete(int id)
        {
            try
            {
                _produtoAppService.Delete(id);
                return Ok("Produto excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Details", Name = "Details")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_produtoAppService.GetProdutoDTOById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}