using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.ReportService
{
    public interface IReportService
    {
        Task<ServiceResponse<List<ReportDto>>> GetAllReportsAsync();
        Task<ServiceResponse<ReportDto>> GetReportByIdAsync(Guid id);
        Task<ServiceResponse<ReportDto>> CreateReportAsync(string applicationUserId, DateTime startTime, DateTime endTime);
    }
}
