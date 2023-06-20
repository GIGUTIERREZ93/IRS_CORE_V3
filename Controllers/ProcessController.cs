using System;
using System.Collections.Generic;
using System.Linq;
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
        // GET: Process
        public ActionResult Declaration_Errors()
        {
            return View();
        }
        public ActionResult Downtime_Entry()
        {
            return View();
        }

        public ActionResult Kiosk_Configuration()
        {
            return View();
        }
  
    }
}