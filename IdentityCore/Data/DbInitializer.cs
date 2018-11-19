using IdentityCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<User> userManager,
                              RoleManager<Role> roleManager)
        {
            context.Database.EnsureCreated();


            string role1 = "Voluntário";
            string desc1 = "This is the Voluntário role";

            string role2 = "Veterinário";
            string desc2 = "This is the Veterinário role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new Role(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new Role(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("aa@aa.aa") == null)
            {
                var user = new User
                {
                    UserName = "aa@aa.aa",
                    Email = "aa@aa.aa",
                    Address = "Teste",
                    BirthDate = new DateTime(2018, 10, 10),
                    RegistedDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }

            }

            if (await userManager.FindByNameAsync("bb@bb.bb") == null)
            {
                var user = new User
                {
                    UserName = "bb@bb.bb",
                    Email = "bb@bb.bb",
                    Address = "Teste",
                    BirthDate = new DateTime(2018, 10, 10),
                    RegistedDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }

            }

            if (await userManager.FindByNameAsync("mm@mm.mm") == null)
            {
                var user = new User
                {
                    UserName = "mm@mm.mm",
                    Email = "mm@mm.mm",
                    Address = "Teste",
                    BirthDate = new DateTime(2018, 10, 10),
                    RegistedDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (await userManager.FindByNameAsync("dd@dd.dd") == null)
            {
                var user = new User
                {
                    UserName = "dd@dd.dd",
                    Email = "dd@dd.dd",
                    Address = "Teste",
                    BirthDate = new DateTime(2018, 10, 10),
                    RegistedDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
        }
    }
}
