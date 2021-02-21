using Autofac;
using Joachim_Johnson_ConsidAplication.Interfaces;
using System;
using System.Web.Mvc;

namespace Joachim_Johnson_ConsidAplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IAplication>();
                app.Run();
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title        = "Contact Info";
            ViewBag.Message      = "Joachim Johnson contact info";

            ViewBag.PhoneNumber  = "0738241837";
            ViewBag.Linkedin     = "https://www.linkedin.com/in/joachim-johnson-913389133/";

            ViewBag.Email        = "Joachim@Johnsons.nu";
            ViewBag.Gmail        = "Joachim.johnson.jj@gmail.com";

            return View();
        }
    }
}