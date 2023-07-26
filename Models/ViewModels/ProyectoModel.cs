using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRS.Models.ViewModels
{ 
public class Proyecto : Controller
{
    public string ProjectName { get; set; }
    public string Site { get; set; }
    public string Departament { get; set; }
    public string ProjectLeader { get; set; }
    public string Approved { get; set; }
    public string Details { get; set; }

}
}