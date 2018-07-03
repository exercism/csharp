﻿using System;
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

        private static bool IsList(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(List<>);

        private static bool IsArray(object obj)
            => obj.GetType().IsArray;

        private static bool IsDictionary(object obj)
            => obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>);
    }
}