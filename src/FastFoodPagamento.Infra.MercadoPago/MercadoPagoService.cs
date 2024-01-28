using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FastFoodPagamento.Domain.Interfaces.Services;
using FastFoodPagamento.Infra.MercadoPago.Models;
using static System.Net.Mime.MediaTypeNames;

namespace FastFoodPagamento.Infra.MercadoPago
{
    public class MercadoPagoService : IGatewayPagamento, IDisposable
    {
        private readonly HttpClient _httpClient;
        public readonly string user_id = "657762990";
        public readonly string external_pos_id = "SUC001POS001";
        private readonly string accessToken = "TEST-7091834242473976-082007-3f2848b83eb8c872aebc130399396854-657762990";

        public MercadoPagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SolicitarQrCodeAsync(Guid pedidoId, decimal valor)
        {
            Requisicao requisicao =  new Requisicao();

            requisicao.external_reference= pedidoId.ToString();
            requisicao.title = "Pedido FastFood FIAP";
            requisicao.notification_url = "https://www.fastfoodfiap.com.br/api/webhook";
            requisicao.description = "Autoatendimento";
            requisicao.total_amount = valor;
            
            requisicao.cash_out.amount = 0;

            QrData? qrData = await PostRequisicaoAsync(requisicao);

            return qrData is null? "" : qrData.qr_data;
        }

        public async Task<QrData?> PostRequisicaoAsync(Requisicao requisicao)
        {
            var requisicaoJson = new StringContent(
                JsonSerializer.Serialize(requisicao),
                Encoding.UTF8,
                Application.Json);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            using var httpResponseMessage =
                await _httpClient.PostAsync($"instore/orders/qr/seller/collectors/{user_id}/pos/{external_pos_id}/qrs", requisicaoJson);

            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            return string.IsNullOrEmpty(resultString)
            ? new QrData()
            : JsonSerializer.Deserialize<QrData>(resultString);            
        }
        
        public void Dispose()
        {
            _httpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}