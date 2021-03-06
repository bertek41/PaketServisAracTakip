using Microsoft.EntityFrameworkCore;
using PaketServisAracTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaketServisAracTakip.Areas.Identity.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext()
        {

        }
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IP\\MSSQLSERVER2019;Database=MVCAuthDb;user Id=YASINS;Password=PASSWORD;");
        }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
