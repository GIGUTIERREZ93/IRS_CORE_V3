using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using IRS.Models;
using IRS.Models.ViewModels;


/// <summary>
/// M Olvera and J Montoya are in charge
/// </summary>
namespace IRS.Controllers
{
    public class ProcessController : Controller
    {
        // Controllers para Vistas dentro de folder PROCESS
        public ActionResult Equipment_Repair() { return View(); }
        public ActionResult Kamishibai_Board() { return View(); }
        public ActionResult Audit_Controls () { return View(); }
        public ActionResult Valor_Apps() { return View(); }

        // Controllers para Vistas dentro de folder PROCESS - > VALOR
        public ActionResult Declaration_Errors() {return View(); }
        public ActionResult Downtime_Entry() { return View(); }
        public ActionResult Kiosk_Configuration() { return View(); }
  
    }
}