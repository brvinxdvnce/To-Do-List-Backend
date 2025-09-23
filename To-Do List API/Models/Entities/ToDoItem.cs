using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_List_API.Models.Entities
{
    [Table("task")]
    public class ToDoItem
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/ //генерится в бд
        [Column("id")]
        public required int Id {  get; set; }

        [Column("title")]
        public required string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_completed")]
        public required bool IsCompleted { get; set; }
    }
}
