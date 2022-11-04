using System.ComponentModel.DataAnnotations;

namespace orders.core.Requests
{
    public class UpdateOrderRequest
    {
        [Required]
        public string? Id { get; set; }

        [Required]
        public int? Type { get; set; }

        [Required]
        public string? CustomerName { get; set; }
    }
}
