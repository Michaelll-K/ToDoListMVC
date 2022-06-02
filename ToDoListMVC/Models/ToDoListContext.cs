using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListMVC.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoModel> Tasks { get; set; }
    }
}
