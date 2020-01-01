using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public int CardNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string Exp { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public int CVV { get; set; }

    }
}
