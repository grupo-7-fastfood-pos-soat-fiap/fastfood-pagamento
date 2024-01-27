using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.PagamentoCommands{

    public class PagamentoCommand : Command
    {
        public Guid Id { get; protected set; }

        public Guid PedidoId { get; protected set; }

        public int SituacaoId { get; protected set; }

        public decimal Valor { get; protected set; }
        
    }
}
