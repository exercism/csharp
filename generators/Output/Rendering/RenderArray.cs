using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        private const int MaximumLengthForSingleLineValue = 68;
        
        public string Array<T>(T[] elements) =>
            elements.Length == 0
                ? $"Array.Empty<{typeof(T).ToFriendlyName()}>()"
                : $"new[]{CollectionInitializer(elements)}";

        public string ArrayMultiLine<T>(T[] elements) 
            => RenderAsSingleLine(elements) 
                ? Array(elements) 
                : $"new[]{MultiLineCollectionInitializer(elements)}";

        public string Array<T>(T[,] elements) 
            => elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,]{CollectionInitializer(elements.Rows())}";

        public string ArrayMultiLine<T>(T[,] elements) 
            => elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,]{MultiLineCollectionInitializer(elements.Rows(), CollectionInitializer)}";
        
        private bool RenderAsSingleLine<T>(T[] elements) 
            => !elements.Any() || IsNotArrayOfArrays(elements) && RenderedAsSingleLineDoesNotExceedMaximumLength(elements);

        private static bool IsNotArrayOfArrays<T>(T[] elements) 
            => !elements.GetType().GetElementType().IsArray;

        private bool RenderedAsSingleLineDoesNotExceedMaximumLength<T>(T[] elements) 
            => Array(elements).Length <= MaximumLengthForSingleLineValue;
    }
}