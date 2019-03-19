using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListDomain.Models;

namespace ToDoListServiceLayer.BAL.Interface
{
    public interface IToDoOperationService
    {
        Task<IEnumerable<ToDo>> GetAllToDoByUserId(string userId);
        Task<ToDo> GetToDoDetailById(int? id);
        Task CreateToDoTask(ToDo toDo);
        Task<ToDo> GetToDoForEditById(int? id);
        Task<ToDo> UpdateToDoWithEntity(int id, ToDo toDo);
        Task<ToDo> GetToDoForDeleteById(int? id);
        Task<bool> DeleteConfirmedTodo(int id);
    }
}