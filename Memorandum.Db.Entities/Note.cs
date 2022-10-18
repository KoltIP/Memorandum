using Memorandum.Db.Entities._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.Db.Entities
{
    public class Note : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string? Img { get; set; } = String.Empty;
        public int CategoryId { get; set; }
        public virtual Category Categoria { get; set; } 
    }
}
