using Amazon.SQS;

namespace FastFoodPagamento.Infra.Data.Mensageria
{
    public class AndamentoMensageria
    {
        public static async Task SendMessage(string queueURL, Guid pedidoId)
        {
            var sqsClient = new AmazonSQSClient();

            var pedido_id = pedidoId.ToString();

            object value = new { pedido_id };

            await sqsClient.SendMessageAsync(queueURL, value.ToString().Replace(" =", ":"));

        }
    }
}
