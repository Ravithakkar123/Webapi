using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }
        public int OrderNo { get; set; }
        public int TotalAmount { get; set; }
        public List<OrderItem> OrderItem { get; set; }
        public int CustomerId { get; set; }


    }
}
