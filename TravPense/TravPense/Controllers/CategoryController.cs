using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravPense.Data;
using TravPense.Data.Model;

namespace TravPense.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Destination> categorylist = new List<Destination>();
            categorylist = (from category in _context.destination select category).ToList();

            categorylist.Insert(0, new Destination { DestinationId = 0, DestName = "select" });
            ViewBag.categorylist = categorylist;
            return View();
        }

        public JsonResult GetLocation(int locationid)
        {
            List<Location> locationlist = new List<Location>();
            locationlist = (from loc in _context.location where loc.DestinationId == locationid select loc).ToList();

            locationlist.Insert(0, new Location { LocationId = 0, LocType = "select" });

            return Json(new SelectList(locationlist, "LocationId", "LocType"));
        }
        public JsonResult GetHotel(int hotelid)
        {
            List<Hotel> hotellist = new List<Hotel>();
            hotellist = (from hot in _context.hotel where hot.HotelId == hotelid select hot).ToList();

            hotellist.Insert(0, new Hotel { HotelId = 0, HotName = "select" });

            return Json(new SelectList(hotellist, "HotelId", "HotName"));
        }
    }
}