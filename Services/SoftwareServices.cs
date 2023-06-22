using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRS.Models;

namespace IRS.Services
{
    public class SoftwareServices
    {
        public List<Master_SW> Get_Software()
        {
            ITDBEntities db = new ITDBEntities();

            var result = db.Master_SW.ToList();

            return result;

        }
    }
}