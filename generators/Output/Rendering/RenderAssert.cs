using System;

namespace Exercism.CSharp.Output.Rendering
{
    public class RenderAssert
    {
        public string Null(string actual) 
            => Render("AssertNull", new { actual });
        
        public string Empty(string expected, string actual) 
            => Render("AssertEmpty", new { expected, actual });
        
        public string Equal(string expected, string actual) 
            => Render("AssertEqual", new { expected, actual });
        
        public string EqualWithin(string expected, string actual, int precision) 
            => Render("AssertEqualWithin", new { expected, actual, precision });
        
        public string NotEqual(string expected, string actual) 
            => Render("AssertNotEqual", new { expected, actual });
        
        public string Boolean(bool expected, string actual) 
            => Render("AssertBoolean", new { expected = expected.ToString(), actual });
        
        public string Matches(string expected, string actual) 
            => Render("AssertMatches", new { expected, actual });
        
        public string Throws(Type expectedException, string actual) 
            => Render("AssertThrows", new { expected = expectedException.Name, actual });
        
        public string Throws<T>(string actual) 
            => Throws(typeof(T), actual);
        
        private static string Render(string template, object parameters)
            => Template.Render(template, parameters);
    }
}