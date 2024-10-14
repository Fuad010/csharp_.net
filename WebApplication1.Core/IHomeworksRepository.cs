﻿namespace WebApplication1.Core
{
    public interface IHomeworksRepository
    {
        void Add(Homework homework);
        Homework Get();
        void Update(Homework homework);
        void Delete(int homeworkId);
    }
}