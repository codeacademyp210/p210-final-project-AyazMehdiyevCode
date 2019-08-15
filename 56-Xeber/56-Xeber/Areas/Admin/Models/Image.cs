using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _56_Xeber.Areas.Admin.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int NewsId { get; set; }
        public News News { get; set; }
    }


        

}