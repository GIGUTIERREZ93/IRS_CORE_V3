using IRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Services
{
    public class ValorServices
    {
        readonly vManageEntities1 db = new vManageEntities1();
        public List<XDeclarationProgram> xDeclaration_Programs()
        {
            /*var result1 = (from x in db.XDeclarationProgram
                           select new
                           {
                               x.McID,
                               x.Program,
                               x.Noblock,
                               x.NIP,
                               x.Suffix,
                               x.PartNumber,
                               x.Line,
                               x.CycleTime,
                               x.PzsHr
                           }).ToList();
            */
            var result = db.XDeclarationProgram.ToList();
            return result;
        }

        public void Insertar(XDeclarationProgram model)
        {
            var std = new XDeclarationProgram()
            {
                McID = model.McID,
                Program = model.Program,
                Noblock = model.Noblock,
                NIP = model.NIP,
                Suffix = model.Suffix,
                PartNumber = model.PartNumber,
                Line = model.Line,
                CycleTime = model.CycleTime,
                PzsHr = model.PzsHr
            };
            db.XDeclarationProgram.Add(std);
            db.SaveChanges();
        }

        public XDeclarationProgram Editar(long RecordID)
        {
            var model =( from monitor in db.XDeclarationProgram.Where(x => x.RecordID==RecordID) select monitor).FirstOrDefault();
            return model;

        }
        public XDeclarationProgram Editar_Form(XDeclarationProgram model) 
        {
            var update_model = (from monitor in db.XDeclarationProgram
                          where monitor.RecordID == model.RecordID
                          select monitor).FirstOrDefault();

            update_model.McID = model.McID;
            update_model.Program = model.Program;
            update_model.Noblock = model.Noblock;
            update_model.NIP = model.NIP;
            update_model.Suffix = model.Suffix;
            update_model.PartNumber = model.PartNumber;
            update_model.Line = model.Line;
            update_model.CycleTime = model.CycleTime;
            update_model.PzsHr = model.PzsHr;

            db.SaveChanges();
            return update_model;

        }

        public void Eliminar(long dato)
        {
            var del_model = (from monitor in db.XDeclarationProgram
                             where monitor.RecordID == dato
                             select monitor).FirstOrDefault();
            if (del_model != null) 
            {
                db.XDeclarationProgram.Remove(del_model);
                db.SaveChanges();
            }
        }

        public List<X_Mail> LogErrores() 
        {
            var model = db.X_Mail.Where(x =>x.Maquina =="AUDI Q5").Take(100).OrderByDescending(y => y.TimeDate).ToList();
            return (model);
        }
    }
}