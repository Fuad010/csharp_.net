﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Core.Repositories
{
    public interface ILessonsRepository
    {
        void Create(Lesson<int> lesson);

        Lesson<int>[] Get();
    }
}
