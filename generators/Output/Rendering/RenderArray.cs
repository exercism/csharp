using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Array<T>(T[] elements) =>
            elements.Length == 0
                ? $"Array.Empty<{typeof(T).ToFriendlyName()}>()"
                : $"new[]{CollectionInitializer(elements)}";

        public string ArrayMultiLine<T>(T[] elements) 
            => elements.Length == 0
                ? $"Array.Empty<{typeof(T).ToFriendlyName()}>()" 
                : $"new[]{MultiLineCollectionInitializer(elements)}";

        public string Array<T>(T[,] elements) 
            => elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,]{CollectionInitializer(elements.Rows())}";

        public string ArrayMultiLine<T>(T[,] elements) 
            => elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,]{MultiLineCollectionInitializer(elements.Rows(), CollectionInitializer)}";
    }
}