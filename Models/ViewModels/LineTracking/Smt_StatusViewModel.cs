using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRS.Models;

namespace IRS.Models.ViewModels.LineTracking
{
    public class Smt_StatusViewModel
    {
        public string Linea { get; set; }
        public string WO { get; set; }
        public DateTime Marcadora_f   { get; set; }

        public DateTime SPI_f { get; set; }
        public DateTime AOI_f { get; set; }

        public int Marcadora { get; set; }

        public int SPI { get; set; }
        public int AOI { get; set; }

        public string Pick_place { get; set; }

        public string Oee_detail {  get; set; }

        public int Top {  get; set; }
        public int Bot { get; set; }



    }
   
}