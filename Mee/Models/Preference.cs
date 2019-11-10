using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mee.Models
{
    public class Preference
    {
        [Key]
        public int PreferenceID { get; set; }
        public bool Select { get; set; }
        public string Preferences { get; set; }
    }
}