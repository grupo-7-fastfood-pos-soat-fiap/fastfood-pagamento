namespace FastFoodFIAP.Domain.Interfaces.Services
{
    public interface IGatewayPagamento
    {
        Task<string> SolicitarQrCodeAsync(Guid pedidoId, decimal valor);
    }
}
