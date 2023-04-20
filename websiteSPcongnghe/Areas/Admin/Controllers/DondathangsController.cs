using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using websiteSPcongnghe.Data;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DondathangsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly websiteSPcongngheContext _context;

        public DondathangsController(ILogger<HomeController> logger, websiteSPcongngheContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Dondathang.ToListAsync());
        }

        // GET: Admin/DonDatHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dondathang == null)
            {
                return NotFound();
            }

            var donDatHang = await _context.Dondathang
                .FirstOrDefaultAsync(m => m.DondathangID == id);
            if (donDatHang == null)
            {
                return NotFound();
            }

            return View(donDatHang);
        }

        // POST: Admin/DonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dondathang == null)
            {
                return Problem("Entity set 'webbanlaptopContext.DonDatHang'  is null.");
            }
            var donDatHang = await _context.Dondathang.FindAsync(id);
            if (donDatHang != null)
            {
                _context.Dondathang.Remove(donDatHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var webbanlaptopContext = _context.Dathangchitiet
                .Include(c => c.Dondathang)
                .Include(c => c.Sanpham)
                .Where(m => m.DondathangID == id);

            ViewBag.ddh = _context.Dondathang.FirstOrDefault(d => d.DondathangID == id);

            return View(await webbanlaptopContext.ToListAsync());
        }

        private bool DonDatHangExists(int id)
        {
            return _context.Dondathang.Any(e => e.DondathangID == id);
        }
    }
}
