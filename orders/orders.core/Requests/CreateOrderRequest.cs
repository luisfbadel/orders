using System.ComponentModel.DataAnnotations;

namespace orders.core.Requests
{
    public class CreateOrderRequest
    {
        [Required]
        public int? Type { get; set; }

        [Required]
        public string? CustomerName { get; set; }

        [Required]
        public string? CreatedByUsername { get; set; }
    }
}
