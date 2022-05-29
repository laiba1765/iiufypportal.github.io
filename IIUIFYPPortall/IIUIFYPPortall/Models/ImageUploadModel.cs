using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIUIFYPPortall.Models
{
    public class ImageUploadModel
    {
        public HttpPostedFileWrapper ImageFile { get; set; }
        public string PathtoSave { get; set; }
    }
}