using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Writer : IEntity
    {
        public int WriterId { get; set; }
        public int UserId { get; set; }
   
    }
}
