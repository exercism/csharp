using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Generators
{
    public class GeneratorCollection : IEnumerable<Generator>
    {
        private readonly IEnumerable<Generator> generators = GetDefinedGenerators();

        public IEnumerator<Generator> GetEnumerator() => generators.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static IEnumerable<Generator> GetDefinedGenerators() =>
            from type in Assembly.GetEntryAssembly().GetTypes()
            where typeof(Generator).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract
            select (Generator)Activator.CreateInstance(type);
    }
}