namespace FastFoodPagamento.Domain.Commands.PagamentoCommands{

    public class PagamentoUpdateCommand : PagamentoCommand
    {
        protected PagamentoUpdateCommand(){}

        public PagamentoUpdateCommand(Guid id, int situacaoId){
            Id = id;
            SituacaoId = situacaoId;
        }
    }
}
