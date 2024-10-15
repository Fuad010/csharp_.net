using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Core
{
    public class Homework
    {
        [MaxLength(8)]
        [MinLength(2)]
        public string Title { get; set; }
        public string Link { get; set; }
        [Range(10, 20)]
        public int MemberId { get; set; }
        public int? MentorId { get; set; }
    }
}
