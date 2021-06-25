using Serilog;

namespace Exercism.CSharp
{
    internal static class Logging
    {
        public static void Setup() =>
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();
    }
}