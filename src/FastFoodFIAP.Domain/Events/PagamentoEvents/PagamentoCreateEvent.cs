using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoCreateEvent : Event
    {
        public Guid Id { get; protected set; }
        public Guid PedidoId { get; protected set;}

        public PagamentoCreateEvent(PedidoId pedidoId)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
        }
    }
}
