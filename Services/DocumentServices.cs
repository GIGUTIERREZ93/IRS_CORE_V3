using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRS.Models;
using IRS.Models.ViewModels;

namespace IRS.Services
{
    public class DocumentServices
    {
        readonly ITDBEntities db= new ITDBEntities();
        public List<Document> Mostrar_Documentos()
        {
            var docu =db.Documents.ToList();
            return docu;
        }

    }
}