using FastFoodPagamento.Application.InputModels;
using FastFoodPagamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodPagamento.Services.Api.Controllers
{
    [ApiController]
    [Route("api/pagamento")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PagamentoController : ApiController
    {
        private readonly IPagamentoApp _pagamentoApp;

        public PagamentoController(IPagamentoApp pagamentoApp)
        {
            _pagamentoApp = pagamentoApp;
        }

        [HttpPost("/")]
        [SwaggerOperation(
        Summary = "Cria um pagamento e seu QR Code",
        Description = "Recebe um pedido ID e um valor e retorna um QR Code para pagamento"
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Create([FromBody] NewPagamentoInputModel newPagamentoInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                return CustomResponse(await _pagamentoApp.Create(newPagamentoInputModel));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
        }

        [HttpPost("/webhook")]
        [SwaggerOperation(
        Summary = "Recebe a confirmação de pagamento aprovado ou pagamento recusado",
        Description = "Recebe a confirmação de pagamento aprovado ou pagamento recusado"
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> PostWebhook([FromBody] WebhookPagamentoInputModel pagamento)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                return CustomNoContentResponse(await _pagamentoApp.Update(pagamento));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}
