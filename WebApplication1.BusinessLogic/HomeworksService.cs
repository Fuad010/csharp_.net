using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core;

namespace WebApplication1.BusinessLogic
{
    public class HomeworksService : IHomeworksService
    {
        private readonly IHomeworksRepository _homeworksRepository;
        public HomeworksService(IHomeworksRepository homeworksRepository)
        {
            _homeworksRepository = homeworksRepository;
        }

        public bool Create(Homework homework)
        {
            // валидация
            if (homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            // сохранение в базе
            _homeworksRepository.Add(homework);

            return true;
        }

        public bool Delete(int homeworkId)
        {
            _homeworksRepository.Delete(homeworkId);

            return true;
        }
    }
}
