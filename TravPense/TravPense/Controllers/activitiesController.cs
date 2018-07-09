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
    public class activitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public activitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: activities
        public async Task<IActionResult> Index()
        {
            return View(await _context.activities.ToListAsync());
        }

        // GET: activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activities
                .SingleOrDefaultAsync(m => m.actid == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("actid,ActivityName,Duration,PricePerHour")] activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activities.SingleOrDefaultAsync(m => m.actid == id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("actid,ActivityName,Duration,PricePerHour")] activity activity)
        {
            if (id != activity.actid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!activityExists(activity.actid))
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
            return View(activity);
        }

        // GET: activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.activities
                .SingleOrDefaultAsync(m => m.actid == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.activities.SingleOrDefaultAsync(m => m.actid == id);
            _context.activities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool activityExists(int id)
        {
            return _context.activities.Any(e => e.actid == id);
        }
    }
}
