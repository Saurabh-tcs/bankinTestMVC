using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankingMvcTestApp.Models
{
    [Table("customer", Schema ="public")]
    public class CustomerClass
    {
        [Key]
        public int customerid { get; set; }
        public string customer_name { get; set; }
        public string customer_accounttype { get; set; }
        public int customer_accountbalance { get; set; }
        public string email { get; set; }
    }
}