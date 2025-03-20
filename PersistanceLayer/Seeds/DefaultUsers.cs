using Application.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PersistanceLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistanceLayer.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var temp = userManager.Users.ToList();

            var user = new ApplicationUser();
            user.UserName = "superadmin";
            user.Email = "superAdmin@gmail.com";
            user.FirstName = "Shami";
            user.LastName = "Hashmi";
            user.Gender = "Male";
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;

            if (userManager.Users.All(x => x.Id == user.Id))
            {
                var result = await userManager.FindByEmailAsync(user.Email);
                if (result is null)
                {
                    await userManager.CreateAsync(user, "123@Test");
                    await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                }
            }
        }
    }
}