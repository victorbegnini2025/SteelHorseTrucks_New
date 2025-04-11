using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SteelHorseTrucks.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminEmail = "vabeg17@gmail.com";
            string adminPassword = "Admin147!";
            string roleName = "Admin";

            // Cria a role se não existir
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Cria o user se não existir
            var user = await userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    throw new Exception("Error while creating admin user: " + string.Join(", ", result.Errors));
                }
            }
            else
            {
                if (!await userManager.IsInRoleAsync(user, roleName))
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
