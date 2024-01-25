using FastFoodFIAP.Domain.Commands.PagamentoCommands;

namespace FastFoodFIAP.Domain.Test;

public class PagamentoCreateCommandTest
{
    [Fact]
    public void ValidaConstrutor()
    {
        Guid pedidoId = Guid.NewGuid();
        decimal valor = 2;
        
        PagamentoCreateCommand pag = new PagamentoCreateCommand(pedidoId, valor);
        
        Assert.Equal(pag.PedidoId, pedidoId);
        Assert.Equal(pag.Valor, valor);
    }
}