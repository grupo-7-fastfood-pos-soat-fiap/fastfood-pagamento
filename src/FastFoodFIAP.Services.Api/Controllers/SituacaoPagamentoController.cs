using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/situacao-pagamento")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SituacaoPagamentoController: ApiController
    {
        private readonly ISituacaoPagamentoApp _situacaoApp;        

        public SituacaoPagamentoController(ISituacaoPagamentoApp situacaoApp)
        {
            _situacaoApp = situacaoApp;            
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todas as situações.",
        Description = "Lista todas as situações."
        )]
        [SwaggerResponse(200, "Success", typeof(List<SituacaoPagamentoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var lista = await _situacaoApp.GetAll();
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}
