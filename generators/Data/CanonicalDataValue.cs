using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Data
{
    public static class CanonicalDataValue
    {
        public static string ExpectedToMultiLineString(object expected)
        {
            switch (expected)
            {
                case IEnumerable<string> enumerable:
                    return string.Join("\\n\"+\n\"", enumerable);
                case JArray jarray:
                    return ExpectedToMultiLineString(((JArray) expected).Values<string>());
                case string str:
                    return ExpectedToMultiLineString(str.Split('\n'));
                default:
                    throw new ArgumentException("Cannot convert expected value to multil-ine string.");
            }
        }
    }
}
