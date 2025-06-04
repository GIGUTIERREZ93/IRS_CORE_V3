using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRS.Models;
using IRS.Models.ViewModels.LineTracking;
using IRS.Services.LineTracking;

namespace IRS.Controllers
{
    public class LineTrackingController : Controller
    {
        // GET: LineTracking
        public ActionResult Index()
        {
            GetinfoService getinfo = new GetinfoService();
            //ViewBag.Lista = getinfo.Get_Status();
            var Lista= getinfo.Get_Status();

            //ViewBag.Lista_BackEnd = getinfo.Get_StatusAssy();
            //var Lista_BackEnd = getinfo.Get_StatusAssy();

            ViewBag.Lista_Servicios=getinfo.Get_Services_Status();
            
            return View(Lista);
        }

        public ActionResult OeeSMT(string mcid, DateTime date)
        {
            /* CBSEntities db = new CBSEntities();
             var turno=db.Database.SqlQuery<int>("exec TurnoA").FirstOrDefault();
             ViewBag.turno = turno;*/

            vManageEntities db2 = new vManageEntities();
            var day = DateTime.Now;
            var dia = day.ToString("yyyy-MM-dd");
            var dia3 = day.AddDays(-1).ToString("yyyy-MM-dd");
            ViewBag.turno1 = db2.XOEE_Details_Per_Hour.Where(x => x.McID == 9004 && x.TurnoID==1 && x.TimeDate.ToString()==dia ).ToList();
            ViewBag.turno2 = db2.XOEE_Details_Per_Hour.Where(x => x.McID == 9004 && x.TurnoID == 2 && x.TimeDate.ToString() == dia).ToList();
            ViewBag.turno3 = db2.XOEE_Details_Per_Hour.Where(x => x.McID == 9004 && x.TurnoID == 3 && x.TimeDate.ToString() == dia3).ToList();


            return View();
        }
    }
}