using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Core
{
    public class Lesson<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public T Chapters { get; set; }
        public T TotalDay { get; set; }
        public DateTime StartedPost { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan DuratoinTime { get; set; }
        public void ChangeDescription()
        {
               
        }
    }
}
