using GenericPack.Domain;

namespace FastFoodPagamento.Domain.Models
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public String QrCode { get; private set; } = "";
        public decimal Valor { get; private set; }
        public Guid PedidoId { get; private set; }
        public int SituacaoId { get; private set; }

        public virtual SituacaoPagamento? SituacaoPagamentoNavegation { get; private set; }

        private Pagamento() { }

        public Pagamento(Guid id, string qrCode, decimal valor, Guid pedidoId, int situacaoId)
        {
            Id = id;
            QrCode = qrCode;
            Valor = valor;
            PedidoId = pedidoId;
            SituacaoId = situacaoId;
        }
    }
}
