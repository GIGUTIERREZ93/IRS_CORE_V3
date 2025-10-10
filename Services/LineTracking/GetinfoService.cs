using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using IRS.Models;
using IRS.Models.ViewModels.LineTracking;

using Microsoft.Ajax.Utilities;


namespace IRS.Services.LineTracking
{
    public class GetinfoService
    {
         CBSEntities db = new CBSEntities();
         vManageEntities db2 = new vManageEntities();

        public List<Smt_StatusViewModel> Get_Status()
        {
            List<Smt_StatusViewModel> Lista = new List<Smt_StatusViewModel>();
            Smt_StatusViewModel Status;
            var lineas = db.Lines.Where(d => d.LineName.Contains("SMT")).ToList();

            foreach (var line in lineas)
            {
                Status= new Smt_StatusViewModel();
                DateTime current = DateTime.Now;
                var Datos_linea=db.Database.SqlQuery<FileScannerViewModel>("SELECT LineID, ISnull(Marker,'2024-01-01')as Marker,ISnull(SPI,'2024-01-01')as [SPI],ISnull(AOI,'2024-01-01')as [AOI],ISnull([AssyFiles],'2024-01-01')as [AssyFiles] ,[Area],[Active],'0' as [IDSPI]  FROM [CBS].[dbo].[FileScannerMonitor]  where LineID='" + line.LineID+"'").FirstOrDefault();
                if (Datos_linea != null)
                {
                    //var order = 
                    var D_marcadora = (current.Subtract(Datos_linea.Marker)).Minutes;
                    var D_spi = (current.Subtract(Datos_linea.SPI)).Minutes;
                    var D_aoi = (current.Subtract(Datos_linea.AOI)).Minutes;
                    var top = db2.ActPCBList.Where(d => d.McID == line.LineID && d.Lane == 1).Count();
                    var bot = db2.ActPCBList.Where(d => d.McID == line.LineID && d.Lane == 2).Count();
                    var serial = db2.ActPCBList.Where((d) => d.McID == line.LineID).OrderByDescending(d => d.Timestamp).FirstOrDefault();
                    var serial_f = "";
                    var orden = "ORDEN DESCONOCIDA";
                    if (serial != null)
                    {
                        serial_f = serial.RawBarcode.ToString() + " " + serial.Timestamp.ToString();
                        orden = db2.Database.SqlQuery<string>("select ISNull(orderNo,'ORDEN DESCONOCIDA') as orderNo from PCBTrace where PCBId=@p0 and orderNo!='??' ", serial_f).FirstOrDefault();
                        
                        if ((orden.IsEmpty()) || (orden.Contains("")))
                        {
                            orden = "ORDEN DESCONOCIDA";
                        }
                    }



                    Status.Linea = line.LineName + " (" + line.LineID + ")";
                    Status.WO = orden;
                    Status.Marcadora = D_marcadora;
                    Status.SPI = D_spi;
                    Status.AOI = D_aoi;
                    Status.Marcadora_f = Datos_linea.Marker;
                    Status.SPI_f = Datos_linea.SPI;
                    Status.AOI_f = Datos_linea.AOI;
                    Status.Top = top;
                    Status.Bot = bot;
                    Status.Pick_place = serial_f;

                    Lista.Add(Status);
                }

            }

            return Lista;
        
        }
        public List<BackEnd_StatusViewModel> Get_StatusAssy()
        {
            List<BackEnd_StatusViewModel> Lista_BackEnd = new List<BackEnd_StatusViewModel>();
            BackEnd_StatusViewModel StatusAssy;
            var lineas_Assy = db.Lines.Where(a => a.LineType.Contains("Assy")).ToList();


            foreach (var lineAssy in lineas_Assy)
            {
                
                    StatusAssy = new BackEnd_StatusViewModel();
                    DateTime current = DateTime.Now;
                    var Datos_Assy = db.Database.SqlQuery<FileScannerViewModel>("SELECT LineID, [Area],[Active],'0' as [IDSPI], ISnull([AssyFiles],'2024-01-01')as [AssyFiles]  FROM [CBS].[dbo].[FileScannerMonitor]  where LineID='" + lineAssy.LineName + "'").FirstOrDefault();
                    if (Datos_Assy != null)
                    {
                        var D_Assy = (current.Subtract(Datos_Assy.AssyFiles)).Minutes;
                    }
                    
                    StatusAssy.Linea_Assy =  lineAssy.LineName;
                    StatusAssy.Assy_F = Datos_Assy.AssyFiles;
                    StatusAssy.StatusAssy1 = lineAssy.LineType;
                                   
                    Lista_BackEnd.Add(StatusAssy);
            }

            return Lista_BackEnd; 
        }
        

        public List<Monitoring_Services> Get_Services_Status()
        {
            ITAplicationsEntities db = new ITAplicationsEntities();

            var result=db.Monitoring_Services.ToList();

            return result;
        }

    }
}