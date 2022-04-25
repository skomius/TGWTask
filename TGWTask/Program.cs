using System;
using System.Collections.Generic;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TWGTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IFooService, FooService>()
            .AddSingleton<IBarService, BarService>()
            .BuildServiceProvider();

            Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(new String[] { "--help" });

            while (true)
            {
                var text = Console.ReadLine().Split();
                var parse = Parser.Default.ParseArguments<AddOptions, CommitOptions, CloneOptions>(text)
                    .MapResult(
                        (AddOptions opts) => RunAddAndReturnExitCode(opts),
                        (CommitOptions opts) => RunCommitAndReturnExitCode(opts),
                        (CloneOptions opts) => RunCloneAndReturnExitCode(opts, serviceProvider.GetRequiredService<IBarService>()),
                      (errs) => 1);

            }
        }

        private static int RunCloneAndReturnExitCode(CloneOptions opts, IBarService barService)
        {
            Console.WriteLine("Clone");
            return 0;
        }

        private static int RunCommitAndReturnExitCode(CommitOptions opts)
        {
            Console.WriteLine("Commint");
            return 0;
        }

        private static int RunAddAndReturnExitCode(AddOptions opts)
        {
            Console.WriteLine("Add");
            return 0;
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            if (errs.IsVersion())
            {
                Console.WriteLine("Version Request");
                return;
            }

            if (errs.IsHelp())
            {
                Console.WriteLine("Help Request");
                return;
            }
            Console.WriteLine("Parser Fail");
        }

        private static void Run(Options opts)
        {
            Console.WriteLine("Parser success");
        }

        [Verb("add", HelpText = "Add file contents to the index.")]
        class AddOptions
        {
            [Option("stdin", Default = false, HelpText = "Read from stdin")]
            public bool stdin { get; set; }

            [Value(0, MetaName = "offset", HelpText = "File offset.")]
            public long? Offset { get; set; }
        }

        [Verb("commit", HelpText = "Record changes to the repository.")]
        class CommitOptions
        {
            //commit options here
        }

        [Verb("clone", HelpText = "Clone a repository into a new directory.")]
        class CloneOptions
        {
            //clone options here
        }

        public interface IFooService
        {
            void DoThing(int number);
        }

        public interface IBarService
        {
            void DoSomeRealWork();
        }

        public class BarService : IBarService
        {
            private readonly IFooService _fooService;
            public BarService(IFooService fooService)
            {
                _fooService = fooService;
            }

            public void DoSomeRealWork()
            {
                for (int i = 0; i < 10; i++)
                {
                    _fooService.DoThing(i);
                }
            }
        }

        public class FooService : IFooService
        {
            private readonly ILogger<FooService> _logger;
            public FooService(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<FooService>();
            }

            public void DoThing(int number)
            {
                _logger.LogInformation($"Doing the thing {number}");
            }
        }
    }
}

