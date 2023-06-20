using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRS.Models.ViewModels;
/// <summary>
/// M Olvera and J Montoya are in charge
/// </summary>
namespace IRS.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Ejemplo_Formulario()
        {
            return View();
        }
        public ActionResult Saludo(Saludo sal)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "No mms verifica tus datos";
                return View("Ejemplo_Formulario");
            }
            return View(sal);
        }

        public ActionResult Downtime_Entry ()
        {
            return View();
        }

    }
}