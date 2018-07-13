using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravPense.Data.Model;
using TravPense.Models;

namespace TravPense.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<TravPense.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Destination> destination { get; set; }
        public DbSet<Location> location { get; set; }
        public DbSet<Hotel> hotel{ get; set; }
        public DbSet<Activityy> activityy { get; set; }
        }
}
