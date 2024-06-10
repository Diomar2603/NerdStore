using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoAtualizadoEvent  : Event
    {
        public Guid ClientId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }


        public PedidoAtualizadoEvent(Guid clientId, Guid pedidoId, Guid produtoId, int quantidade)
        {
            AggregateId = pedidoId;
            ClientId = clientId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }
    }
}
