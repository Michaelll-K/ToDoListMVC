using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListMVC.Models;

namespace ToDoListMVC.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoListContext context;

        public ToDoRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public ToDoModel Get(int taskId) => context.Tasks.SingleOrDefault(x => x.ToDoId == taskId);

        public IQueryable<ToDoModel> GetAllActive() => context.Tasks.Where(x => x.Done == false);

        public void Add(ToDoModel todo)
        {
            context.Tasks.Add(todo);
            context.SaveChanges();
        }

        public void Update(int taskId, ToDoModel todo)
        {
            var result = context.Tasks.SingleOrDefault(x => x.ToDoId == taskId);

            if (result != null)
            {
                result.Name = todo.Name;
                result.Content = todo.Content;
                result.Done = todo.Done;

                context.SaveChanges();
            }
        }

        public void Delete(int taskId)
        {
            var result = context.Tasks.SingleOrDefault(x => x.ToDoId == taskId);

            if (result != null)
            {
                context.Tasks.Remove(result);

                context.SaveChanges();
            }
        }
    }
}
