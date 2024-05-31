using IRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace IRS.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(ITDBEntities obj_usuarios)
        {
            bool registradro;
            string mensaje;
            var model = obj_usuarios.Users.ToList();


            return View();
        }
    }
}