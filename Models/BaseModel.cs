using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataTutorial.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; } = null;
        public string? UpdatedBy { get; set; } = null;
    }
}