using System;
using System.Collections.Generic;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string Object(object val)
        {
            if (val == null)
                return null;

            switch (val)
            {
                case string str: return String(str);
                case MultiLineString multiLineString: return String(multiLineString.ToString());
                case double dbl: return Double(dbl);
                case int i: return Int(i);
                case float flt: return Float(flt);
                case ulong ulng: return Ulong(ulng);
                case char c: return Char(c);
                case Tuple<string, object> tuple: return Tuple(tuple);
                case int[,] multidimensionalArray: return MultidimensionalArray(multidimensionalArray);
                default:
                    if (RenderList(val))
                        return List((dynamic)val);

                    if (RenderArray(val))
                        return Array((dynamic)val);

                    if (RenderDictionary(val))
                        return Dictionary((dynamic)val);

                    return val.ToString();
            }
        }

        private static bool RenderList(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(List<>);

        private static bool RenderArray(object obj)
            => obj.GetType().IsArray;

        private static bool RenderDictionary(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>);
    }
}