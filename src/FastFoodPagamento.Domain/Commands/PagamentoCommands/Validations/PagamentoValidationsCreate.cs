﻿namespace FastFoodPagamento.Domain.Commands.PagamentoCommands.Validations
{
    public class PagamentoValidationsUpdate : PagamentoValidations<PagamentoUpdateCommand>
    {
        public PagamentoValidationsUpdate(){        
            ValidaId();    
            ValidaSituacao();
        }
    }
}
