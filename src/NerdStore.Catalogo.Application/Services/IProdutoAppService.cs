using NerdStore.Catalogo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services
{
    public interface IProdutoAppService
    {
        Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigoCategoria);
        Task<ProdutoDto> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDto>> ObterTodos();
        Task<IEnumerable<CategoriaDto>> ObterCategorias();

        Task AdicionarProduto(ProdutoDto ProdutoDto);
        Task AtualizarProduto(ProdutoDto ProdutoDto);

        Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDto> ReporEstoque(Guid id, int quantidade);
    }
}
