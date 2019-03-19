using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListDAL.EF;
using ToDoListDomain.Models;
using ToDoListServiceLayer.BAL.Interface;

namespace ToDoListServiceLayer.BAL.Implementation
{
    public class ToDoOperationService : IToDoOperationService
    {
        private readonly ToDoListDbContext _context;

        public ToDoOperationService(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDo>> GetAllToDoByUserId(string userId)
        {
            var todoList = await _context.ToDos.Where(x => x.UserId == userId).ToListAsync();
            return todoList;
        }


        public async Task<ToDo> GetToDoDetailById(int? id)
        {
            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);

            return toDo;
        }

        public async Task CreateToDoTask(ToDo toDo)
        {
            _context.Add(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task<ToDo> GetToDoForEditById(int? id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            return toDo;
        }

        public async Task<ToDo> UpdateToDoWithEntity(int id, ToDo toDo)
        {
            try
            {
                _context.Update(toDo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(toDo.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return toDo;
        }

        // GET: ToDoOperation/Delete/5
        public async Task<ToDo> GetToDoForDeleteById(int? id)
        {
            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);

            return toDo;
        }

        // POST: ToDoOperation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<bool> DeleteConfirmedTodo(int id)
        {
            try
            {
                var toDo = await _context.ToDos.FindAsync(id);
                _context.ToDos.Remove(toDo);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
