using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Column (TypeName="varchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string IDNo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Mobile { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
