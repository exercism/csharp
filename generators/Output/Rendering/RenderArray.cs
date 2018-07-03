using System;
using System.Linq;
using Exercism.CSharp.Helpers;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        private const int MaximumLengthForSingleLineValue = 68;
        
        public string Array<T>(T[] elements) =>
            elements.Any()
                ? $"new[] {{ {string.Join(", ", elements.Cast<object>().Select(Object))} }}"
                : $"Array.Empty<{typeof(T).ToFriendlyName()}>()";

        public string ArrayMultiLine<T>(T[] elements)
        {
            if (RenderAsSingleLine())
                return Array(elements);

            return $"new[]{Environment.NewLine}{{{Environment.NewLine}{string.Join($",{Environment.NewLine}", elements.Cast<object>().Select(Object).Select(line => line.Indent()))}{Environment.NewLine}}}";

            bool RenderAsSingleLine() => !elements.Any() || IsNotArrayOfArrays() && RenderedAsSingleLineDoesNotExceedMaximumLength();
            bool IsNotArrayOfArrays() => !elements.GetType().GetElementType().IsArray;
            bool RenderedAsSingleLineDoesNotExceedMaximumLength() => Array(elements).Length <= MaximumLengthForSingleLineValue;
        }

        public string Array<T>(T[,] elements)
        {
            return elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,] {{ {string.Join(", ", elements.Rows().Select(RenderRow))} }}";

            string RenderRow(T[] row) => $"{{ {string.Join(", ", row.Cast<object>().Select(Object))} }}";
        }

        public string ArrayMultiLine<T>(T[,] elements)
        {
            return elements.Length == 0 
                ? $"new {typeof(T).ToFriendlyName()}[,] {{ }}" 
                : $"new[,]{Environment.NewLine}{{{Environment.NewLine}{string.Join($",{Environment.NewLine}", elements.Rows().Select(RenderRow))}{Environment.NewLine}}}";

            string RenderRow(T[] row) => $"{{ {string.Join(", ", row.Cast<object>().Select(Object))} }}".Indent();
        }
    }
}