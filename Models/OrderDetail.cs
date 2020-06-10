using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int LineNos { get; set; }
        public int OrderNo { get; set; }
        public int ProductId { get; set; }
        public int NoOfUnits { get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(20,2)")]
        public decimal NetAmount { get; set; }

        
    }
}

 

 



