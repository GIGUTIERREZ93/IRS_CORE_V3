using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Models.ViewModels
{
    public class XHistoryCheck
    {
        public string SerialNumber { get; set; }
        public int Sequence { get; set; }
        public DateTime TimeDone { get; set; }
        public string Message { get; set; }
        public string LineID { get; set; }
        public string StationID { get; set; }
        public string PN { get; set; } // Part Number
       

    }
}