using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _56_Xeber.Areas.Admin.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title_az { get; set; }
        public string Text_az { get; set; }
        public string Title_ru { get; set; }
        public string Text_ru { get; set; }
        public DateTime PubDate { get; set; }
        public string Video { get; set; }
        public int ReadCount { get; set; }
        public bool Hot { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Image> Images{ get; set; }
    }

}