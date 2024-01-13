using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Domain.Models;
using GenericPack.Messaging;
using MediatR;


namespace FastFoodFIAP.Domain.Events.PagamentoEvents
{
    public class PagamentoEventHandler :
        INotificationHandler<PagamentoCreateEvent>
    {

        private readonly IPagamentoRepository _repository;
        private readonly IGatewayPagamento _gateway;

        public PagamentoEventHandler(IPagamentoRepository repository, IGatewayPagamento gateway)
        {
            _repository = repository;
            _gateway = gateway;
        }

        public async Task Handle(PagamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            var qrCode = await _gateway.SolicitarQrCodeAsync(notification.PedidoId, notification.Valor);

            var pagamento = new Pagamento(Guid.NewGuid(), qrCode, notification.Valor, notification.PedidoId, (int)Models.Enums.SituacaoPagamento.Pendente);
            
            _repository.Add(pagamento);            

            return;
        }

    }
}
