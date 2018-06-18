using System.Collections.Generic;
using System.Text;
using Generators.Output;

namespace Generators.Exercises
{
    public class ExpectedDataBinaryTree
    {
        public ExpectedDataBinaryTree(System.Collections.Generic.Dictionary<string, object> treeNode)
        {
            Value = treeNode["data"] as string;
            if (treeNode["left"] != null) this.Left = new ExpectedDataBinaryTree(treeNode["left"] as System.Collections.Generic.Dictionary<string, object>);
            if (treeNode["right"] != null) this.Right = new ExpectedDataBinaryTree(treeNode["right"] as System.Collections.Generic.Dictionary<string, object>);
        }

        public int Level { get; }
        public string Value { get; }
        public ExpectedDataBinaryTree Left { get; private set; }
        public ExpectedDataBinaryTree Right { get; private set; }

        public IEnumerable<string> TestAsserts(string traverse = "")
        {
            yield return $"Assert.Equal({this.Value}, tree{traverse}.Value);";
            if (this.Left != null) foreach (var assert in this.Left.TestAsserts(traverse + ".Left")) yield return assert;
            if (this.Right != null) foreach (var assert in this.Right.TestAsserts(traverse + ".Right")) yield return assert;
        }
    }

    public class BinarySearchTree : GeneratorExercise
    {
        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(System.Linq.IQueryable).Namespace };

        private StringBuilder testFactCodeLines;
        void addCodeLine(string line) => testFactCodeLines.Append(line + "\r\n");

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            testFactCodeLines = new StringBuilder();
            var canonicalDataCase = testMethodBody.CanonicalDataCase;
            var input = canonicalDataCase.Properties["input"] as System.Collections.Generic.Dictionary<string, object>;
            var constructorData = input["treeData"] as string[];

            if (constructorData.Length == 1) addCodeLine($"var tree = new BinarySearchTree({constructorData[0]});");
            else
            {
                var constructorDataString = string.Join(", ", constructorData);
                addCodeLine($"var tree = new BinarySearchTree(new[] {{ {constructorDataString} }});");
            }

            var expected = canonicalDataCase.Properties["expected"] as System.Collections.Generic.Dictionary<string, object>;
            if (expected != null)
            {
                var tree = new ExpectedDataBinaryTree(expected as System.Collections.Generic.Dictionary<string, object>);
                foreach (var assert in tree.TestAsserts())
                    addCodeLine(assert);
            }
            else
            {
                var expectedArrayString = string.Join(", ", canonicalDataCase.Properties["expected"] as string[]);
                addCodeLine($"Assert.Equal(new[] {{ {expectedArrayString} }}, tree.AsEnumerable());");
            }

            return new[] { TemplateRenderer.RenderInline(testFactCodeLines.ToString(), testMethodBody.AssertTemplateParameters) };
        }
    }
}