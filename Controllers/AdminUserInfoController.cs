﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using TieTheKnot.Data;
//using TieTheKnot.Models;

//namespace TieTheKnot.Controllers
//{
//    public class AdminUserInfoController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public AdminUserInfoController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: AdminUserInfo
//        public async Task<IActionResult> Index()
//        {
//              return _context.UserInfo != null ? 
//                          View(await _context.UserInfo.ToListAsync()) :
//                          Problem("Entity set 'ApplicationDbContext.UserInfo'  is null.");
//        }

//        // GET: AdminUserInfo/Details/5
//        public async Task<IActionResult> Details(long? id)
//        {
//            if (id == null || _context.UserInfo == null)
//            {
//                return NotFound();
//            }

//            var userInfo = await _context.UserInfo
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (userInfo == null)
//            {
//                return NotFound();
//            }

//            return View(userInfo);
//        }

//        // GET: AdminUserInfo/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: AdminUserInfo/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,UserName,CateringServices,Decoration,City,PhotographyServices,WeddingDate,WeddingVenue")] UserInfo userInfo)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(userInfo);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userInfo);
//        }

//        // GET: AdminUserInfo/Edit/5
//        public async Task<IActionResult> Edit(long? id)
//        {
//            if (id == null || _context.UserInfo == null)
//            {
//                return NotFound();
//            }

//            var userInfo = await _context.UserInfo.FindAsync(id);
//            if (userInfo == null)
//            {
//                return NotFound();
//            }
//            return View(userInfo);
//        }

//        // POST: AdminUserInfo/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(long id, [Bind("Id,UserName,CateringServices,Decoration,City,PhotographyServices,WeddingDate,WeddingVenue")] UserInfo userInfo)
//        {
//            if (id != userInfo.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(userInfo);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UserInfoExists(userInfo.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userInfo);
//        }

//        // GET: AdminUserInfo/Delete/5
//        public async Task<IActionResult> Delete(long? id)
//        {
//            if (id == null || _context.UserInfo == null)
//            {
//                return NotFound();
//            }

//            var userInfo = await _context.UserInfo
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (userInfo == null)
//            {
//                return NotFound();
//            }

//            return View(userInfo);
//        }

//        // POST: AdminUserInfo/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(long id)
//        {
//            if (_context.UserInfo == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.UserInfo'  is null.");
//            }
//            var userInfo = await _context.UserInfo.FindAsync(id);
//            if (userInfo != null)
//            {
//                _context.UserInfo.Remove(userInfo);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UserInfoExists(long id)
//        {
//          return (_context.UserInfo?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}



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
    public class AdminUserInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminUserInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminUserInfo
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<UserInfo> userInfo = _context.UserInfo;

            if (!string.IsNullOrEmpty(searchString))
            {
                userInfo = userInfo.Where(u => u.UserName.Contains(searchString));
            }

            return View(await userInfo.ToListAsync());
        }

        // GET: AdminUserInfo/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.UserInfo == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // GET: AdminUserInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminUserInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,CateringServices,Decoration,City,PhotographyServices,WeddingDate,WeddingVenue")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        // GET: AdminUserInfo/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.UserInfo == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }
            return View(userInfo);
        }

        // POST: AdminUserInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserName,CateringServices,Decoration,City,PhotographyServices,WeddingDate,WeddingVenue")] UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInfoExists(userInfo.Id))
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
            return View(userInfo);
        }

        // GET: AdminUserInfo/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.UserInfo == null)
            {
                return NotFound();
            }

            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return View(userInfo);
        }

        // POST: AdminUserInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.UserInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserInfo'  is null.");
            }
            var userInfo = await _context.UserInfo.FindAsync(id);
            if (userInfo != null)
            {
                _context.UserInfo.Remove(userInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserInfoExists(long id)
        {
            return (_context.UserInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}