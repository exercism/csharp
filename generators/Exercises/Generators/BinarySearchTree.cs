﻿using System.Collections.Generic;
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

        private StringBuilder _testFactCodeLines;
        private void AddCodeLine(string line) => _testFactCodeLines.Append(line + "\r\n");

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
        {
            _testFactCodeLines = new StringBuilder();
            var canonicalDataCase = method.Data;
            var input = canonicalDataCase.Input as Dictionary<string, object>;
            var constructorData = input["treeData"] as string[];

            if (constructorData.Length == 1) AddCodeLine($"var tree = new BinarySearchTree({constructorData[0]});");
            else
            {
                var constructorDataString = string.Join(", ", constructorData);
                AddCodeLine($"var tree = new BinarySearchTree(new[] {{ {constructorDataString} }});");
            }

            if (canonicalDataCase.Expected is Dictionary<string, object> expected)
            {
                var tree = new ExpectedDataBinaryTree(expected);
                foreach (var assert in TestAsserts(tree))
                    AddCodeLine(assert);
            }
            else
            {
                var expectedNumbers = ((string[]) canonicalDataCase.Expected).Select(int.Parse).ToArray();
                var expectedRendered = Render.Object(expectedNumbers);
                AddCodeLine(Render.AssertEqual(expectedRendered, "tree.AsEnumerable()"));
            }

            return _testFactCodeLines.ToString();
        }

        private IEnumerable<string> TestAsserts(ExpectedDataBinaryTree tree, string traverse = "")
        {
            yield return Render.AssertEqual(tree.Value, $"tree{traverse}.Value");
            if (tree.Left != null) foreach (var assert in TestAsserts(tree.Left, traverse + ".Left")) yield return assert;
            if (tree.Right != null) foreach (var assert in TestAsserts(tree.Right, traverse + ".Right")) yield return assert;
        }
    }
}