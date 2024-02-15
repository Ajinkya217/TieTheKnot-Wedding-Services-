using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TieTheKnot.Data;
using TieTheKnot.Models;

namespace TieTheKnot.Controllers
{
    public class AdminVendorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminVendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminVendor
        public async Task<IActionResult> Index()
        {
              return _context.VendorInfo != null ? 
                          View(await _context.VendorInfo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.VendorInfo'  is null.");
        }

        // GET: AdminVendor/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.VendorInfo == null)
            {
                return NotFound();
            }

            var vendorInfo = await _context.VendorInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorInfo == null)
            {
                return NotFound();
            }

            return View(vendorInfo);
        }

        // GET: AdminVendor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminVendor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendorName,GstNumber,City,Facility,Charges,PictureLinks")] VendorInfo vendorInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorInfo);
        }

        // GET: AdminVendor/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.VendorInfo == null)
            {
                return NotFound();
            }

            var vendorInfo = await _context.VendorInfo.FindAsync(id);
            if (vendorInfo == null)
            {
                return NotFound();
            }
            return View(vendorInfo);
        }

        // POST: AdminVendor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,VendorName,GstNumber,City,Facility,Charges,PictureLinks")] VendorInfo vendorInfo)
        {
            if (id != vendorInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorInfoExists(vendorInfo.Id))
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
            return View(vendorInfo);
        }

        // GET: AdminVendor/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.VendorInfo == null)
            {
                return NotFound();
            }

            var vendorInfo = await _context.VendorInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorInfo == null)
            {
                return NotFound();
            }

            return View(vendorInfo);
        }

        // POST: AdminVendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.VendorInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VendorInfo'  is null.");
            }
            var vendorInfo = await _context.VendorInfo.FindAsync(id);
            if (vendorInfo != null)
            {
                _context.VendorInfo.Remove(vendorInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorInfoExists(long id)
        {
          return (_context.VendorInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
