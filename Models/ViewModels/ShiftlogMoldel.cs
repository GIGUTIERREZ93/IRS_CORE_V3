using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Models.ViewModels
{
    public class ShiftlogModel
    {
        public string Site { get; set; }
        public string Plant { get; set; }
        public string TicketTy { get; set; }
        public string Line { get; set; }
        public string Category { get; set; }
        public string Sub_Category { get; set; }
        public string Component_ID { get; set; }

        public string Description { get; set; }
        public string Follow { get; set; }
        public string Status { get; set; }
        public string Stop_line { get; set; }
        public string DurationH { get; set; }
        public string DurationM { get; set; }
        public string Reported { get; set; }
    }
}