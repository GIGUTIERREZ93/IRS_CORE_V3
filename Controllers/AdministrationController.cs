using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRS.Models;
using IRS.Models.ViewModels;
using IRS.Services;



/// </summary>
namespace IRS.Controllers
{
    public class AdministrationController : Controller
    {
        readonly DocumentServices document=new DocumentServices();
        // GET: Administration
        public ActionResult Administration_Menu()
        {
            return View();
        }
        //Action del formulario para agregar documentacion
        public ActionResult Agregar_Documento()
        {
            return View();
        }
       

        //Action para insertar documento
        public ActionResult Insertar_Documento(HttpPostedFileBase DocumentName, string DocID, string IT_Area, string Topic, string DocType, string Fecha, string UserID )
        {
            var InsertarDoc_Services = new Document();
            var resultado=InsertarDoc_Services.Insertar_Documento
            Mostrar_Documento();
        }
        //************************

        //Action para mostrar datos del documento

        public ViewResult Mostrar_Documento()
        {
            var model = document.Mostrar_Documentos();
            return View(model); 
        }


        //Action del formulario para agregar proyecto
        public ActionResult Agregar_Proyecto()
        {
            return View();
        }

        //Action para mostrar datos de un proyecto
        public ActionResult Proyecto(Proyecto proj)
        {
            return View(proj);
        }

        //Action del formulario para agregar una linea telefonica
        public ActionResult Agregar_Linea_Telefonica()
        {
            return View();
        }

        //Actiom del formulario para agregar un registro shiftlog
        public ActionResult Agregar_Shiftlog()
        {
            return View();
        }

        //Action para mostrar detalles de un registro shiftlog
        public ActionResult Shiftlog(ShiftlogModel ShLo)
        {
            return View(ShLo);
        }

        //Action del formulario para agregar usuarios
        public ActionResult AgregarUsuario()
        {
            return View();
        }
    }

}