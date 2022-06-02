using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListMVC.Models
{
    [Table("Tasks")]
    public class ToDoModel
    {
        [Key]
        public int ToDoId { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Podaj nazwe")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [MaxLength(2000)]
        public string Content { get; set; }
        public bool Done { get; set; }
    }
}
