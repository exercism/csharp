using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generators.Output;
using Generators.Output.Templates;

namespace Generators.Exercises
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

        public IEnumerable<string> TestAsserts(string traverse = "")
        {
            yield return $"Assert.Equal({Value}, tree{traverse}.Value);";
            if (Left != null) foreach (var assert in Left.TestAsserts(traverse + ".Left")) yield return assert;
            if (Right != null) foreach (var assert in Right.TestAsserts(traverse + ".Right")) yield return assert;
        }
    }

    public class BinarySearchTree : GeneratorExercise
    {
        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IQueryable).Namespace);
        }

        private StringBuilder _testFactCodeLines;
        private void AddCodeLine(string line) => _testFactCodeLines.Append(line + "\r\n");

        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        protected IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            _testFactCodeLines = new StringBuilder();
            var canonicalDataCase = testMethodBody.Data;
            var input = canonicalDataCase.Properties["input"] as Dictionary<string, object>;
            var constructorData = input["treeData"] as string[];

            if (constructorData.Length == 1) AddCodeLine($"var tree = new BinarySearchTree({constructorData[0]});");
            else
            {
                var constructorDataString = string.Join(", ", constructorData);
                AddCodeLine($"var tree = new BinarySearchTree(new[] {{ {constructorDataString} }});");
            }

            if (canonicalDataCase.Properties["expected"] is Dictionary<string, object> expected)
            {
                var tree = new ExpectedDataBinaryTree(expected);
                foreach (var assert in tree.TestAsserts())
                    AddCodeLine(assert);
            }
            else
            {
                var expectedArrayString = string.Join(", ", canonicalDataCase.Properties["expected"] as string[]);
                AddCodeLine($"Assert.Equal(new[] {{ {expectedArrayString} }}, tree.AsEnumerable());");
            }

            return new[] { TemplateRenderer.RenderInline(_testFactCodeLines.ToString(), testMethodBody.AssertTemplateParameters) };
        }
    }
}