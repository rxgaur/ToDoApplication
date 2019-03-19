using System.ComponentModel.DataAnnotations;

namespace ToDoListDomain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}
