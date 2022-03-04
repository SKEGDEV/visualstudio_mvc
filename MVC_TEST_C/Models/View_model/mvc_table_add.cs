using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_TEST_C.Models.View_model
{
    public class mvc_table_add
    {
        [Required]
        [Display(Name = "id")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "nombre")]
        public string name_user { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "fecha")]
        public DateTime birthday { get; set; }

    }
}