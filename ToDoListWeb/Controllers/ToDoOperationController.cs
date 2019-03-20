using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoListDomain.Models;
using ToDoListServiceLayer.BAL.Interface;

namespace ToDoListWeb.Controllers
{
    [Authorize]
    public class ToDoOperationController : Controller
    {
        private readonly IToDoOperationService _toDoOperationService;

        public ToDoOperationController(IToDoOperationService toDoOperationService)
        {
            _toDoOperationService = toDoOperationService;
        }

        // GET: ToDoOperation
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadData()
        {
            try
            {

                int recordsTotal = 0;

                // Getting all Customer data  
                var userId = User.Identity.GetUserId();
                var result = _toDoOperationService.GetAllToDoByUserId(userId).Result;
                recordsTotal = result.Count();


                //Returning Json Data  
                return Json(new { recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result });

            }
            catch (Exception)
            {
                throw;
            }

        }


        // GET: ToDoOperation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _toDoOperationService.GetToDoDetailById(id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDoOperation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoOperation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskName,Description,IsActive,Id")] ToDo toDo)
        {
            if (!ModelState.IsValid) return View(toDo);
            toDo.LastUpdate = DateTime.UtcNow;
            toDo.UserId = User.Identity.GetUserId();
            await _toDoOperationService.CreateToDoTask(toDo);
            return RedirectToAction(nameof(Index));
        }

        // GET: ToDoOperation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _toDoOperationService.GetToDoForEditById(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleEdit(int id)
        {
            var toDo = await _toDoOperationService.GetToDoForEditById(id);
            if (toDo == null)
            {
                return NotFound();
            }

            toDo.LastUpdate = DateTime.UtcNow;
            toDo.UserId = User.Identity.GetUserId();
            toDo.IsActive = !toDo.IsActive;
            var todo = await _toDoOperationService.UpdateToDoWithEntity(id, toDo);
            if (todo == null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // POST: ToDoOperation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskName,Description,IsActive,Id")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(toDo);
            toDo.LastUpdate = DateTime.UtcNow;
            toDo.UserId = User.Identity.GetUserId();
            var todo = await _toDoOperationService.UpdateToDoWithEntity(id, toDo);
            if (todo == null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: ToDoOperation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _toDoOperationService.GetToDoForDeleteById(id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDoOperation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _toDoOperationService.DeleteConfirmedTodo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

