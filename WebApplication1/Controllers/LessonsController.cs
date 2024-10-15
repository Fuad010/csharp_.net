using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.BusinessLogic;
using WebApplication1.Core;
using WebApplication1.Core.Repositories;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeWorksController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;
        public HomeWorksController(IHomeworksService homeworksService)
        {
            _homeworksService = homeworksService;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;

        public LessonsController()
        {
            ILessonsRepository lessonsRepository = new LessonsRepository();
            LessonsService _lessonService = new LessonsService(lessonsRepository, null);
        }

        [HttpGet]
        public Lesson<int> GetLessons(string name, string description, int chapters, int totalDay)
        {
            //var lessons = new List<Lesson>();
            var lesson = new Lesson<int>
            {
                Name = name,
                Description = description,
                Chapters = chapters,
                TotalDay = totalDay,
                StartedPost = DateTime.Now,
                StartTime = DateTime.Now.AddDays(3),
                DuratoinTime = TimeSpan.FromMinutes(45),
            };

            return lesson;
        }

        [HttpGet("getForReflex")]
        public Lesson<int>[] GetForReflex(string name, string description, int chapters, int totalDay)
        {
            var lessons = new List<Lesson<int>>();

            int count = 0;

            for (int i = 0; i < 10; i++)
            {
                count++;
                var lesson = new Lesson<int>
                {
                    Name = name + " " + count,
                    Description = description + " " + count,
                    Chapters = chapters,
                    TotalDay = totalDay,
                    StartedPost = DateTime.Now.AddHours(1 + 0.5),
                    StartTime = DateTime.Now.AddDays(3 + 1),
                    DuratoinTime = TimeSpan.FromMinutes(45 + 3),
                };
                lessons.Add(lesson);
            }


            return lessons.ToArray();
        }

        [HttpGet]
        public Lesson<int>[] Get(string lessonName)
        {


            var lesson = _lessonsService.Get();

            var result = new Lesson<int>();

            return new[] { result };
        }

        [HttpPost]
        public Lesson<int> Create(Lesson<int> newLesson)
        {
            var lesson = new Core.Lesson<int>
            {
                Name = newLesson.Name,
                Description = newLesson.Description,
                Chapters = newLesson.Chapters,
                TotalDay = newLesson.TotalDay,
                StartedPost = newLesson.StartedPost,
                StartTime = newLesson.StartTime,
                DuratoinTime = newLesson.DuratoinTime,
            };

            _lessonsService.Create(lesson);

            return newLesson;
        }

    }
}
