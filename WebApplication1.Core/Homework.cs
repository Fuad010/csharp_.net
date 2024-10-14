using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Core
{
    public class Homework
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public int MemberId { get; set; }
        public int? MentorId { get; set; }
    }
}
