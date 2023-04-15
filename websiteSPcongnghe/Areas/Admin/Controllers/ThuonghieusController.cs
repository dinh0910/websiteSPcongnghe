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
    public class ThuonghieusController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public ThuonghieusController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Thuonghieus
        public async Task<IActionResult> Index()
        {
              return _context.Thuonghieu != null ? 
                          View(await _context.Thuonghieu.ToListAsync()) :
                          Problem("Entity set 'websiteSPcongngheContext.Thuonghieu'  is null.");
        }

        // GET: Admin/Thuonghieus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Thuonghieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThuonghieuID,Tenthuonghieu")] Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuonghieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuonghieu);
        }

        // GET: Admin/Thuonghieus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thuonghieu == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }
            return View(thuonghieu);
        }

        // POST: Admin/Thuonghieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThuonghieuID,Tenthuonghieu")] Thuonghieu thuonghieu)
        {
            if (id != thuonghieu.ThuonghieuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuonghieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuonghieuExists(thuonghieu.ThuonghieuID))
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
            return View(thuonghieu);
        }

        // GET: Admin/Thuonghieus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thuonghieu == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu
                .FirstOrDefaultAsync(m => m.ThuonghieuID == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // POST: Admin/Thuonghieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thuonghieu == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Thuonghieu'  is null.");
            }
            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            if (thuonghieu != null)
            {
                _context.Thuonghieu.Remove(thuonghieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuonghieuExists(int id)
        {
          return (_context.Thuonghieu?.Any(e => e.ThuonghieuID == id)).GetValueOrDefault();
        }
    }
}
