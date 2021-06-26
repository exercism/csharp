using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class BinarySearchTree : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();

            var treeData = ConvertToIntegers(testMethod.Input["treeData"]);
            var constructorParameters = Render.Object(treeData.Length == 1 ? treeData[0] : treeData);
            assert.AppendLine(Render.Variable("tree", $"new BinarySearchTree({constructorParameters})"));

            if (testMethod.Expected is Dictionary<string, object>)
            {
                foreach (var testAssert in TestAsserts(testMethod.Expected))
                    assert.AppendLine(testAssert);
            }
            else
            {
                var renderedExpected = Render.Object(ConvertToIntegers(testMethod.Expected));
                assert.AppendLine(Render.AssertEqual(renderedExpected, "tree.AsEnumerable()"));
            }

            return assert.ToString();
        }

        private static int[] ConvertToIntegers(dynamic data) => ((string[]) data).Select(int.Parse).ToArray();

        private IEnumerable<string> TestAsserts(dynamic tree, string traverse = "")
        {
            yield return Render.AssertEqual(tree["data"], $"tree{traverse}.Value");
            if (tree["left"] != null) foreach (var assert in TestAsserts(tree["left"], $"{traverse}.Left")) yield return assert;
            if (tree["right"] != null) foreach (var assert in TestAsserts(tree["right"], $"{traverse}.Right")) yield return assert;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IQueryable).Namespace);
        }
    }
}