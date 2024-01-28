namespace FastFoodPagamento.Domain.Commands.PagamentoCommands.Validations
{
    public class PagamentoValidationsCreate : PagamentoValidations<PagamentoCreateCommand>
    {
        public PagamentoValidationsCreate(){        
            ValidaPedidoId();
            ValidaAmount();
        }
    }
}
