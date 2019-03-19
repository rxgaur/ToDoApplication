using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ToDoListDomain.Models;
using ToDoListServiceLayer.BAL.Interface;

namespace ToDoListServiceLayer.BAL.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterViewModel form)
        {
            var entity = new IdentityUser
            {
                Email = form.Email,
                UserName = form.Email,
            };

            var result = await _userManager.CreateAsync(entity, form.Password);
            
           return result;
        }
    }
}
