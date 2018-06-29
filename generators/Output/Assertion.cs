using System;
using System.Collections.Generic;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Output
{
    public static class Assertion
    {
        public static IEnumerable<string> Null(string testedValue) 
            => Render("AssertNull", new { TestedValue = testedValue });
        
        public static IEnumerable<string> Empty(string testedValue, string expectedParameter) 
            => Render("AssertEmpty", new { TestedValue = testedValue, ExpectedParameter = expectedParameter });
        
        public static IEnumerable<string> Equal(string testedValue, string expectedParameter) 
            => Render("AssertEqual", new { TestedValue = testedValue, ExpectedParameter = expectedParameter });
        
        public static IEnumerable<string> Exception(string testedValue, Type exceptionType) 
            => Render("AssertException", new { TestedValue = testedValue, ExceptionType = exceptionType.Name });
        
        public static IEnumerable<string> Boolean(string testedValue, bool expected) 
            => Render("AssertBoolean", new { TestedValue = testedValue, BooleanAssertMethod = expected.ToString() });
        
        private static IEnumerable<string> Render(string template, object parameters)
            => new[] { TemplateRenderer.RenderPartial(template, parameters) };
    }
}