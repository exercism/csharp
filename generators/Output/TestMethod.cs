using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output
{
    public class TestMethod
    {
        private enum AssertType
        {
            Equal,
            Empty,
            Null,
            Throws,
            Boolean,
            Matches
        }
        
        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";
        private const string TemplateName = "TestMethod";

        private static readonly Render Renderer = new Render();

        private readonly HashSet<string> _inputParameterProperties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _constructorInputParameterProperties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public TestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            Input = new Dictionary<string, dynamic>(canonicalDataCase.Input, StringComparer.OrdinalIgnoreCase);
            Expected = canonicalDataCase.Expected;
            Property = canonicalDataCase.Property;
            TestMethodName = canonicalDataCase.Description.ToTestMethodName();
            TestMethodNameWithPath = string.Join(" - ", canonicalDataCase.DescriptionPath).ToTestMethodName();
            TestedClass = canonicalData.Exercise.ToTestedClassName();
            TestedMethod = canonicalDataCase.Property.ToTestedMethodName();
            Skip = canonicalDataCase.Index > 0;

            SetInputParameters(canonicalDataCase.Input.Keys.ToArray());
        }

        public string Property { get; }

        public IDictionary<string, dynamic> Input { get; set; }
        public dynamic Expected { get; set; }

        public bool Skip { get; set; }

        public bool UseVariablesForInput { get; set; }
        public bool UseVariableForExpected { get; set; }
        public bool UseVariablesForConstructorParameters { get; set; }
        public bool UseVariableForTested { get; set; }
        private bool UseVariableForSut 
            => TestedMethodType == TestedMethodType.InstanceMethod || 
               TestedMethodType == TestedMethodType.Property;

        public string TestMethodName { get; set; }
        public string TestMethodNameWithPath { get; }
        public string TestedClass { get; set; }
        public string TestedMethod { get; set; }
        public TestedMethodType TestedMethodType { get; set; }
        public Type ExceptionThrown { get; set; }

        public void SetInputParameters(params string[] properties)
        {
            _inputParameterProperties.Clear();
            _inputParameterProperties.UnionWith(properties);

            _constructorInputParameterProperties.ExceptWith(properties);
        }

        public void SetConstructorInputParameters(params string[] properties)
        {
            _constructorInputParameterProperties.Clear();
            _constructorInputParameterProperties.UnionWith(properties);

            _inputParameterProperties.ExceptWith(properties);

            if (TestedMethodType == TestedMethodType.StaticMethod)
                TestedMethodType = TestedMethodType.InstanceMethod;
        }

        public string SutValue => $"new {TestedClass}({ConstructorParameters})";
        public string TestedValue => UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public string ExpectedParameter => UseVariableForExpected ? ExpectedVariableName : Renderer.Object(Expected);
        
        private string InputParameters => string.Join(", ", _inputParameterProperties.Select(key => UseVariablesForInput ? key.ToVariableName() : Renderer.Object(Input[key])));
        private string ConstructorParameters => string.Join(", ", _constructorInputParameterProperties.Select(key => UseVariablesForConstructorParameters ? key.ToVariableName() : Renderer.Object(Input[key])));

        private string ExpectedVariableDeclaration => Renderer.Variable(ExpectedVariableName, Renderer.ObjectMultiLine(Expected));
        private IEnumerable<string> InputVariablesDeclaration => Renderer.Variables(_inputParameterProperties.ToDictionary(key => key, key => Input[key]));
        private IEnumerable<string> ConstructorVariablesDeclaration => Renderer.Variables(_constructorInputParameterProperties.ToDictionary(key => key, key => Input[key]));
        private IEnumerable<string> SutVariableDeclaration => new[] { Renderer.Variable(SutVariableName, SutValue) };
        private IEnumerable<string> ActualVariableDeclaration => new[] { Renderer.Variable(TestedVariableName, TestedMethodInvocation) };

        public IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (UseVariablesForInput)
                    lines.AddRange(InputVariablesDeclaration);

                if (UseVariablesForConstructorParameters)
                    lines.AddRange(ConstructorVariablesDeclaration);

                if (UseVariableForSut)
                    lines.AddRange(SutVariableDeclaration);

                if (UseVariableForTested)
                    lines.AddRange(ActualVariableDeclaration);

                if (UseVariableForExpected)
                    lines.Add(ExpectedVariableDeclaration);

                return lines;
            }
        }

        public string TestedMethodInvocation
        {
            get
            {
                switch (TestedMethodType)
                {
                    case TestedMethodType.StaticMethod:
                        return $"{TestedClass}.{TestedMethod}({InputParameters})";
                    case TestedMethodType.ExtensionMethod:
                        return $"{InputParameters}.{TestedMethod}()";
                    case TestedMethodType.InstanceMethod:
                        return $"{SutVariableName}.{TestedMethod}({InputParameters})";
                    case TestedMethodType.Property:
                        return $"{SutVariableName}.{TestedMethod}";
                    case TestedMethodType.Constructor:
                        return $"new {TestedClass}({ConstructorParameters})";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        
        

        public string Act { get; set; }
        public string Arrange { get; set; }
        public string Assert { get; set; }
        
        public string Render()
        {
            UpdateBasedOnCurrentAssertType();

            Arrange = Arrange ?? RenderArrange();
            Act = Act ?? RenderAct();
            Assert = Assert ?? RenderAssert();

            return Template.Render(TemplateName, new { Name = TestMethodName, Skip, Arrange, Act, Assert });
        }

        private string RenderArrange() => Template.Render("Arrange", new { Variables });

        private string RenderAct() => Template.Render("Act", new { });

        private string RenderAssert()
        {
            switch (CurrentAssertType)
            {
                case AssertType.Equal:
                    return Renderer.AssertEqual(ExpectedParameter, TestedValue);
                case AssertType.Empty:
                    return Renderer.AssertEmpty(ExpectedParameter, TestedValue);
                case AssertType.Null:
                    return Renderer.AssertNull(TestedValue);
                case AssertType.Throws:
                    return Renderer.AssertThrows(ExceptionThrown, TestedValue);
                case AssertType.Boolean:
                    return Renderer.AssertBoolean(Convert.ToBoolean(Expected), TestedValue);
                case AssertType.Matches:
                    return Renderer.AssertMatches(ExpectedParameter, TestedValue);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateBasedOnCurrentAssertType()
        {
            switch (CurrentAssertType)
            {
                case AssertType.Empty:
                    UseVariableForExpected = false;
                    break;
                case AssertType.Throws:
                    UseVariableForExpected = false;
                    UseVariableForTested = false;
                    break;
            }
        }

        private AssertType CurrentAssertType
        {
            get
            {
                if (ExceptionThrown != null)
                    return AssertType.Throws;

                switch (Expected)
                {
                    case null:
                        return AssertType.Null;
                    case bool _:
                        return AssertType.Boolean;
                    case Regex _:
                        return AssertType.Matches;
                    default:
                        return UseEmptyAssertion 
                            ? AssertType.Empty 
                            : AssertType.Equal;
                }
            }
        }

        private bool UseEmptyAssertion 
            => !(Expected is string) && Expected is IEnumerable enumerable && enumerable.GetEnumerator().MoveNext() == false;
    }
}