using System.Collections.Generic;
using CommandLine;

namespace Generators
{
    public class Options
    {
        [Option('e', "exercises", Required = false, 
            HelpText = "Exercises to generate (if not specified, defaults to all exercises).")]
        public IEnumerable<string> Exercises { get; set; }
        
        [Option('d', "canonicaldatadirectory", Required = false,
            HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")]
        public string CanonicalDataDirectory { get; set; }

        [Option('c', "cachecanonicaldata", Required = false, Default = false,
            HelpText = "Use the cached canonical data and don't update the data.")]
        public bool CacheCanonicalData { get; set; }
    }
}