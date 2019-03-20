using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListDAL.EF;
using ToDoListDomain.Models;

namespace ToDoListWeb
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
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
    }
}
