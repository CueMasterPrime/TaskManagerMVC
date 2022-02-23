using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerMVC.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        
        [Key]
        public int TaskId { get; set; }

        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        public bool Done { get; set; }

    }
}
