using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravPense.Data;
using TravPense.Data.Model;

namespace TravPense.Controllers
{
    public class ActivityyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activityy
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.activityy.Include(a => a.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Activityy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityy = await _context.activityy
                .Include(a => a.Location)
                .SingleOrDefaultAsync(m => m.ActivityyId == id);
            if (activityy == null)
            {
                return NotFound();
            }

            return View(activityy);
        }

        // GET: Activityy/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.location, "LocationId", "LocationId");
            return View();
        }

        // POST: Activityy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityyId,ActivityName,LocationId")] Activityy activityy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.location, "LocationId", "LocationId", activityy.LocationId);
            return View(activityy);
        }

        // GET: Activityy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityy = await _context.activityy.SingleOrDefaultAsync(m => m.ActivityyId == id);
            if (activityy == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.location, "LocationId", "LocationId", activityy.LocationId);
            return View(activityy);
        }

        // POST: Activityy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityyId,ActivityName,LocationId")] Activityy activityy)
        {
            if (id != activityy.ActivityyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityyExists(activityy.ActivityyId))
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
            ViewData["LocationId"] = new SelectList(_context.location, "LocationId", "LocationId", activityy.LocationId);
            return View(activityy);
        }

        // GET: Activityy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityy = await _context.activityy
                .Include(a => a.Location)
                .SingleOrDefaultAsync(m => m.ActivityyId == id);
            if (activityy == null)
            {
                return NotFound();
            }

            return View(activityy);
        }

        // POST: Activityy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityy = await _context.activityy.SingleOrDefaultAsync(m => m.ActivityyId == id);
            _context.activityy.Remove(activityy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityyExists(int id)
        {
            return _context.activityy.Any(e => e.ActivityyId == id);
        }
    }
}
