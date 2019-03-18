using System.ComponentModel.DataAnnotations;

namespace ToDoListWeb.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}
