using FeatureHub.Application.UseCases.Sum;
using Gcsb.Connect.Pkg.FeatureHub.Application.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FeatureHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumController : ControllerBase
    {
        private readonly ISumUseCase sumUseCase;

        public SumController(ISumUseCase sumUseCase)
        {
            this.sumUseCase = sumUseCase;
        }

        [HttpPost]
        [Features("SOMA")]
        [ProducesResponseType(typeof(int), 200)]
        [Route("Sum")]
        public IActionResult SumValues([FromBody] SumRequest input)
        {
            var sum = sumUseCase.Sum(input.Value1, input.Value2);

            return Ok(sum);
        }
    }
}
