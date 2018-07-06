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
    [Authorize(Roles = "superadmin,hm")]
    public class HotelModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.hotelModels.ToListAsync());
        }

        // GET: HotelModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelModel = await _context.hotelModels
                .SingleOrDefaultAsync(m => m.Hotelid == id);
            if (hotelModel == null)
            {
                return NotFound();
            }

            return View(hotelModel);
        }

        // GET: HotelModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hotelid,HotelName,Destination,Contact,MinPrice,MaxPrice")] HotelModel hotelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelModel);
        }

        // GET: HotelModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelModel = await _context.hotelModels.SingleOrDefaultAsync(m => m.Hotelid == id);
            if (hotelModel == null)
            {
                return NotFound();
            }
            return View(hotelModel);
        }

        // POST: HotelModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hotelid,HotelName,Destination,Contact,MinPrice,MaxPrice")] HotelModel hotelModel)
        {
            if (id != hotelModel.Hotelid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelModelExists(hotelModel.Hotelid))
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
            return View(hotelModel);
        }

        // GET: HotelModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelModel = await _context.hotelModels
                .SingleOrDefaultAsync(m => m.Hotelid == id);
            if (hotelModel == null)
            {
                return NotFound();
            }

            return View(hotelModel);
        }

        // POST: HotelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelModel = await _context.hotelModels.SingleOrDefaultAsync(m => m.Hotelid == id);
            _context.hotelModels.Remove(hotelModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelModelExists(int id)
        {
            return _context.hotelModels.Any(e => e.Hotelid == id);
        }
    }
}
