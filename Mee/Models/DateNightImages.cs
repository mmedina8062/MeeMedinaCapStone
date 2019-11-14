using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mee.Models
{
    public class DateNightImages
    {
        [Key]
        public int ImageID { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
    }
}