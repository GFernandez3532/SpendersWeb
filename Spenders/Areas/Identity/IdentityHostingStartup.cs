using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spenders.Areas.Identity.Data;
using Spenders.Data;

[assembly: HostingStartup(typeof(Spenders.Areas.Identity.IdentityHostingStartup))]
namespace Spenders.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SpendersContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SpendersContextConnection")));

                services.AddDefaultIdentity<SpendersUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<SpendersContext>();
            });
        }
    }
}