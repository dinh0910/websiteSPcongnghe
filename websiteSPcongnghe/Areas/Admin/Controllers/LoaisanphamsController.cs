using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using websiteSPcongnghe.Data;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaisanphamsController : Controller
    {
        private readonly websiteSPcongngheContext _context;
        private readonly INotyfService _notifyService;

        public LoaisanphamsController(websiteSPcongngheContext context, INotyfService notyfService)
        {
            _context = context;
            _notifyService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Loaisanpham != null ?
                        View(await _context.Loaisanpham.OrderByDescending(l => l.LoaisanphamID).ToListAsync()) :
                        Problem("Entity set 'websiteSPcongngheContext.Loaisanpham'  is null.");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaisanphamID,Ten")] Loaisanpham lsp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lsp);
                _notifyService.Success("Thêm loại sản phẩm thành công!");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lsp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Loaisanpham == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Loaisanpham.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            return View(danhmuc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaisanphamID,Ten")] Loaisanpham danhmuc)
        {
            if (id != danhmuc.LoaisanphamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhmuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucExists(danhmuc.LoaisanphamID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(danhmuc);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Loaisanpham == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Loaisanpham
                .FirstOrDefaultAsync(m => m.LoaisanphamID == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Loaisanpham == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Loaisanpham'  is null.");
            }
            var danhmuc = await _context.Loaisanpham.FindAsync(id);
            if (danhmuc != null)
            {
                _context.Loaisanpham.Remove(danhmuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhmucExists(int id)
        {
            return (_context.Loaisanpham?.Any(e => e.LoaisanphamID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Details(int? id)
        {
            var sp = _context.Loaisanpham.FirstOrDefault(s => s.LoaisanphamID == id);
            ViewBag.danhmuc = _context.Danhmuc;
            return View(sp);
        }

        public IActionResult CreateMenu(int? id)
        {
            var l = _context.Loaisanpham.FirstOrDefault(lsp => lsp.LoaisanphamID == id);
            return View(l);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMenu(int id, [Bind("DanhmucID,LoaisanphamID,Tendanhmuc")] Danhmuc dm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dm);
                _notifyService.Success("Thêm danh mục thành công!");
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", "Loaisanphams", routeValues: new { id });
        }

        public IActionResult EditMenu(int? id)
        {
            var l = _context.Danhmuc.Include(l => l.Loaisanphams).FirstOrDefault(lsp => lsp.DanhmucID == id);
            return View(l);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMenu(int id, [Bind("DanhmucID,LoaisanphamID,Tendanhmuc")] Danhmuc dm)
        {
            if (ModelState.IsValid)
            {
                _context.Update(dm);
                _notifyService.Success("Sửa danh mục thành công!");
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", "Loaisanphams", routeValues: new { id });
        }


        public async Task<IActionResult> DeleteMenu(int? id)
        {
            if (id == null || _context.Danhmuc == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.DanhmucID == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        [HttpPost, ActionName("DeleteMenu")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMenuConfirmed(int id)
        {
            if (_context.Danhmuc == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Danhmuc'  is null.");
            }
            var danhmuc = await _context.Danhmuc.FindAsync(id);
            if (danhmuc != null)
            {
                _context.Danhmuc.Remove(danhmuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
