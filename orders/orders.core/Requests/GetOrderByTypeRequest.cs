using System.ComponentModel.DataAnnotations;

namespace orders.core.Requests
{
    public class GetOrderByTypeRequest
    {
        [Required]
        public int Type { get; set; }
    }
}
