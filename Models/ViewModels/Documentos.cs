using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRS.Models.ViewModels
{
    public class Documentos
    {
        [Required]
        public HttpPostedFileBase DocumentName { get; set; }
    }
}