using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDoListDomain.Models;

namespace ToDoListServiceLayer.BAL.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterViewModel form);
    }
}
