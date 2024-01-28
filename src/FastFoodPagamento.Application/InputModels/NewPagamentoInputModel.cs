using System.ComponentModel.DataAnnotations;

namespace FastFoodPagamento.Application.InputModels
{
    public class NewPagamentoInputModel
    {
        [Required(ErrorMessage = "O id do pedido é requerido.")]
        public Guid PedidoId { get; set; }

        [Required(ErrorMessage = "O valor do pagamento é requerida.")]
        public decimal Valor { get; set; }
    }
}
