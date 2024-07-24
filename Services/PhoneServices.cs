using IRS.Models;
using IRS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IRS.Services
{
    public class PhoneServices
    {
        readonly ITDBEntities db = new ITDBEntities();

      
        public List<ConsultaCelularUsuario_ActivosHd>ConsultarCelulares()
        {
            //Creando la vista
            List<ConsultaCelularUsuario_ActivosHd> mi_lista = new List<ConsultaCelularUsuario_ActivosHd>();

            //De que tabla quiero obtener informacion en otra tabla
            //declarar
            var celulares = db.PhoneMasters.ToList();

            foreach (var x in celulares) 
            {
                ConsultaCelularUsuario_ActivosHd telefono = new ConsultaCelularUsuario_ActivosHd();
                //crear una variable de otra tabla para el match de los datos
                var Usuario=(from user in db.Employees where user.EmpID==x.EmpID select user).FirstOrDefault();
                if (Usuario == null)
                {
                    telefono.FullName = "Disponible";
                    telefono.Depa = "";

                }
                else
                {
                    telefono.FullName = Usuario.FullName;
                    telefono.Depa = Usuario.Depa;

                }

                telefono.PhoneID =(x.PhoneID.ToString());
                
                mi_lista.Add(telefono); 
            }
            return mi_lista;

            
        }
        
    }


     
}