using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using IRS.Models;


namespace IRS.Services
{


    public class DocumentServices
    {
        readonly ITDBEntities db = new ITDBEntities();

        public List<Document> Mostrar_Documentos()
        {
            var model=(from Document in  db.Documents select Document).ToList();
            return model;
        }

        public void Insertar_Documento_servicio(HttpPostedFileBase DocumentName, string Area, string Topic, string DocType)
        {
            Guardar_Archivo(DocumentName);
            db.SaveChanges();

           
             
        }
        public void Guardar_Archivo(HttpPostedFileBase DocumentName)
        {
            string rutaserver = System.Web.HttpContext.Current.Server.MapPath("~/");
            string folder = Path.Combine(rutaserver + "ICT\\Documents\\");

        }

    }
}