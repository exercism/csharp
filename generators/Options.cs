using CommandLine;

namespace Generators
{
    public class Options
    {
        [Option('e', "exercise", Required = false, 
            HelpText = "Exercise to generate (if not specified, defaults to all exercises).")]
        public string Exercise { get; set; }
        
        [Option('d', "canonicaldatadirectory", Required = false,
            HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")]
        public string CanonicalDataDirectory { get; set; }

        [Option('c', "cachecanonicaldata", Required = false, Default = false,
            HelpText = "Use the cached canonical data and don't update the data.")]
        public bool CacheCanonicalData { get; set; }
    }
}