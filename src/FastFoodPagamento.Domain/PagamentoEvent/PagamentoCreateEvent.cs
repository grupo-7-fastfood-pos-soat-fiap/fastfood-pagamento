using GenericPack.Messaging;

namespace FastFoodPagamento.Domain.PagamentoEvent
{
    public class PagamentoCreateEvent: Event
    {
        public Guid PedidoId { get; protected set; }

        public PagamentoCreateEvent(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

    }
}
