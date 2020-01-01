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
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int Amount { get; set; }

        public int FoodItemId { get; set; }
        [ForeignKey("FoodItemId")]
        public FoodItem foodItem { get; set; }
   

    }
}
