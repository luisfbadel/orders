using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.core.Models
{
    public class Order
    {
        public string Id { get; set; }
        public int Type { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUsername { get; set; }
    }
}
