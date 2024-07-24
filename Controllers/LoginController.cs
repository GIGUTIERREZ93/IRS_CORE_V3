using IRS.Models;
using IRS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public ActionResult Registrar(CBSEntities1 obj_usuarios, Usuario_confirmar confirmar)
        {
            bool registrado;
            string mensaje = "", password = "dfdsf", mail = "dsfdsfsd";

            var dato = ( from x in obj_usuarios.Usuarios
                         where x.Password == confirmar.ConfirmarClave
                         select new
                         {
                             x.Password,
                             x.Id_Usuario

                         }).FirstOrDefault();

            if(dato.Password == confirmar.ConfirmarClave )
            {
                password = ConvertirSha256(dato.Password);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            try
            {
                CBSEntities1 cb = new CBSEntities1();
                ObjectParameter obj_registrado = new ObjectParameter("Registrado", typeof(bool));
                ObjectParameter obj_message = new ObjectParameter("Message", typeof(string));
                cb.sp_RegistrarUsuarios(mail, password, obj_registrado, obj_message);
                cb.SaveChanges();

                registrado = Convert.ToBoolean(obj_registrado.Value);
                mensaje = obj_message.Value.ToString();

                ViewData["Mensaje"] = mensaje;

                return View();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            
        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create()) 
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach(byte b in result ) 
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}