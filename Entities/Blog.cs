using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        public int WriterId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Image { get; set; }
        public string ThumbnailImage { get; set; }
        public bool Status { get; set; }
    }
}
