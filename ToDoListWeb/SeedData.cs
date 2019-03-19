using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ToDoListDAL.EF;
using ToDoListDomain.Models;

namespace ToDoListWeb
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            //await AddTestUsers(
            //    services.GetRequiredService<RoleManager<UserRoleEntity>>(),
            //    services.GetRequiredService<UserManager<UserEntity>>());

            await AddTestData(
                services.GetRequiredService<ToDoListDbContext>());
        }

        public static async Task AddTestData(ToDoListDbContext context)
        {
            try
            {
                if (context.ToDos.Any()) return;
                context.ToDos.AddRange(GetTasks());
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static IEnumerable<ToDo> GetTasks()
        {
            var todos = new List<ToDo>
            {
                new ToDo {Description = "First Task", IsActive = true, UserId = "1"},
                new ToDo {Description = "Second Task", IsActive = true, UserId = "1"},
                new ToDo {Description = "Third Task", IsActive = true, UserId = "1"}
            };
            return todos;
        }

        //private static async Task AddTestUsers(
        //    RoleManager<UserRoleEntity> roleManager,
        //    UserManager<UserEntity> userManager)
        //{
        //    var dataExists = roleManager.Roles.Any() || userManager.Users.Any();
        //    if (dataExists)
        //    {
        //        return;
        //    }

        //    // Add a test role
        //    await roleManager.CreateAsync(new UserRoleEntity("Admin"));

        //    // Add a test user
        //    var user = new UserEntity
        //    {
        //        Email = "admin@landon.local",
        //        UserName = "admin@landon.local",
        //        FirstName = "Admin",
        //        LastName = "Tester",
        //        CreatedAt = DateTimeOffset.UtcNow
        //    };

        //    await userManager.CreateAsync(user, "Supersecret123!!");

        //    // Put the user in the admin role
        //    await userManager.AddToRoleAsync(user, "Admin");
        //    await userManager.UpdateAsync(user);
        //}
    }
}
    