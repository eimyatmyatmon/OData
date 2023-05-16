using System.ComponentModel.DataAnnotations;

namespace ODataTutorial.Models
{
    public class Todo : BaseModel
    {
        public Todo()
        {
            Notes = new HashSet<Note>();
        }

        [Required]
        public string Item { get; set; } = "";
        public int Status { get; set; } = 0;
        public ICollection<Note> Notes { get; set; }
    }
}