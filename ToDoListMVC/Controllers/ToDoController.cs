using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListMVC.Models;
using ToDoListMVC.Repositories;

namespace ToDoListMVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository toDoRepository;

        public ToDoController(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }
        // GET: ToDo
        public ActionResult Index()
        {
            return View(toDoRepository.GetAllActive());
        }

        // GET: ToDo/Details/5
        public ActionResult Details(int id)
        {
            return View(toDoRepository.Get(id));
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View(new ToDoModel());
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoModel toDoModel)
        {
            toDoRepository.Add(toDoModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View(toDoRepository.Get(id));
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDoModel toDoModel)
        {
            toDoRepository.Update(id, toDoModel);

            return RedirectToAction(nameof(Index));
            
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(toDoRepository.Get(id));
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ToDoModel toDoModel)
        {
            toDoRepository.Delete(id);

            return RedirectToAction(nameof(Index));
            
        }

        // GET: ToDo/Done/5
        public ActionResult Done(int id)
        {
            ToDoModel todo = toDoRepository.Get(id);
            todo.Done = true;
            toDoRepository.Update(id, todo);

            return RedirectToAction(nameof(Index));
        }
    }
}
