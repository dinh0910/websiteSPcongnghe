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
    public class DonvitinhsController : Controller
    {
        private readonly websiteSPcongngheContext _context;

        public DonvitinhsController(websiteSPcongngheContext context)
        {
            _context = context;
        }

        // GET: Admin/Donvitinhs
        public async Task<IActionResult> Index()
        {
              return _context.Donvitinh != null ? 
                          View(await _context.Donvitinh.ToListAsync()) :
                          Problem("Entity set 'websiteSPcongngheContext.Donvitinh'  is null.");
        }

        // GET: Admin/Donvitinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donvitinh == null)
            {
                return NotFound();
            }

            var donvitinh = await _context.Donvitinh
                .FirstOrDefaultAsync(m => m.DonvitinhID == id);
            if (donvitinh == null)
            {
                return NotFound();
            }

            return View(donvitinh);
        }

        // GET: Admin/Donvitinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Donvitinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonvitinhID,Ten")] Donvitinh donvitinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donvitinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donvitinh);
        }

        // GET: Admin/Donvitinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donvitinh == null)
            {
                return NotFound();
            }

            var donvitinh = await _context.Donvitinh.FindAsync(id);
            if (donvitinh == null)
            {
                return NotFound();
            }
            return View(donvitinh);
        }

        // POST: Admin/Donvitinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonvitinhID,Ten")] Donvitinh donvitinh)
        {
            if (id != donvitinh.DonvitinhID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donvitinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonvitinhExists(donvitinh.DonvitinhID))
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
            return View(donvitinh);
        }

        // GET: Admin/Donvitinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donvitinh == null)
            {
                return NotFound();
            }

            var donvitinh = await _context.Donvitinh
                .FirstOrDefaultAsync(m => m.DonvitinhID == id);
            if (donvitinh == null)
            {
                return NotFound();
            }

            return View(donvitinh);
        }

        // POST: Admin/Donvitinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donvitinh == null)
            {
                return Problem("Entity set 'websiteSPcongngheContext.Donvitinh'  is null.");
            }
            var donvitinh = await _context.Donvitinh.FindAsync(id);
            if (donvitinh != null)
            {
                _context.Donvitinh.Remove(donvitinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonvitinhExists(int id)
        {
          return (_context.Donvitinh?.Any(e => e.DonvitinhID == id)).GetValueOrDefault();
        }
    }
}
