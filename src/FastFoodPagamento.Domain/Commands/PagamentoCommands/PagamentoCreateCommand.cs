namespace FastFoodPagamento.Domain.Commands.PagamentoCommands
{
    public class PagamentoCreateCommand : PagamentoCommand
    {
        protected PagamentoCreateCommand() { }

        public PagamentoCreateCommand(Guid pedidoId, decimal valor)
        {
            PedidoId = pedidoId;
            Valor = valor;
        }
    }
}
