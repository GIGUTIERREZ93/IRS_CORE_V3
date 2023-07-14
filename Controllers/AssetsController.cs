using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRS.Services;
/// <summary>
/// J Mendoza and J Montoya
/// </summary>
namespace IRS.Controllers
{
    public class AssetsController : Controller
    {
        readonly HardwareService hws = new HardwareService();
        readonly SoftwareServices sws = new SoftwareServices();
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

        public ActionResult Master_Software()
        {

            var result = sws.Get_Software();
            return View(result);
        }

        public ActionResult Get_Anexos()
        {
            var result = hws.Obtener_Anexos();

            return View(result);
        }

        public ActionResult Add_Employees()
        {
           

            return View();
        }


        public ActionResult Add_Hardware()
        {


            return View();
        }

        public ActionResult Add_Modelo_Hardware()
        {


            return View();
        }

        public ActionResult Add_Phone()
        {


            return View();
        }

        public ActionResult Add_Software()
        {


            return View();
        }

        public ActionResult Add_Vendor()
        {


            return View();
        }
    }
}