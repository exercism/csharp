using System;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Output
{
    public static class Assertion
    {
        public static string Null(string testedValue) 
            => Render("AssertNull", new { TestedValue = testedValue });
        
        public static string Empty(string testedValue, string expectedParameter) 
            => Render("AssertEmpty", new { TestedValue = testedValue, ExpectedParameter = expectedParameter });
        
        public static string Equal(string testedValue, string expectedParameter) 
            => Render("AssertEqual", new { TestedValue = testedValue, ExpectedParameter = expectedParameter });
        
        public static string Exception(string testedValue, Type exceptionType) 
            => Render("AssertException", new { TestedValue = testedValue, ExceptionType = exceptionType.Name });
        
        public static string Boolean(string testedValue, bool expected) 
            => Render("AssertBoolean", new { TestedValue = testedValue, BooleanAssertMethod = expected.ToString() });
        
        private static string Render(string template, object parameters)
            => TemplateRenderer.RenderPartial(template, parameters);
    }
}