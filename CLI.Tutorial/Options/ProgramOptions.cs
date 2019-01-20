using MatthiWare.CommandLine.Core.Attributes;

namespace CLI.Tutorial.Options
{
    public class ProgramOptions
    {
        [Required, Name("u", "username"), Description("Login user")]
        public string Username { get; set; }

        [Required, Name("p", "password"), Description("Password for the user")]
        public string Password { get; set; }

        [Name("v", "verbose"), Description("Verbose output"), DefaultValue(true)]
        public bool Verbose { get; set; }
    }
}
