using System.ComponentModel.DataAnnotations;

namespace orders.core.Requests
{
    public class GetOrderByIdRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
