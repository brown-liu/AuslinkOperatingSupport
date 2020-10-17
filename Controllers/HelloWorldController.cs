using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuslinkOperatingSupport.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String Welcome(string name,int num)
        {
            return HtmlEncoder.Default.Encode($"Hi, welcome {name}, this is your {num} time visit today");
        }

    }
}
