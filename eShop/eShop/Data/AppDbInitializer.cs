using eShop.Areas.Identity.Data;
using eShop.Data;
using eShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Data
{
    public class AppDbInitializer
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<eShopUser>>();

           
            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Adding Admin User
            var user = new eShopUser();
            user.FirstName = "admin";
            user.LastName = "admin";
            user.UserName = "admin@gmail.com";
            user.Email = "admin@gmail.com";
            string userPWD = "123456Ab+";

            IdentityResult chkUser = await UserManager.CreateAsync(user, userPWD);
            if (!await UserManager.IsInRoleAsync(user, "Admin"))
            {
                await UserManager.SetLockoutEnabledAsync(user, false);
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }
            public static void Seed(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<eShopDbContext>();

                    context.Database.EnsureCreated();

                    //Sellers
                    if (!context.Sellers.Any())
                    {
                        context.Sellers.AddRange(new List<Seller>()
                   {
                       new Seller()
                       {
                           FullName = "Charles Dickens",
                           ProfilePictureURL = "https://cdn.icon-icons.com/icons2/1736/PNG/512/4043260-avatar-male-man-portrait_113269.png",
                           Bio = "Has been selling cars on this platform over 10 years."
                       },

                       new Seller()
                       {
                           FullName = "Noname Jhon",
                           ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROdUNllTvwag4LcIRAu9tcb8tgbR_RoaGQSE3_Zv6zS2ewaBC6z9PuJ2bYtfxwCRx7d6U&usqp=CAU",
                           Bio = "Doesn't know anything about the cars."
                       },

                       new Seller()
                       {
                           FullName = "Adam Hrincir",
                           ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9n2fISU1BKUbbIXELQxRMuoH_QcZq74po2Y2PBZ07GD52L23dKWzRmKjMlF_TXx5Xpzc&usqp=CAU",
                           Bio = "Im here just for fun."
                       }
                   });
                        context.SaveChanges();
                    }
                    //Cars
                    if (!context.Cars.Any())
                    {
                        context.Cars.AddRange(new List<Car>()
                    {
                       new Car()
                       {
                           Model = "AUDI R8",
                           Description = "Car was in use for 5 years, now i just need to sell this car, because I've bouthg myself a new one.",
                           Price = 1000,
                           CarMark = CarMark.Audi,
                           ImageURL = "https://img.carismo.cz/a/a6/a6b/a6ba929a57b557da0e2840d26961f8c4.jpg",
                           StartDate = DateTime.Now.AddDays(3),
                           EndDate = DateTime.Now.AddDays(365),
                           SellerId = 1
                       },
                       new Car()
                       {
                           Model = "BMW M3",
                           Description = "Car was in use for 5 years, now i just need to sell this car, because I've bouthg myself a new one.",
                           Price = 1100,
                           CarMark = CarMark.BMW,
                           ImageURL = "https://cdn.bmwblog.com/wp-content/uploads/2021/03/bmw_m3_m4_toronto_red_05.jpg",
                           StartDate = DateTime.Now.AddDays(3),
                           EndDate = DateTime.Now.AddDays(365),
                           SellerId = 2
                       },
                       new Car()
                       {
                           Model = "Tesla Model X",
                           Description = "Car was in use for 5 years, now i just need to sell this car, because I've bouthg myself a new one.",
                           Price = 500,
                           CarMark = CarMark.Tesla,
                           ImageURL = "https://auta5p.eu/zkusenosti/tesla_x/tesla_x_03c.jpg",
                           StartDate = DateTime.Now.AddDays(3),
                           EndDate = DateTime.Now.AddDays(365),
                           SellerId = 3
                       }
                    });
                        context.SaveChanges();
                    
                }
            }
        }
    }
}
