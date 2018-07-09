using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravPense.Data;
using TravPense.Models;

namespace TravPense.Controllers
{
    public class locationtypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public locationtypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: locationtypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.loctypes.ToListAsync());
        }

        // GET: locationtypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationtype = await _context.loctypes
                .SingleOrDefaultAsync(m => m.locid == id);
            if (locationtype == null)
            {
                return NotFound();
            }

            return View(locationtype);
        }

        // GET: locationtypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: locationtypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("locid,Loctype")] locationtype locationtype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationtype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationtype);
        }

        // GET: locationtypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationtype = await _context.loctypes.SingleOrDefaultAsync(m => m.locid == id);
            if (locationtype == null)
            {
                return NotFound();
            }
            return View(locationtype);
        }

        // POST: locationtypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("locid,Loctype")] locationtype locationtype)
        {
            if (id != locationtype.locid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationtype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!locationtypeExists(locationtype.locid))
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
            return View(locationtype);
        }

        // GET: locationtypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationtype = await _context.loctypes
                .SingleOrDefaultAsync(m => m.locid == id);
            if (locationtype == null)
            {
                return NotFound();
            }

            return View(locationtype);
        }

        // POST: locationtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationtype = await _context.loctypes.SingleOrDefaultAsync(m => m.locid == id);
            _context.loctypes.Remove(locationtype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool locationtypeExists(int id)
        {
            return _context.loctypes.Any(e => e.locid == id);
        }
    }
}
