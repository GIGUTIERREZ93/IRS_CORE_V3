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
        // Controllers para Vistas de PROCESS
        public ActionResult Equipment_Repair() { return View(); }
        public ActionResult Kamishibai_Board() { return View(); }
        public ActionResult Audit_Controls () { return View(); }
        public ActionResult Valor_Apps() { return View(); }

        // Controllers para Vistas de PROCESS para sub operaciones de VALOR_APPS
        public ActionResult Declaration_Errors() {return View(); }
        public ActionResult DowntimeEntry() { return View(); }
        public ActionResult Kiosk_Configuration() { return View(); }
        public ActionResult Error_Codes() { return View(); }
        public ActionResult PLC_Activation() { return View(); }
        public ActionResult OEE_Reporting() { return View(); }
        public ActionResult System_Erros() { return View(); }
        public ActionResult Trace_Errors() { return View(); }
        public ActionResult History_Check() { return View(); }
        public ActionResult Trace_Desactivation() { return View(); }
        public ActionResult Valor_Declaration() { return View(); }
    }
}