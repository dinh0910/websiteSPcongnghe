using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using websiteSPcongnghe.Data;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanphamsController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public SanphamsController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Sanphams
        public async Task<IActionResult> Index()
        {
            var websiteSPcongngheContext = _context.Sanpham.Include(s => s.Danhmucs).Include(s => s.Thuonghieus);
            return View(await websiteSPcongngheContext.ToListAsync());
        }

        // GET: Admin/Sanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Danhmucs)
                .Include(s => s.Thuonghieus)
                .FirstOrDefaultAsync(m => m.SanphamID == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Admin/Sanphams/Create
        public IActionResult Create()
        {
            ViewData["DanhMucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "DanhmucID");
            ViewData["ThuongHieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "ThuonghieuID");
            return View();
        }

        // POST: Admin/Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SanphamID,Tensanpham,DanhMucID,ThuongHieuID,Hinhanh,Dongia,Sale,Thanhtien,Soluong")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "DanhmucID", sanpham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "ThuonghieuID", sanpham.ThuongHieuID);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["DanhMucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "DanhmucID", sanpham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "ThuonghieuID", sanpham.ThuongHieuID);
            return View(sanpham);
        }

        // POST: Admin/Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanphamID,Tensanpham,DanhMucID,ThuongHieuID,Hinhanh,Dongia,Sale,Thanhtien,Soluong")] Sanpham sanpham)
        {
            if (id != sanpham.SanphamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.SanphamID))
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
            ViewData["DanhMucID"] = new SelectList(_context.Danhmuc, "DanhmucID", "DanhmucID", sanpham.DanhMucID);
            ViewData["ThuongHieuID"] = new SelectList(_context.Thuonghieu, "ThuonghieuID", "ThuonghieuID", sanpham.ThuongHieuID);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sanpham == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.Danhmucs)
                .Include(s => s.Thuonghieus)
                .FirstOrDefaultAsync(m => m.SanphamID == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Admin/Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sanpham == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Sanpham'  is null.");
            }
            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham != null)
            {
                _context.Sanpham.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
          return (_context.Sanpham?.Any(e => e.SanphamID == id)).GetValueOrDefault();
        }
    }
}
