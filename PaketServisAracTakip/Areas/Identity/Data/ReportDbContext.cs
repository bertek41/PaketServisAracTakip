using Microsoft.EntityFrameworkCore;
using PaketServisAracTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaketServisAracTakip.Areas.Identity.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext()
        {

        }
        public ReportDbContext(DbContextOptions<ReportDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IP\\MSSQLSERVER2019;Database=MVCAuthDb;user Id=YASINS;Password=PASSWORD;");
        }

        public DbSet<Report> Reports { get; set; }

    }
}
