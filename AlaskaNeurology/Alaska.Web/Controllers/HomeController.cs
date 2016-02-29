using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Alaska.DB.Infrastructure;

namespace Alaska.Web.Controllers
{
    public class HomeController : Controller
    {

        private UnitOfWork _unitOfWork;
        public HomeController(UnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public IActionResult Index()
        {
            var a = "NAsir";
            return View("Index", a);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            string op=_unitOfWork.ScreenRepo.GenerateScreenLayout();
            return View("About",op);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult SmartGrid()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
