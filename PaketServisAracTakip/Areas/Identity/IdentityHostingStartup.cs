using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaketServisAracTakip.Areas.Identity.Data;
using PaketServisAracTakip.Data;

[assembly: HostingStartup(typeof(PaketServisAracTakip.Areas.Identity.IdentityHostingStartup))]
namespace PaketServisAracTakip.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AccountDbContext>(options =>
                    options.UseSqlServer("Server=IP\\MSSQLSERVER2019;Database=MVCAuthDb;user Id=YASINS;Password=PASSWORD;"));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<AccountDbContext>();
            });
        }
    }
}