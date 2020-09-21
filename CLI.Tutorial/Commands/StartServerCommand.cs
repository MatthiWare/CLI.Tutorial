using CLI.Tutorial.DI;
using CLI.Tutorial.Options;
using MatthiWare.CommandLine.Abstractions.Command;
using System;

namespace CLI.Tutorial.Commands
{
    public class StartServerCommand : Command<ProgramOptions, StartOptions>
    {
        private readonly ICustomInjectedService injectedService;

        public StartServerCommand(ICustomInjectedService injectedService)
        {
            this.injectedService = injectedService;
        }

        public override void OnConfigure(ICommandConfigurationBuilder<StartOptions> builder)
        {
            builder.Name("start")
                .Required(false)
                .Description("Start the server");
        }

        public override void OnExecute(ProgramOptions options, StartOptions startOptions)
        {
            Console.WriteLine($"Server start on port {startOptions.Port}");
            injectedService.DoSomething();
            Console.WriteLine();
        }
    }
}
