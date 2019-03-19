using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoListDomain.Models;

namespace ToDoListDAL.EF
{
    public class ToDoListDbContext : IdentityDbContext<IdentityUser>
    {
        public ToDoListDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
