using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class ExpectedDataBinaryTree
    {
        public ExpectedDataBinaryTree(IReadOnlyDictionary<string, object> treeNode)
        {
            Value = treeNode["data"] as string;
            if (treeNode["left"] != null) Left = new ExpectedDataBinaryTree(treeNode["left"] as Dictionary<string, object>);
            if (treeNode["right"] != null) Right = new ExpectedDataBinaryTree(treeNode["right"] as Dictionary<string, object>);
        }

        public string Value { get; }
        public ExpectedDataBinaryTree Left { get; }
        public ExpectedDataBinaryTree Right { get; }
    }

    public class BinarySearchTree : GeneratorExercise
    {
        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IQueryable).Namespace);
        }

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

            if (testMethod.Expected is Dictionary<string, object> expected)
            {
                var tree = new ExpectedDataBinaryTree(expected);
                foreach (var testAssert in TestAsserts(tree))
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

        private IEnumerable<string> TestAsserts(ExpectedDataBinaryTree tree, string traverse = "")
        {
            yield return Render.AssertEqual(tree.Value, $"tree{traverse}.Value");
            if (tree.Left != null) foreach (var assert in TestAsserts(tree.Left, $"{traverse}.Left")) yield return assert;
            if (tree.Right != null) foreach (var assert in TestAsserts(tree.Right, $"{traverse}.Right")) yield return assert;
        }
    }
}