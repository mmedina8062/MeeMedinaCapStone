using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mee.Models
{
    public class Rating
    {
        [Key]
        public int RateID { get; set; }
        public int SitterID { get; set; }
        //public string ParentName { get; set; }

        public int Ratings { get; set; }
        public string Comments { get; set; }

        /* [ForeignKey("ParentID")]
         public virtual Parent Parent { get; set; }*/
        [ForeignKey("SitterID")]
        public virtual Sitter Sitter { get; set; }
    }
}