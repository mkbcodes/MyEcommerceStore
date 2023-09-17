using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmStore.Shared
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? ReportType { get; set; }

        [Required, MaxLength(50)]
        public string? TimePeriod { get; set; }

        [MaxLength(25)]
        public string? Region { get; set; }

        [Required]
        public int? AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }
    }
}
