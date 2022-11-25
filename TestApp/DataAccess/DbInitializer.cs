using Core.Constant;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbInitializer
    {
        public async static Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await roleManager.RoleExistsAsync(role.ToString()))
                {
                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = role.ToString(),
                    });

                }

            }

            if ((await userManager.FindByNameAsync("admin")) == null)
            {

                var user = new User
                {
                    Fullname = "admin",
                    UserName = "admin",
                    Email = "admin@app.com"

                };

                var result = await userManager.CreateAsync(user, "Admin12345678*");
                if (!result.Succeeded)
                {

                    foreach (var error in result.Errors)
                    {
                        throw new Exception(error.Description);
                    }
                }

                await userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
            }
        }
    }
}
