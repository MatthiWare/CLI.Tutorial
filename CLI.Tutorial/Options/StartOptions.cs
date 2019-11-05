using MatthiWare.CommandLine.Core.Attributes;

namespace CLI.Tutorial.Options
{
    public class StartOptions
    {
        [Required, Name("p", "port"), Description("port for the server"), DefaultValue(3333)]
        public int Port { get; set; }
    }
}
