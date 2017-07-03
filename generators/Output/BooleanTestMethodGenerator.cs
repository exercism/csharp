using System;
using System.Collections.Generic;
using System.Linq;

namespace Generators.Output
{
    public class BooleanTestMethodGenerator : TestMethodGenerator
    {
        protected override IEnumerable<string> Body => Variables.Append($"Assert.{BooleanAssertMethod}({TestedValue});");

        private string BooleanAssertMethod => Convert.ToBoolean(CanonicalDataCase.Expected).ToString();
    }
}