using Exam9.DataAccesLayer;
using Exam9.Models;
using Exam9.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam9.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController(ServiceContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.services.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceVM createServiceVM)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _context.services.AddAsync(
                new Service
                {
                    Title = createServiceVM.Title,
                    Subtitle = createServiceVM.Subtitle,
                    Icon = createServiceVM.Icon,
                });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var result = await _context.services.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return NotFound();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, CreateServiceVM createServiceVM)
        {
            if (id == null || id < 1) return BadRequest();
            var result = await _context.services.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return NotFound();
            result.Title = createServiceVM.Title;
            result.Subtitle = createServiceVM.Subtitle;
            result.Icon = createServiceVM.Icon;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            var result= await _context.services.FindAsync(id);
            if (result == null) return NotFound();
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
