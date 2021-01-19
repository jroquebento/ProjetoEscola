using Escola.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
           return View();
        }
    }
}
