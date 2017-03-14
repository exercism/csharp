﻿using System.Collections.Generic;
using System.Linq;

namespace Generators
{
    public static class TestClassRenderer
    {
        private const string TestClassTemplate =
@"{UsingNamespaces}

public class {ClassName}Test
{
{Body}
}";

        public static string Render(TestClass testClass) =>
            TestClassTemplate
                .Replace("{UsingNamespaces}", RenderUsingNamespaces(testClass))
                .Replace("{ClassName}", testClass.ClassName)
                .Replace("{Body}", RenderBody(testClass));

        private static string RenderUsingNamespaces(TestClass testClass) =>
           string.Join("\n", testClass.UsingNamespaces.Select(usingNamespace => $"using {usingNamespace};"));

        private static string RenderBody(TestClass testClass) =>
           string.Join("\n\n", GetBodyParts(testClass));

        private static IEnumerable<string> GetBodyParts(TestClass testClass) =>
            from bodyPart in new [] { testClass.BeforeTestMethods, RenderTestMethods(testClass), testClass.AfterTestMethods }
            where !string.IsNullOrWhiteSpace(bodyPart)
            select bodyPart;

        private static string RenderTestMethods(TestClass testClass) =>
           string.Join("\n\n", testClass.TestMethods.Select(TestMethodRenderer.Render));
    }
}
