using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Models.ViewModels
{
    public class ListaComponentes
    {
        public string CompID { get; set; }
        public int FeederID { get; set; }
        public string CompName { get; set; }
        public DateTime OpenTimeStamp { get; set; }
        public int NumDryLeft { get; set; }
        public int McID { get; set; }
        public int Station { get; set; }
        public int Slot { get; set; }
        public int SubSlot { get; set; }
        public int Used { get; set; }
        public int Errors { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
        public int LastSeenOnMachine { get; set; }
       
    }
}