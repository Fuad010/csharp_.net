using Microsoft.Extensions.DependencyInjection;
using System;

namespace DITest
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddSingleton<LessonsService>();
            collection.AddTransient<PullRequestService>();
            collection.AddSingleton<GithubClient>();

            var provider = collection.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var lessonsService = scope.ServiceProvider.GetService<LessonsService>();
                var pullRequestService = scope.ServiceProvider.GetService<PullRequestService>();
                var controller = new LessonsController(lessonsService, pullRequestService);
                controller.Print();
            }

            using (var scope = provider.CreateScope())
            {
                var lessonsService = scope.ServiceProvider.GetService<LessonsService>();
                var pullRequestService = scope.ServiceProvider.GetService<PullRequestService>();
                var controller = new LessonsController(lessonsService, pullRequestService);
                controller.Print();
            }
        }
        
        private static void SingletonMultipleRequests()
        {
            var client = new GithubClient();
            var lessonsService = new LessonsService(client);
            var pullRequestService = new PullRequestService(client);

            // request - scope
            {
                var controller = new LessonsController(lessonsService, pullRequestService);
                controller.Print();
            }

            // request - scope
            {

                var controller = new LessonsController(lessonsService, pullRequestService);
                controller.Print();
            }
        }

        private static void MultipleRequests()
        {
            // request - scope
            {
                var client = new GithubClient();
                var lessonsService = new LessonsService(client);
                var pullRequestService = new PullRequestService(client);
                var controller = new LessonsController(lessonsService, pullRequestService);

                controller.Print();
            }

            // request - scope
            {
                var client = new GithubClient();
                var lessonsService = new LessonsService(client);
                var pullRequestService = new PullRequestService(client);
                var controller = new LessonsController(lessonsService, pullRequestService);

                controller.Print();
            }
        }

        private static void SingleRequest()
        {
            var client = new GithubClient();
            var lessonsService = new LessonsService(client);
            var pullRequestService = new PullRequestService(client);
            var controller = new LessonsController(lessonsService, pullRequestService);

            controller.Print();
        }
    }
    public class LessonsController
    {
        private readonly LessonsService _lessonsService;
        private readonly PullRequestService _pullRequestService;
        private readonly Guid _guid;
        public LessonsController(LessonsService lessonsService, PullRequestService pullRequestService)
        {
            _guid = Guid.NewGuid();
            _lessonsService = lessonsService;
            _pullRequestService = pullRequestService;
        }
        public void Print()
        {
            Console.WriteLine($"{nameof(LessonsController)} - {_guid}");
            _lessonsService.Print();
        }
    }

    public class LessonsService
    {
        private readonly GithubClient _githubClient;
        private readonly Guid _guid;
        public LessonsService(GithubClient githubClient)
        {
            _guid = Guid.NewGuid();
            _githubClient = githubClient;
        }
        public void Print()
        {
            Console.WriteLine($"{nameof(LessonsService)} - {_guid}");
            _githubClient.Print();
        }
    }
    public class PullRequestService
    {
        private readonly GithubClient _githubClient;
        private readonly Guid _guid;
        public PullRequestService(GithubClient githubClient)
        {
            _guid = Guid.NewGuid();
            _githubClient = githubClient;
        }
        public void Print()
        {
            Console.WriteLine($"{nameof(PullRequestService)} - {_guid}");
            _githubClient.Print();
        }
    }
    public class GithubClient
    {
        private Guid _guid;
        public GithubClient()
        {
            _guid = Guid.NewGuid();
        }
        public void Print() => Console.WriteLine($"{nameof(GithubClient)} - {_guid}");
    }
}
