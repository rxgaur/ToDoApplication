using System;
using System.ComponentModel.DataAnnotations;
using ToDoListWeb.Models;

namespace ToDoListWeb.DAL.EF
{
    public class ToDo : BaseEntity
    {
        [Required]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}