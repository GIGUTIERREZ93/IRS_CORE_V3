using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Models.ViewModels.LineTracking
{
    public class FileScannerViewModel
    {

        public string LineID { get; set; }
        public DateTime Marker { get; set; }
        public DateTime SPI {  get; set; }  
        public DateTime AOI { get; set; }
        public DateTime AssyFiles {  get; set; }    
        public string Area { get; set; }
        public short Active { get; set; }     
        public string IDSPI { get; set; }

    }
}