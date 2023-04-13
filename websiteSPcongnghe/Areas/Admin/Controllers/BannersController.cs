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
    public class BannersController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public BannersController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Banners
        public async Task<IActionResult> Index()
        {
              return _context.DanhsachBanner != null ? 
                          View(await _context.DanhsachBanner.ToListAsync()) :
                          Problem("Entity set 'websiteSPcongngheContext.DanhsachBanner'  is null.");
        }

        // GET: Admin/Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhsachBanner == null)
            {
                return NotFound();
            }

            var danhsachBanner = await _context.DanhsachBanner
                .FirstOrDefaultAsync(m => m.DanhsachBannerID == id);
            if (danhsachBanner == null)
            {
                return NotFound();
            }

            return View(danhsachBanner);
        }

        // GET: Admin/Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhsachBannerID,Banner")] DanhsachBanner danhsachBanner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhsachBanner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhsachBanner);
        }

        // GET: Admin/Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhsachBanner == null)
            {
                return NotFound();
            }

            var danhsachBanner = await _context.DanhsachBanner.FindAsync(id);
            if (danhsachBanner == null)
            {
                return NotFound();
            }
            return View(danhsachBanner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanhsachBannerID,Banner")] DanhsachBanner danhsachBanner)
        {
            if (id != danhsachBanner.DanhsachBannerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhsachBanner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhsachBannerExists(danhsachBanner.DanhsachBannerID))
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
            return View(danhsachBanner);
        }

        // GET: Admin/Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhsachBanner == null)
            {
                return NotFound();
            }

            var danhsachBanner = await _context.DanhsachBanner
                .FirstOrDefaultAsync(m => m.DanhsachBannerID == id);
            if (danhsachBanner == null)
            {
                return NotFound();
            }

            return View(danhsachBanner);
        }

        // POST: Admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DanhsachBanner == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.DanhsachBanner'  is null.");
            }
            var danhsachBanner = await _context.DanhsachBanner.FindAsync(id);
            if (danhsachBanner != null)
            {
                _context.DanhsachBanner.Remove(danhsachBanner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhsachBannerExists(int id)
        {
          return (_context.DanhsachBanner?.Any(e => e.DanhsachBannerID == id)).GetValueOrDefault();
        }
    }
}
