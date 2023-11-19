using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankingMvcTestApp.Models
{
    [Table("userlogin", Schema = "public")]
    public class LoginClass
    {
        [Key]
        public int userid { get; set; }
        [Required(ErrorMessage = "Please enter valid account number")]
        [Display(Name = "Enter account number :")]
        public string accountnumber { get; set; }

        [Required(ErrorMessage = "Please enter valid pasword")]
        [Display(Name = "Enter pasword :")]
        [DataType(DataType.Password)]
        public string accountpassword { get; set; }
    }
}