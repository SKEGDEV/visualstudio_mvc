using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TEST_C.Models.View_model
{
    public class table_view_model
    {
        public int id { get; set; }
        public string name_user { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
    }
}