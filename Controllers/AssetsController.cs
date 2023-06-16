using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRS.Services;

namespace IRS.Controllers
{
    public class AssetsController : Controller
    {
        readonly HardwareService hws = new HardwareService();
       //Actions para formularios

        public ActionResult Add_Hardware_Form()
        {
            return View();
        }
        



        //***********Actions para consultas*********

        public ActionResult Master_Hardware()
        {
            var modelo = hws.Consultar_Hardware();
            return View(modelo);
        }

    }
}