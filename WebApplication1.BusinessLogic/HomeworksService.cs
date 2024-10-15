using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core;
using WebApplication1.Core.Exceptions;
using WebApplication1.Core.Repositories;

namespace WebApplication1.BusinessLogic
{
    public class HomeworksService : IHomeworksService
    {
        public const string HOMEWORK_IS_INVALID = "Homework is invaild!";
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

            var isValid = string.IsNullOrWhiteSpace(homework.Link)
                || string.IsNullOrEmpty(homework.Title)
                || homework.MemberId <=0;

            if (isValid)
            {
                throw new BusinessException(HOMEWORK_IS_INVALID);
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
