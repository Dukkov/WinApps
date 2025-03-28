using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    /// <summary>
    /// 파일 메타데이터 전송용 DTO 클래스
    /// </summary>
    public class FileMetadata
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
