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
    public class TaikhoansController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public TaikhoansController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Taikhoans
        public async Task<IActionResult> Index()
        {
            var websiteSPcongngheContext = _context.Taikhoan.Include(t => t.Quyenhans);
            return View(await websiteSPcongngheContext.ToListAsync());
        }

        // GET: Admin/Taikhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taikhoan == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoan
                .Include(t => t.Quyenhans)
                .FirstOrDefaultAsync(m => m.TaikhoanID == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // GET: Admin/Taikhoans/Create
        public IActionResult Create()
        {
            ViewData["QuyenhanID"] = new SelectList(_context.Quyenhan, "QuyenhanID", "QuyenhanID");
            return View();
        }

        // POST: Admin/Taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaikhoanID,Tendangnhap,Matkhau,HovaTen,Diachi,Sodt,Email,QuyenhanID")] Taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taikhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuyenhanID"] = new SelectList(_context.Quyenhan, "QuyenhanID", "QuyenhanID", taikhoan.QuyenhanID);
            return View(taikhoan);
        }

        // GET: Admin/Taikhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taikhoan == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoan.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            ViewData["QuyenhanID"] = new SelectList(_context.Quyenhan, "QuyenhanID", "QuyenhanID", taikhoan.QuyenhanID);
            return View(taikhoan);
        }

        // POST: Admin/Taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaikhoanID,Tendangnhap,Matkhau,HovaTen,Diachi,Sodt,Email,QuyenhanID")] Taikhoan taikhoan)
        {
            if (id != taikhoan.TaikhoanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaikhoanExists(taikhoan.TaikhoanID))
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
            ViewData["QuyenhanID"] = new SelectList(_context.Quyenhan, "QuyenhanID", "QuyenhanID", taikhoan.QuyenhanID);
            return View(taikhoan);
        }

        // GET: Admin/Taikhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taikhoan == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoan
                .Include(t => t.Quyenhans)
                .FirstOrDefaultAsync(m => m.TaikhoanID == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // POST: Admin/Taikhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taikhoan == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Taikhoan'  is null.");
            }
            var taikhoan = await _context.Taikhoan.FindAsync(id);
            if (taikhoan != null)
            {
                _context.Taikhoan.Remove(taikhoan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaikhoanExists(int id)
        {
          return (_context.Taikhoan?.Any(e => e.TaikhoanID == id)).GetValueOrDefault();
        }
    }
}
