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

            categorylist.Insert(0, new Destination { DestinationId = 0, DestName = "select an option" });
            ViewBag.categorylist = categorylist;
            return View();
        }

        public JsonResult GetLocation(int locationid)
        {
            List<Location> locationlist = new List<Location>();
            locationlist = (from loc in _context.location where loc.DestinationId == locationid select loc).ToList();

            locationlist.Insert(0, new Location { LocationId = 0, LocType = "select an option" });

            return Json(new SelectList(locationlist, "LocationId", "LocType"));
        }
        public JsonResult GetHotel(int hotelid)
        {
            List<Hotel> hotellist = new List<Hotel>();
            hotellist = (from hot in _context.hotel where hot.HotelId == hotelid select hot).ToList();

            hotellist.Insert(0, new Hotel { HotelId = 0, HotName = "select an option" });

            return Json(new SelectList(hotellist, "HotelId", "HotName"));
        }
        [HttpGet]
        public JsonResult GetActivity(int activityid)
        {
            List<Activityy> activitieslist = new List<Activityy>();
            activitieslist = (from act in _context.activityy where act.LocationId == activityid select act).ToList();
            activitieslist.Insert(0, new Activityy { ActivityyId = 0, ActivityName = "select an option" });

            ViewBag.datasource = activitieslist;
            return Json(new SelectList(activitieslist, "ActivityyId", "ActivityName"));
        }
    }
}