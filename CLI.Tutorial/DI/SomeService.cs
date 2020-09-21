using MatthiWare.CommandLine.Abstractions.Usage;
using System;

namespace CLI.Tutorial.DI
{
    public class SomeService : ICustomInjectedService
    {
        private readonly IEnvironmentVariablesService environment;

        public SomeService(IEnvironmentVariablesService environment)
        {
            this.environment = environment;
        }

        public void DoSomething()
        {
            Console.WriteLine("Injected Service:");
            Console.WriteLine($" -> {nameof(SomeService)}: {environment.GetType().Name}: NO_COLOR was set to: {environment.NoColorRequested}");
        }
    }
}
