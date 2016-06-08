using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoolPhone.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}

