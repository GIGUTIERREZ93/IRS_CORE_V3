using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public void Insertar_Documento_Servicio(Document doc)
        {
            db.Documents.Add(doc);
            db.SaveChanges();
        }

    }
}