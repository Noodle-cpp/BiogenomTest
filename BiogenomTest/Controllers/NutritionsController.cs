using Api.ViewModels.Responses;
using Application.Exceptions;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NutritionsController : ControllerBase
    {
        private readonly INutritionsReportService _reportService;

        public NutritionsController(INutritionsReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: <NutritionController>
        /// <summary>
        /// Получить полный отчет
        /// </summary>
        /// <returns></returns>
        /// Выдает все БАДы, которые подходят по витаминам.
        /// Не совсем разбираюсь в этой теме, поэтому если БАД А подходит для воставления витамина C и D, 
        /// а БАД В подходит только для восстановления D, то все равно будут выведены оба
        [HttpGet("report")]
        public async Task<IActionResult> GetStatisticAsync()
        {
            try
            {
                var report = await _reportService.GetNutritionsReportAsync().ConfigureAwait(false);

                var response = new NutritionReportResponse()
                {
                    Id = report.Id,
                    CountBelow = report.CountBelow,
                    CountInNorm = report.CountInNorm,
                    DietarySupplements = report.DietarySupplements.Select(x => new DietarySupplementResponse()
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToList(),
                    VitaminAttributeViewModels = report.VitaminAttributes.Select(x => new VitaminAttributeResponse()
                    {
                        NormValue = x.NormValue,
                        Value = x.Value,
                        ValueDif = x.ValueDif,
                        VitaminTitle = x.VitaminTitle
                    }).ToList(),
                    VitaminBalances = report.VitaminBalances.Select(x => new VitaminBalanceResponse()
                    {
                        VitaminTitle = x.VitaminTitle,
                        SuppsValue = x.SuppsValue,
                        Value = x.Value
                    })
                };

                return Ok(response);
            }
            catch (NutritionsReportNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
