using System.ComponentModel.DataAnnotations;

namespace FastFoodPagamento.Application.InputModels
{
    public class WebhookPagamentoInputModel
    {
        [Required(ErrorMessage = "O id do pagamento é requerido.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O id do pedido é requerido.")]
        public Guid PedidoId { get; set; }

        [Required(ErrorMessage = "A Situação do pagamento é requerida.")]
        public int SituacaoId { get; set; }
    }
}
