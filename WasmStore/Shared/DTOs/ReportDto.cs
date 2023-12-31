﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmStore.Shared.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime TimePeriodStart { get; set; }
        public DateTime TimePeriodEnd { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscount { get; set; }
    }

}
