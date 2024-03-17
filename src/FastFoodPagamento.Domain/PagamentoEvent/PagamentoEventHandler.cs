using Amazon.SQS;
using MediatR;

namespace FastFoodPagamento.Domain.PagamentoEvent
{
    public class PagamentoEventHandler: INotificationHandler<PagamentoCreateEvent>
    {
        public async Task Handle(PagamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            var sqsClient = new AmazonSQSClient();

            var pedido_id = notification.PedidoId.ToString();

            await sqsClient.SendMessageAsync("https://sqs.us-east-1.amazonaws.com/381491906285/PagamentoAprovado.fifo", pedido_id);
        }
    }
}
