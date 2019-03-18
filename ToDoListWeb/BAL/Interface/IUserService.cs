using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDoListWeb.Models;

namespace ToDoListWeb.BAL.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterViewModel form);
    }
}
