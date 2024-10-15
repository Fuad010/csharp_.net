using System;
using WebApplication1.Core.Repositories;

namespace WebApplication1.DataAccess
{
    public class LessonsRepository : ILessonsRepository
    {
        public LessonsRepository() 
        {
        
        }

        public Core.Lesson<int>[] Get()
        {
            var lesson = new Lesson<int>
            {
                Id = 1,
                Name = "English",
                Description = "Have Has",
                Chapters = 34,
                TotalDay = 60
            };
            return new[]
            {
                new Core.Lesson<int>
                {
                    Name = lesson.Name,
                    Description = lesson.Description,
                    Chapters = lesson.Chapters,
                    TotalDay = lesson.TotalDay
                }
            };
        }

        public void Create(Core.Lesson<int> user)
        {

        }
    }
}
