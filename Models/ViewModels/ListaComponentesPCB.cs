using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Models.ViewModels
{
    public class ListaComponentesPCB
    {
        public int DeviceID { get; set; }
        public int McID { get; set; }
        public int Station { get; set; }
        public int Slot { get; set; }
        public int SubSlot { get; set; }
        public string CompID { get; set; }
        public int BlockNo { get; set; }
        public int CompType { get; set; }
        public DateTime InsertDate { get; set; }
    }
}