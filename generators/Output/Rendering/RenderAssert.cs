using System;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public string AssertNull(string actual) 
            => RenderTemplate("AssertNull", new { actual });
        
        public string AssertEmpty(string expected, string actual) 
            => RenderTemplate("AssertEmpty", new { expected, actual });
        
        public string AssertEqual(string expected, string actual) 
            => RenderTemplate("AssertEqual", new { expected, actual });
        
        public string AssertEqualWithin(string expected, string actual, int precision) 
            => RenderTemplate("AssertEqualWithin", new { expected, actual, precision });
        
        public string AssertNotEqual(string expected, string actual) 
            => RenderTemplate("AssertNotEqual", new { expected, actual });
        
        public string AssertBoolean(bool expected, string actual) 
            => RenderTemplate("AssertBoolean", new { expected = expected.ToString(), actual });
        
        public string AssertMatches(string expected, string actual) 
            => RenderTemplate("AssertMatches", new { expected, actual });
        
        public string AssertInRange(string expected, string lower, string upper) 
            => RenderTemplate("AssertInRange", new { expected, lower, upper });
        
        public string AssertThrows(Type expectedException, string actual) 
            => RenderTemplate("AssertThrows", new { expected = expectedException.Name, actual });
        
        public string AssertThrows<T>(string actual) 
            => AssertThrows(typeof(T), actual);
        
        private static string RenderTemplate(string template, object parameters)
            => Template.Render(template, parameters);
    }
}