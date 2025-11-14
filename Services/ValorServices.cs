using IRS.Models;
using IRS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Services.Description;

namespace IRS.Services
{
    public class ValorServices
    {
        readonly vManageEntities db = new vManageEntities();
        readonly RADServerEntities1 db_rad = new RADServerEntities1();
        
        public List <DeviceTrace> ComponentAndPCBService(string busqueda)
        {
            string query;
            if (busqueda == "1")
            {
                //Tabla que muestra los prmieros 200 registros de la tabla DeviceTrace sin filtro
                query = "SELECT TOP (200) [DeviceID],[McID],[Station],[Slot],[SubSlot],[CompID],[BlockNo],[CompType],[InsertDate] FROM [vManage].[dbo].[DeviceTrace] ORDER BY InsertDate DESC";
            }
            else
            {
                //Tabla que muestra los registros filtrados por CompID
                query = "SELECT [DeviceID],[McID],[Station],[Slot],[SubSlot],[CompID],[BlockNo],[CompType],[InsertDate] FROM [vManage].[dbo].[DeviceTrace] WHERE (CompID='" + busqueda + "') ORDER BY InsertDate DESC";
            }
            var result = db.DeviceTrace.Take(200).OrderByDescending(x => x.InsertDate).ToList();
            return result;

        }
        //DECLARACION
        public List<XDeclarationProgram> xDeclaration_Programs()
        {
            var result = db.XDeclarationProgram.ToList();
            return result;
        }
        public List<CompList> ComponentTrace1(string busqueda)
        {

            string query;
            if (busqueda == "1")
            {
                //Tabla que muestra los prmieros 200 registros de la tabla CompList sin filtro
                query = "SELECT TOP (200) [CompID],[FeederID],[CompName],[OpenTimeStamp],[NumDryLeft],[McID],[Station],[Slot],[SubSlot],[Used],[Errors],[Amount],[Correction],[Status],[CompPrPCB],[DryTimeStamp],[PreparationStatus],[LastSeenOnMachine],[BookingMcid],[BookingStation],[BookingSlot],[BookingSubslot],[ExpirationDate],[IdentifierStatus] FROM [vManage].[dbo].[CompList] ORDER BY DryTimeStamp DESC";
            }
            else
            {
                //Tabla que muestra los registros filtrados por CompID
                query = "SELECT [CompID],[FeederID],[CompName],[OpenTimeStamp],[NumDryLeft],[McID],[Station],[Slot],[SubSlot],[Used],[Errors],[Amount],[Correction],[Status],[CompPrPCB],[DryTimeStamp],[PreparationStatus],[LastSeenOnMachine],[BookingMcid],[BookingStation],[BookingSlot],[BookingSubslot],[ExpirationDate],[IdentifierStatus] FROM [vManage].[dbo].[CompList] WHERE (SerialNumber='" + busqueda + "') ORDER BY DryTimeStamp DESC";
            }
            var result = db.CompList.Take(200).OrderByDescending(x => x.DryTimeStamp).ToList();
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
                PzsHr = model.PzsHr,
                Assy_Line = model.Assy_Line,
                Active = true
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
            update_model.Assy_Line = model.Assy_Line;
            update_model.Active=model.Active;

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
            var model = db.X_Mail.Where(x =>x.Planta =="AGUAS").Take(100).OrderByDescending(y => y.TimeDate).ToList();
            
            return (model);
        }

        //ERRORES DE DECLARACION
        public List<Z_Mail> Declaration_Errors()
        {
            var result = (from x in db_rad.Z_Mail 
                           where (x.Referencia == "None" || x.Referencia == "Error")
                           orderby x.TimeDate descending
                           select x).Take(100).ToList();
            return result;
        }
    }
}