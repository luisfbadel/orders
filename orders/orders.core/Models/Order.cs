using System.ComponentModel.DataAnnotations;

namespace orders.core.Models
{
    public class Order
    {
        public string? Id { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public string CreatedByUsername { get; set; }
    }
}
