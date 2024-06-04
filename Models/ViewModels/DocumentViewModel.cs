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
        //atributos de tipo hhtppostfile base
        public HttpPostedFileBase File { get; set; }


        [Required]
        //Datos registrados en la vista Agregar Documento 
        public string DocID { get; set; }
        [Required]
        public string DocumentName { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string DocType { get; set; }
        [Required]
        public string Title { get; set; }
       
        public string Fecha { get; set; }

        public string UserID { get; set; }

    }
}