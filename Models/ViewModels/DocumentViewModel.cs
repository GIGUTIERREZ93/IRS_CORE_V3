using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRS.Models.ViewModels
{
    public class DocumentViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
        public string Datos { get; set; }
    }
}