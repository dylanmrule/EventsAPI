using System;
using EventsAPI.Areas.Identity.Data;
using EventsAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EventsAPI.Areas.Identity.IdentityHostingStartup))]
namespace EventsAPI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EventsApiIdentityDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EventsApiIdentityDBContextConnection")));

                services.AddDefaultIdentity<EventsAPIUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<EventsApiIdentityDBContext>();
            });
        }
    }
}