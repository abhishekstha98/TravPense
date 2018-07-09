using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            List<Location> li = new List<Location>();
            li = _context.locations.ToList();
            ViewBag.listofitems = li;
            return View();
        }
    }
}