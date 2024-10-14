using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Lesson<T>
    {
        /// <summary>
        /// Название урока
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание урока
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Главы (или страницы, если это обучающая глава)
        /// </summary>
        public T Chapters { get; set; }

        /// <summary>
        /// Общая длительность обучения
        /// </summary>
        public T TotalDay { get; set; }

        /// <summary>
        /// Дата создания поста
        /// </summary>
        public DateTime StartedPost { get; set; }

        /// <summary>
        /// Время начала урока
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Длительность урока
        /// </summary>
        public TimeSpan DuratoinTime { get; set; }

        /// <summary>
        /// Конструктор класса Lesson
        /// </summary>
        public Lesson()
        {

        }
        public Lesson(string name,string description,T chapters,T totalDay)
        {
            Name = name;
            Description = description;
            Chapters = chapters;
            TotalDay = totalDay;
        }
    }
}
