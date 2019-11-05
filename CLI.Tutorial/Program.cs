using CLI.Tutorial.Options;
using CLI.Tutorial.Validations;
using MatthiWare.CommandLine;
using MatthiWare.CommandLine.Extensions.FluentValidations;
using System;

namespace CLI.Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineParserOptions
            {
                AppName = "CLI.Tutorial",
                PrefixShortOption = "/",
                PrefixLongOption = "--",
                PostfixOption = "="
            };

            var parser = new CommandLineParser<ProgramOptions>(options);

            parser.UseFluentValidations(configurator
                => configurator.AddValidator<ProgramOptions, ProgramOptionValidator>()
                    .AddValidator<StartOptions, StartOptionValidator>());

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

                foreach (var ex in result.Errors)
                    Console.Error.WriteLine(ex);

                Console.ReadLine();
                return;
            }

            var programOptions = result.Result;

            Console.WriteLine("Program executed with: ");
            Console.WriteLine($"Username: {programOptions.Username}");
            Console.WriteLine($"Password: {programOptions.Password}");
            Console.WriteLine($"Verbose: {programOptions.Verbose}");

            Console.ReadLine();
        }
    }
}
