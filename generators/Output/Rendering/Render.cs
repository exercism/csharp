using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
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
                case DateTime dateTime: return DateTime(dateTime);
                case Regex regex: return Regex(regex);
                case BigInteger bigInt: return BigInteger(bigInt);
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
            if (val == null)
                return "null";

            switch (val)
            {
                case MultiLineString multiLineValue:
                    return StringMultiLine(multiLineValue);
                default:
                    if (IsDictionary(val))
                        return DictionaryMultiLine((dynamic) val);

                    if (IsArray(val))
                        return RenderArrayAsMultiline((dynamic) val) 
                            ? ArrayMultiLine((dynamic) val)
                            : Array((dynamic) val);

                    return Object(val);
            }
        }

        private static bool IsList(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(List<>);

        private static bool IsArray(object obj)
            => obj.GetType().IsArray;

        private static bool IsDictionary(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>);
        
        private static bool RenderArrayAsMultiline<T>(T[,] _) => true;

        private static bool RenderArrayAsMultiline<T>(T[] elements)
            => IsNestedArray(elements) && elements.Length > 0;

        private static bool IsNestedArray<T>(T[] elements) 
            => elements.GetType().GetElementType().IsArray;
    }
}