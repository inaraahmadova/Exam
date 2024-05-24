using Exam9.DataAccesLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exam9.Controllers
{
    public class HomeController (ServiceContext _context): Controller
    {

        public async Task<IActionResult> Index()
        {
            return View(await _context.services.ToListAsync());
        }

    }
}
