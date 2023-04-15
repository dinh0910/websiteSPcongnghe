using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using websiteSPcongnghe.Data;
using websiteSPcongnghe.Models;

namespace websiteSPcongnghe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhmucsController : Controller
    {
        private readonly websiteSPcongngheContext _context;
        private readonly INotyfService _notifyService;

        public DanhmucsController(websiteSPcongngheContext context, INotyfService notyfService)
        {
            _context = context;
            _notifyService = notyfService;
        }

        // GET: Admin/Danhmucs
        public async Task<IActionResult> Index()
        {
              return _context.Danhmuc != null ? 
                          View(await _context.Danhmuc.ToListAsync()) :
                          Problem("Entity set 'websiteSPcongngheContext.Danhmuc'  is null.");
        }

        // GET: Admin/Danhmucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhmucID,Tendanhmuc")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhmuc);
                _notifyService.Error("Thêm danh mục thành công!");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhmuc);
        }

        // GET: Admin/Danhmucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Danhmuc == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/Danhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanhmucID,Tendanhmuc")] Danhmuc danhmuc)
        {
            if (id != danhmuc.DanhmucID)
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
                    if (!DanhmucExists(danhmuc.DanhmucID))
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

        // GET: Admin/Danhmucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/Danhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool DanhmucExists(int id)
        {
          return (_context.Danhmuc?.Any(e => e.DanhmucID == id)).GetValueOrDefault();
        }
    }
}
