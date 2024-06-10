using NerdStore.Vendas.Application.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoDto>> ObterPedidosCliente(Guid clienteId);
    }
}
