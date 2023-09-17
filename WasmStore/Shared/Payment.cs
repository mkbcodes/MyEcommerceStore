using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmStore.Shared
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Required, MaxLength(25)]
        public string? TransactionId { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required, MaxLength(50)]
        public string? Status { get; set; }

        [Required, MaxLength(25)]
        public string? PaymentMethod { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
