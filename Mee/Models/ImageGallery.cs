using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mee.Models
{
    public class ImageGallery
    {
        [Key]
        public int ImageID { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] imageData { get; set; }

        [Required(ErrorMessage ="Please select image file")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

    }
}