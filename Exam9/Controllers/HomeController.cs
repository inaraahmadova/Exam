using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam9.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
