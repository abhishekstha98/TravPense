using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravPense.Data;
using TravPense.Models;

namespace TravPense.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Destination> li = new List<Destination>();
            li = _context.destinations.ToList();
            ViewBag.listofitems = li;
            return View();
        }

        public IActionResult GetHotelById(int id)
        {
            List<hotel> loclist =new List<hotel>();
           // List<hotel> hotlist = new List<hotel>();
           // List<activity> actlist = new List<activity>();

            loclist = _context.hotels.Where(a => a.destination.destid == id).ToList();
            loclist.Insert(0, new hotel { hotelid = 0, HotelName = "Select an option" });

            return Json(new SelectList(loclist, "locid", "Loctype"));
        }
    
    }

}