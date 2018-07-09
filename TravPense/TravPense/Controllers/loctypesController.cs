using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravPense.Data;
using TravPense.Models;

namespace TravPense.Controllers
{
    public class loctypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public loctypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "superadmin")]
        // GET: loctypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.loctypes.ToListAsync());
        }
        public async Task<IActionResult> UserView()
        {
            return View(await _context.destinations.ToListAsync());
        }

        // GET: loctypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loctype = await _context.loctypes
                .SingleOrDefaultAsync(m => m.id == id);
            if (loctype == null)
            {
                return NotFound();
            }

            return View(loctype);
        }

        // GET: loctypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: loctypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Loctype")] loctype loctype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loctype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loctype);
        }

        // GET: loctypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loctype = await _context.loctypes.SingleOrDefaultAsync(m => m.id == id);
            if (loctype == null)
            {
                return NotFound();
            }
            return View(loctype);
        }

        // POST: loctypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Loctype")] loctype loctype)
        {
            if (id != loctype.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loctype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!loctypeExists(loctype.id))
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
            return View(loctype);
        }

        // GET: loctypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loctype = await _context.loctypes
                .SingleOrDefaultAsync(m => m.id == id);
            if (loctype == null)
            {
                return NotFound();
            }

            return View(loctype);
        }

        // POST: loctypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loctype = await _context.loctypes.SingleOrDefaultAsync(m => m.id == id);
            _context.loctypes.Remove(loctype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loctypeExists(int id)
        {
            return _context.loctypes.Any(e => e.id == id);
        }
    }
}
