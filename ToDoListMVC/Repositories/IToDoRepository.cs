using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListMVC.Models;

namespace ToDoListMVC.Repositories
{
    public interface IToDoRepository
    {
        ToDoModel Get(int taskId);
        IQueryable<ToDoModel> GetAllActive();
        void Add(ToDoModel todo);
        void Update(int taskId, ToDoModel todo);
        void Delete(int taskId);

    }
}
