using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.DTOs;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        [HttpGet]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDto()));
        }

        [HttpPost]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto(ProdutoDto produto)
        {
            if (!ModelState.IsValid) return View(await PopularCategorias(new ProdutoDto()));

            await _produtoAppService.AdicionarProduto(produto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoAppService.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDto ProdutoDto)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            ProdutoDto.QuantidadeEstoque = produto.QuantidadeEstoque;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategorias(ProdutoDto));

            await _produtoAppService.AtualizarProduto(ProdutoDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
                await _produtoAppService.ReporEstoque(id, quantidade);
            else
                await _produtoAppService.DebitarEstoque(id, quantidade);

            return View("Index", await _produtoAppService.ObterTodos());
        }

        private async Task<ProdutoDto> PopularCategorias(ProdutoDto produto)
        {
            produto.Categorias = await _produtoAppService.ObterCategorias();
            return produto;
        }
    }
}
