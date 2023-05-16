using System.ComponentModel.DataAnnotations;

namespace ODataTutorial.Models
{
    public class Note : BaseModel
    {
        public string MessageNote { get; set; } = default!;
        public Guid TodoId { get; set; }
        public Todo? Todo { get; set; }
    }
}