using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WasmStore.Server.Models;
using WasmStore.Server.Services.ReportService;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ReportDto>>> CreateReportAsync(string applicationUserId, DateTime start, DateTime end)
        {
            var response = await _reportService.CreateReportAsync(applicationUserId, start,end);
            if (response.Success)
                return Ok(response);
            return NotFound(response);
        }
    }
}
