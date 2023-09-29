using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WasmStore.Server.Models;
using WasmStore.Shared.DTOs;
using WasmStore.Shared.Models;

namespace WasmStore.Server.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReportService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<ReportDto>> CreateReportAsync(string applicationUserId, DateTime start, DateTime end)
        {
            var response = new ServiceResponse<ReportDto>();
            try
            {
                // Fetch orders for the specific user within the time range
                var orders = await _context.Orders
                                           .Include(o => o.OrderItems)
                                           .Include(o => o.ApplicationUser)
                                           .Where(o => o.ApplicationUserId == applicationUserId && o.Date >= start && o.Date <= end)
                                           .ToListAsync();

                // Initialize report fields
                decimal totalRevenue = 0;
                decimal totalTax = 0;
                decimal totalDiscount = 0;

                // Calculate the report fields based on the orders
                foreach (var order in orders)
                {
                    totalRevenue += order.Total;
                    totalTax += order.Tax;
                    if (order.Discount != null)
                    {
                        totalDiscount += order.Discount;
                    }
                }

                // Create the report DTO
                var reportDto = new ReportDto
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = applicationUserId,
                    TimePeriodStart = start,
                    TimePeriodEnd = end,
                    TotalRevenue = totalRevenue,
                    TotalTax = totalTax,
                    TotalDiscount = totalDiscount
                };

                // Map the DTO to a Report model
                var report = _mapper.Map<Report>(reportDto);

                // Save the report to the database
                _context.Reports.Add(report);
                await _context.SaveChangesAsync();

                // Update the DTO with the saved report's ID
                reportDto.Id = report.Id;

                response.Data = reportDto;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Task<ServiceResponse<List<ReportDto>>> GetAllReportsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ReportDto>> GetReportByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
