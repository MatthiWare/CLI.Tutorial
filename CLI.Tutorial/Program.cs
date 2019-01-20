using System;
using CLI.Tutorial.Options;
using MatthiWare.CommandLine;

namespace CLI.Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineParserOptions
            {
                AppName = "CLI.Tutorial"
            };

            var parser = new CommandLineParser<ProgramOptions>(options);

            parser.AddCommand<StartOptions>()
                .Name("start")
                .Required(false)
                .Description("Start the server")
                .OnExecuting((p, s) =>
                {
                    Console.WriteLine($"Server start on port {s.Port}");
                });

            var result = parser.Parse(args);

            if (result.HasErrors)
            {
                Console.Error.WriteLine("Parsing has errors..");
                return;
            }

            var programOptions = result.Result;

            Console.WriteLine("Program executed with: ");
            Console.WriteLine($"Username: {programOptions.Username}");
            Console.WriteLine($"Password: {programOptions.Password}");
            Console.WriteLine($"Verbose: {programOptions.Verbose}");
        }
    }
}
