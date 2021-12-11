using System;
using eShop.Areas.Identity.Data;
using eShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(eShop.Areas.Identity.IdentityHostingStartup))]
namespace eShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<eShopDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("eShopDbContextConnection")));


                services.AddIdentity<eShopUser, IdentityRole>(options => {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = false;
                    options.User.AllowedUserNameCharacters = null;
                })
                    .AddDefaultTokenProviders()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<eShopDbContext>();
            });
        }
    }
}