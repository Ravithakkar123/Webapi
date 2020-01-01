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
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int OrderNo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int TotalAmount { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
     //   public string PaymentMethod { get; set; }
      
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<string> OrderItem { get; set; }
       
        [ForeignKey("OrderItem")]
        public OrderItem OrderItem { get; set; }
    }
}
