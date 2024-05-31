using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRS.Models;
using IRS.Models.ViewModels;
using IRS.Services;
using System.IO;
using System.Data.SqlClient;
using System.Data;

//***** A cargo de I Mora y J Montoya

/// </summary>
namespace IRS.Controllers
{

    public class AdministrationController : Controller
    {
        readonly DocumentServices document=new DocumentServices();
        
        public ActionResult Administration_Menu()
        {
            return View();
        }


        //Action del formulario para agregar documentacion
        public ActionResult Agregar_Documento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subir_Documento(DocumentViewModel model)
        {
            string RutaServer = Server.MapPath("~/");
            string RutaFile = Path.Combine(RutaServer + "/Resources/Documents/File.pdf");

            if (!ModelState.IsValid) {

                return View("Agregar_Documento", model);
            }
            else
            { 
            model.File.SaveAs(RutaFile);
            TempData["Message"] = "Se cargo el documento";
            }
            return View();
        }

       
       

        
       

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