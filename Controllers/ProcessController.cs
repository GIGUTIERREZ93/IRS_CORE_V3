using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using IRS.Models;
using IRS.Models.ViewModels;
using IRS.Services;
using Microsoft.Ajax.Utilities;

/// <summary>
/// M Olvera and J Montoya are in charge
/// </summary>
namespace IRS.Controllers
{
    public class ProcessController : Controller
    {
        readonly ValorServices oService = new ValorServices();
        readonly public vManageEntities db_vmanage = new vManageEntities();

        //¡¡¡¡ Controllers para Vistas de PROCESS
        public ActionResult Equipment_Repair() { return View(); }
        public ActionResult Kamishibai_Board() { return View(); }
        public ActionResult Audit_Controls () { return View(); }
        public ActionResult Valor_Apps() { return View(); }

        //¡¡¡¡ Controllers para Vistas de PROCESS para sub operaciones de VALOR_APPS
        public ActionResult Declaration_Errors() 
        {
            var model = oService.Declaration_Errors();
            return View(model); 
        }
        public ActionResult DowntimeEntry() { return View(); }
        public ActionResult Kiosk_Configuration() { return View(); }
        public ActionResult Error_Codes() { return View(); }
        public ActionResult PLC_Activation() { return View(); }
        public ActionResult OEE_Reporting() { return View(); }
        public ActionResult System_Erros() { return View(); }
        public ActionResult Trace_Errors() 
        {
            var model = oService.LogErrores();
            return View(model); 
        }
        public ActionResult History_Check(string serie="1") 
        {
            string query;
            if (serie == "1")
            {
                query = "SELECT A.SerialNumber, Convert(int,A.Sequence) as Sequence , A.TimeDone, A.Message, A.LineID, A.StationID, B.PN FROM (SELECT top (1000)ID,SerialNumber,Message, LineID, StationID, Sequence, TimeDone, Result, AliasSerialNumber FROM dbo.XHistoryCheck WHERE (SerialNumber<>'') ORDER BY TimeDone DESC) AS A INNER JOIN dbo.XCuadranteDisplay2 AS B ON A.SerialNumber = B.SN_PCB_Main ORDER BY TimeDone DESC";
            }
            else
            {

                query = "SELECT A.SerialNumber, Convert(int,A.Sequence) as Sequence , A.TimeDone, A.Message, A.LineID, A.StationID, B.PN FROM (SELECT top (1000)ID,SerialNumber,Message, LineID, StationID, Sequence, TimeDone, Result, AliasSerialNumber FROM dbo.XHistoryCheck WHERE (SerialNumber='" + serie+"') ORDER BY TimeDone DESC) AS A INNER JOIN dbo.XCuadranteDisplay2 AS B ON A.SerialNumber = B.SN_PCB_Main";
            }

            var result= db_vmanage.Database.SqlQuery<XHistoryCheck>(query).ToList();

            return View(result); 
        }
        public ActionResult History_Check_Selectivos(string serie = "1")
        {
            string query;
            if (serie == "1")
            {
                query = "SELECT A.SerialNumber, Convert(int,A.Sequence) as Sequence , A.TimeDone, A.Message, A.LineID, A.StationID FROM (SELECT top (50)ID,SerialNumber,Message, LineID, StationID, Sequence, TimeDone, Result, AliasSerialNumber FROM dbo.XHistoryCheck WHERE (SerialNumber<>'' AND (StationID='XRAY' OR StationID='ROUTER' OR StationID='OBP')) ORDER BY TimeDone DESC) AS A  ORDER BY TimeDone DESC";
            }
            else
            {

                query = "SELECT A.SerialNumber, Convert(int,A.Sequence) as Sequence , A.TimeDone, A.Message, A.LineID, A.StationID FROM (SELECT top (100)ID,SerialNumber,Message, LineID, StationID, Sequence, TimeDone, Result, AliasSerialNumber FROM dbo.XHistoryCheck WHERE (SerialNumber='" + serie + "' AND (StationID='XRAY' OR StationID='ROUTER' OR StationID='OBP')) ORDER BY TimeDone DESC) AS A";
            }

            var result = db_vmanage.Database.SqlQuery<XHistoryCheck>(query).ToList();

            return View(result);
        }

        public ActionResult Trace_Desactivation() { return View(); }
        public ActionResult Valor_Declaration() { return View(); }

        //¡¡¡¡ Action and View Result para Formulario de Declaration Program > CRUD
        public ViewResult Declaration_Programs() 
        {
            //Tabla que muestra todos los registros de la tabla <XDeclarationProgram>
            var query = oService.xDeclaration_Programs();
           
            return View(query); 
        }
        public ViewResult Declaration_Program_formulario()
        {
            ViewBag.McID = db_vmanage.XDeclarationProgram.DistinctBy(a=>a.McID).Select(a=>a.McID).ToList();
            ViewBag.Lineas = db_vmanage.XDeclarationProgram.DistinctBy(b => b.Line).Select(b => b.Line).ToList();
            
            //Formulario para un nuevo registro
            return View();
        }
        public ActionResult Declation_Program_Insertar(XDeclarationProgram model)
        {
            //Action Result para insertar en la tabla <XDeclarationProgram> el nuevo registro
            oService.Insertar(model);
            return RedirectToAction("Declaration_Programs");
        }
        public ActionResult Declation_Program_Editar_formulario(long dato)
        {
            //Buscando, seleccionando y enviando el RecordID a MOSTRAR en la vista Declation_Program_Editar_formulario
            var model = oService.Editar(dato);
            return View(model);
        }
        public ActionResult Declation_Program_Editar(XDeclarationProgram model)
        {
            oService.Editar_Form(model);
            return RedirectToAction("Declaration_Programs");
        }
        public ActionResult Declation_Program_Eliminar(long dato)
        {
            //Action Result para eliminar en la tabla <XDeclarationProgram> el registro
            oService.Eliminar(dato);
            return RedirectToAction("Declaration_Programs");
        }
    }
}