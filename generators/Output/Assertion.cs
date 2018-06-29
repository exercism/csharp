using System;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Output
{
    public static class Assertion
    {
        public static string Null(string actual) 
            => Render("AssertNull", new { actual });
        
        public static string Empty(string expected, string actual) 
            => Render("AssertEmpty", new { expected, actual });
        
        public static string Equal(string expected, string actual) 
            => Render("AssertEqual", new { expected, actual });
        
        public static string EqualWithin(string expected, string actual, int precision) 
            => Render("AssertEqualWithin", new { expected, actual, precision });
        
        public static string NotEqual(string expected, string actual) 
            => Render("AssertNotEqual", new { expected, actual });
        
        public static string Boolean(bool expected, string actual) 
            => Render("AssertBoolean", new { expected = expected.ToString(), actual });
        
        public static string Matches(string expected, string actual) 
            => Render("AssertMatches", new { expected, actual });
        
        public static string Throws(Type expectedException, string actual) 
            => Render("AssertThrows", new { expected = expectedException.Name, actual });
        
        public static string Throws<T>(string actual) 
            => Throws(typeof(T), actual);
        
        private static string Render(string template, object parameters)
            => TemplateRenderer.RenderPartial(template, parameters);
    }
}