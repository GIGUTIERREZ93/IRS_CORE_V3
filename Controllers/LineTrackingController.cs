using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult OeeSMT()
        {
            return View();
        }
    }
}