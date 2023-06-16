using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IRS.Models.ViewModels
{
    public class Saludo
    {
        [StringLength(10,ErrorMessage ="Debe poner máximo 10 caracteres")]
        public string nombre { get; set; }
        public string apellido { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int edad { get; set; }
        public string color { get; set; }
        public string direccion { get; set; }
    }
}