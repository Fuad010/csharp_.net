using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Core
{
    public interface IHomeworksService
    {
        bool Create(Homework homework);
        bool Delete(int homeworkId);
    }
}
