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
    
   [Authorize(Roles ="superadmin,am")]
    public class ActivitiesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ActivitiesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActivitiesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.activitiesModels.ToListAsync());
        }

        // GET: ActivitiesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiesModel = await _context.activitiesModels
                .SingleOrDefaultAsync(m => m.ActivityID == id);
            if (activitiesModel == null)
            {
                return NotFound();
            }

            return View(activitiesModel);
        }

        // GET: ActivitiesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActivitiesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityID,ActivityName,Loctype,Price")] ActivitiesModel activitiesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activitiesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activitiesModel);
        }

        // GET: ActivitiesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiesModel = await _context.activitiesModels.SingleOrDefaultAsync(m => m.ActivityID == id);
            if (activitiesModel == null)
            {
                return NotFound();
            }
            return View(activitiesModel);
        }

        // POST: ActivitiesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityID,ActivityName,Loctype,Price")] ActivitiesModel activitiesModel)
        {
            if (id != activitiesModel.ActivityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activitiesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitiesModelExists(activitiesModel.ActivityID))
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
            return View(activitiesModel);
        }

        // GET: ActivitiesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activitiesModel = await _context.activitiesModels
                .SingleOrDefaultAsync(m => m.ActivityID == id);
            if (activitiesModel == null)
            {
                return NotFound();
            }

            return View(activitiesModel);
        }

        // POST: ActivitiesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activitiesModel = await _context.activitiesModels.SingleOrDefaultAsync(m => m.ActivityID == id);
            _context.activitiesModels.Remove(activitiesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitiesModelExists(int id)
        {
            return _context.activitiesModels.Any(e => e.ActivityID == id);
        }
    }
}
