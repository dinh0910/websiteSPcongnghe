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
    public class QuyenhansController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public QuyenhansController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Quyenhans
        public async Task<IActionResult> Index()
        {
              return _context.Quyenhan != null ? 
                          View(await _context.Quyenhan.ToListAsync()) :
                          Problem("Entity set 'websiteSPcongngheContext.Quyenhan'  is null.");
        }

        // GET: Admin/Quyenhans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Quyenhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuyenhanID,Quyen")] Quyenhan quyenhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quyenhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quyenhan);
        }

        // GET: Admin/Quyenhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quyenhan == null)
            {
                return NotFound();
            }

            var quyenhan = await _context.Quyenhan.FindAsync(id);
            if (quyenhan == null)
            {
                return NotFound();
            }
            return View(quyenhan);
        }

        // POST: Admin/Quyenhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuyenhanID,Quyen")] Quyenhan quyenhan)
        {
            if (id != quyenhan.QuyenhanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quyenhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuyenhanExists(quyenhan.QuyenhanID))
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
            return View(quyenhan);
        }

        // GET: Admin/Quyenhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quyenhan == null)
            {
                return NotFound();
            }

            var quyenhan = await _context.Quyenhan
                .FirstOrDefaultAsync(m => m.QuyenhanID == id);
            if (quyenhan == null)
            {
                return NotFound();
            }

            return View(quyenhan);
        }

        // POST: Admin/Quyenhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quyenhan == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Quyenhan'  is null.");
            }
            var quyenhan = await _context.Quyenhan.FindAsync(id);
            if (quyenhan != null)
            {
                _context.Quyenhan.Remove(quyenhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuyenhanExists(int id)
        {
          return (_context.Quyenhan?.Any(e => e.QuyenhanID == id)).GetValueOrDefault();
        }
    }
}
