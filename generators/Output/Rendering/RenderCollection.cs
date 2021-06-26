using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    internal partial class Render
    {   
        public string CollectionInitializer<T>(IEnumerable<T> elements)
            => CollectionInitializer(elements, line => Object(line), " ");
        
        public string CollectionInitializer<T>(IEnumerable<T> elements, Func<T, string> render)
            => CollectionInitializer(elements, render, " ");
        
        public string MultiLineCollectionInitializer<T>(IEnumerable<T> elements)
            => CollectionInitializer(elements, line => Object(line).Indent(), Environment.NewLine);
        
        public string MultiLineCollectionInitializer<T>(IEnumerable<T> elements, Func<T, string> render)
            => CollectionInitializer(elements, line => render(line).Indent(), Environment.NewLine);
        
        private static string CollectionInitializer<T>(IEnumerable<T> elements, Func<T, string> render, string separator)
            => $"{separator}{{{separator}{string.Join($",{separator}", elements.Select(render))}{separator}}}";
    }
}