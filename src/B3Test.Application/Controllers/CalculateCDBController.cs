using B3Test.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace B3Test.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateCdbController : ControllerBase
    {
        private readonly ICdbService cdbService;

        public CalculateCdbController(ICdbService cdbService)
        {
            this.cdbService = cdbService;
        }

        [HttpGet("calculate")]
        public IActionResult Calculate(decimal initialValue, int months)
        {
            decimal redemptionValue = cdbService.CalculateCDB(initialValue, months);
            decimal tax = cdbService.CalculateTax(redemptionValue, initialValue, months);

            decimal liquidValue = redemptionValue - tax;

            return Ok(new
            {
                RescueValue = redemptionValue,
                Tax = tax,
                LiquidValue = liquidValue
            });
        }
    }
}
