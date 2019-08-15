using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading;
using _56_Xeber.Resources;

namespace _56_Xeber.Areas.Admin.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

    }


    


}


