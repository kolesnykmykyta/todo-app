using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        [MaxLength(32, ErrorMessage = "Task name is too long.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(128, ErrorMessage = "Task description is too long.")]
        public string Description { get; set; } = string.Empty;
    }
}
