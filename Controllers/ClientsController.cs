using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuslinkOperatingSupport.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index(String name,int numT=0)
        {
            ViewData["msg"] = "Hello" + name;
            ViewData["numt"] = numT;
            return View();
        }
    }
}
