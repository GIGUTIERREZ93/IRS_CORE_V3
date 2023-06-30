using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRS.Models;
using IRS.Models.ViewModels;

namespace IRS.Services
{
    
    public class HardwareService
    {
        readonly ITDBEntities db = new ITDBEntities();
        public List<HW_Model_Join> Consultar_Hardware()
        {
            var hardware = db.Master_HW.ToList();
            var modelos = (from model in db.HW_MODEL select model).ToList();
            var result = hardware.Join(modelos, h => h.ModelID, m => m.ModelID, (hard, model) =>
                     {
                         return new HW_Model_Join
                         {
                             Modelo = model.Model,
                             SerialNumber = hard.SerialNumber,
                             AssetTag=hard.AssetTag,
                             Vendor=hard.Vendor,
                             Type=hard.Type,
                             Location=hard.Location,
                             Status=hard.Status,
                             Comments=hard.Comments,
                             Operator=hard.Operator

                         };
            }).ToList();

           
            return result;
        }
        
        public List<Anexos> Obtener_Anexos()
        {
            string query = "select * from Anexos";
            var result = db.Database.SqlQuery<Anexos>(query).ToList();

            return result;
        }
       
      


    }
}