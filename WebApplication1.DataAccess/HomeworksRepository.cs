using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core;
using WebApplication1.Core.Repositories;

namespace WebApplication1.DataAccess
{
    public class HomeworksRepository : IHomeworksRepository 
    {
        public HomeworksRepository()
        {
            
        }
        public void Add(Homework homework)
        {
            throw new NotImplementedException();
        }

        public void Delete(int homeworkId)
        {
            throw new NotImplementedException();
        }

        public Homework Get()
        {
            throw new NotImplementedException();
        }

        public void Update(Homework homework)
        {
            throw new NotImplementedException();
        }
    }
}
