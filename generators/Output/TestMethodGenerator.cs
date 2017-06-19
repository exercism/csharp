﻿using System.Collections.Generic;
using System.Linq;

namespace Generators.Output
{
    public abstract class TestMethodGenerator
    {
        public TestMethod Create(TestMethodData testMethodData)
        {
            TestMethodData = testMethodData;

            return new TestMethod
            {
                UsingNamespaces = UsingNamespaces,
                MethodName = MethodName,
                Body = Body
            };
        }

        protected TestMethodData TestMethodData { get; private set; }

        protected abstract IEnumerable<string> Body { get; }

        protected virtual ISet<string> UsingNamespaces 
            => new HashSet<string>();

        protected virtual string MethodName
            => TestMethodData.CanonicalDataCase.Description.ToTestMethodName();

        protected virtual string TestedClassName
            => TestMethodData.CanonicalData.Exercise.ToTestedClassName();

        protected virtual string TestedMethod
            => TestMethodData.CanonicalDataCase.Property.ToTestedMethodName();

        protected virtual object Input => FormatInputValue(TestMethodData.CanonicalDataCase.Input);

        protected virtual object FormatInputValue(object val)
        {
            switch (val)
            {
                case IDictionary<string, object> dict:
                    return string.Join(", ", dict.Values.Select(FormatInputValue));
                case string s:
                    return $"\"{s.Replace("\n", "\\n").Replace("\t", "\\t").Replace("\r", "\\r")}\"";
                default:
                    return val;
            }
        }

        protected virtual object Expected => 
            TestMethodData.Options.ExpectedFormat  == ExpectedFormat.Unformatted
                ? TestMethodData.CanonicalDataCase.Expected
                : FormatExpectedValue(TestMethodData.CanonicalDataCase.Expected);

        protected virtual object FormatExpectedValue(object val)
        {
            switch (val)
            {
                case string s:
                    return $"\"{s}\"";
                case IEnumerable<string> enumerable:
                    return enumerable.Select(FormatExpectedValue);
                default:
                    return val;
            }
        }
    }
}