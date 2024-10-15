using System;
using System.Security.Cryptography;
using WebApplication1.Core;
using WebApplication1.Core.Repositories;

namespace WebApplication1.BusinessLogic
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly GithubClient _githubClient;

        public LessonsService(ILessonsRepository lessonsRepository, GithubClient githubClient)
        {
            _lessonsRepository = lessonsRepository;
            _githubClient = githubClient;
        }
        public Lesson<int>[] Get()
        {

            var lessons = _lessonsRepository.Get();

            var githubUser = _githubClient.Get("nickname");

            return lessons; 
        }

        public void Create(Lesson<int> user)
        {

        }
         
    }
        public class GithubClient
        {
            public GithubUser Get(string nickname)
            {   
                return new GithubUser();
            }
        }

        public class GithubUser
        {

        }
}
