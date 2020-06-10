using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName ="varchar(100)")]
        public string ProductName { get; set; }

        [Column(TypeName = "varchar(350)")]
        public string ProductDescription{ get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal Price { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        
    }
}
