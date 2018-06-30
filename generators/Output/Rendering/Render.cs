using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Exercism.CSharp.Helpers;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {   
        public string Object(object val)
        {
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
                case List<int> ints: return List(ints);
                case List<object> objects: return List(objects);
                case IEnumerable<int> ints: return Array(ints);
                case IEnumerable<string> strings: return Array(strings);
                case IEnumerable<UnescapedValue> unescapedValues when unescapedValues.Any(): return Array(unescapedValues);
                case IDictionary<string, object> dict: return Dictionary(dict);
                case IDictionary<char, int> dict: return Dictionary(dict);
                case IDictionary<string, int> dict: return Dictionary(dict);
                case IDictionary<int, string[]> dict: return Dictionary(dict);
                case JArray jArray: return Array(jArray);
                case int[,] multidimensionalArray: return MultidimensionalArray(multidimensionalArray);
                case IEnumerable<ValueTuple<int, int>> tuples: return Array(tuples);
                case IEnumerable<Tuple<string, object>> tuples: return Array(tuples);
                case IEnumerable<object> objects: return Array(objects);
                default: return val?.ToString();
            }
        }
    }
}