using System.Collections.Generic;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        private const int MaximumLengthForSingleLineValue = 68;
        
        public string Object(object val)
        {
            if (val == null)
                return "null";

            switch (val)
            {
                case string str: return String(str);
                case double dbl: return Double(dbl);
                case int i: return Int(i);
                case uint ui: return Uint(ui);
                case float flt: return Float(flt);
                case ulong ulng: return Ulong(ulng);
                case char c: return Char(c);
                default:
                    if (IsList(val))
                        return List((dynamic)val);

                    if (IsArray(val))
                        return Array((dynamic)val);

                    if (IsDictionary(val))
                        return Dictionary((dynamic)val);

                    return val.ToString();
            }
        }

        public string ObjectMultiLine(object val)
        {
            switch (val)
            {
                case MultiLineString multiLineValue:
                    return StringMultiLine(multiLineValue);
                default:
                    if (IsDictionary(val))
                        return DictionaryMultiLine((dynamic) val);

                    if (IsArray(val))
                        return RenderAsSingleLine((dynamic)val) 
                            ? Array((dynamic) val)
                            : ArrayMultiLine((dynamic) val);

                    return Object(val);
            }
        }

        private static bool IsList(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(List<>);

        private static bool IsArray(object obj)
            => obj.GetType().IsArray;

        private static bool IsDictionary(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>);
        
        private bool RenderAsSingleLine<T>(T[] elements) 
            => !elements.Any() || IsNotArrayOfArrays(elements) && RenderedAsSingleLineDoesNotExceedMaximumLength(elements);

        private bool RenderAsSingleLine<T>(T[,] elements) => false;

        private static bool IsNotArrayOfArrays<T>(T[] elements) 
            => !elements.GetType().GetElementType().IsArray;

        private bool RenderedAsSingleLineDoesNotExceedMaximumLength<T>(T[] elements) 
            => Array(elements).Length <= MaximumLengthForSingleLineValue;
    }
}