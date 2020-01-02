using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Models
{
    public class OrderItem
    {
      
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int FoodItemId { get; set; }
      
   

    }
}
