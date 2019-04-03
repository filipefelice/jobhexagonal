namespace ISEntrega.Core.RoboAPI.UseCases.CloseAccount
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using ISEntrega.Core.Application.Commands.Faturamento;

    [Route("api/[controller]")]
    public class FaturamentoController : Controller
    {
        private readonly IEmiteFaturamentoMensalUseCase _faturamentoService;

        public FaturamentoController(
            IEmiteFaturamentoMensalUseCase faturamentoService)
        {
            _faturamentoService = faturamentoService;
        }

        /// <summary>
        /// Processa faturamento mensal
        /// </summary>
        [HttpGet()]
        public async Task<IActionResult> ProcessaMensal()
        {
            var command = new ProcessaFaturamentoCommand();

            var faturamentoResult = await _faturamentoService.Handle(command);

            if (faturamentoResult == null)
            {
                return new NoContentResult();
            }

            return Ok();
        }
    }
}
