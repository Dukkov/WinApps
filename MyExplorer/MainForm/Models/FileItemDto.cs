using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForm.Models
{
    public class FileItemDto
    {
        public int? ParentId { get; set; } = null;
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
        public int? Size { get; set; } = null;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? AccessedAt { get; set; } = null;
        public string Extender { get; set; } = null;
    }
}
