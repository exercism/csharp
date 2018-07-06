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
    public class TestMethodOutput
    {
        private readonly TestMethod _testMethod;

        public TestMethodOutput(TestMethod testMethod) => _testMethod = testMethod;

        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";

        private static readonly Render Renderer = new Render();

        public string SutValue => $"new {_testMethod.TestedClass}({ConstructorParameters})";
        public string TestedValue => _testMethod.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public string ExpectedParameter => _testMethod.UseVariableForExpected ? ExpectedVariableName : Renderer.Object(_testMethod.Expected);
        
        private string InputParameters => string.Join(", ", _testMethod.InputParameters.Select(key => _testMethod.UseVariablesForInput ? key.ToVariableName() : Renderer.Object(_testMethod.Input[key])));
        private string ConstructorParameters => string.Join(", ", _testMethod.ConstructorInputParameters.Select(key => _testMethod.UseVariablesForConstructorParameters ? key.ToVariableName() : Renderer.Object(_testMethod.Input[key])));

        private string ExpectedVariableDeclaration => Renderer.Variable(ExpectedVariableName, Renderer.ObjectMultiLine(_testMethod.Expected));
        private IEnumerable<string> InputVariablesDeclaration => Renderer.Variables(_testMethod.InputParameters.ToDictionary(key => key, key => _testMethod.Input[key]));
        private IEnumerable<string> ConstructorVariablesDeclaration => Renderer.Variables(_testMethod.ConstructorInputParameters.ToDictionary(key => key, key => _testMethod.Input[key]));
        private IEnumerable<string> SutVariableDeclaration => new[] { Renderer.Variable(SutVariableName, SutValue) };
        private IEnumerable<string> ActualVariableDeclaration => new[] { Renderer.Variable(TestedVariableName, TestedMethodInvocation) };

        public IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (_testMethod.UseVariablesForInput)
                    lines.AddRange(InputVariablesDeclaration);

                if (_testMethod.UseVariablesForConstructorParameters)
                    lines.AddRange(ConstructorVariablesDeclaration);

                if (_testMethod.UseVariableForSut)
                    lines.AddRange(SutVariableDeclaration);

                if (_testMethod.UseVariableForTested)
                    lines.AddRange(ActualVariableDeclaration);

                if (_testMethod.UseVariableForExpected)
                    lines.Add(ExpectedVariableDeclaration);

                return lines;
            }
        }

        public string TestedMethodInvocation
        {
            get
            {
                switch (_testMethod.TestedMethodType)
                {
                    case TestedMethodType.StaticMethod:
                        return $"{_testMethod.TestedClass}.{_testMethod.TestedMethod}({InputParameters})";
                    case TestedMethodType.ExtensionMethod:
                        return $"{InputParameters}.{_testMethod.TestedMethod}()";
                    case TestedMethodType.InstanceMethod:
                        return $"{SutVariableName}.{_testMethod.TestedMethod}({InputParameters})";
                    case TestedMethodType.Property:
                        return $"{SutVariableName}.{_testMethod.TestedMethod}";
                    case TestedMethodType.Constructor:
                        return $"new {_testMethod.TestedClass}({ConstructorParameters})";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public string Render()
        {
            UpdateBasedOnCurrentAssertType();

            _testMethod.Arrange = _testMethod.Arrange ?? RenderArrange();
            _testMethod.Act = _testMethod.Act ?? RenderAct();
            _testMethod.Assert = _testMethod.Assert ?? RenderAssert();

            return Template.Render("TestMethod", new { Name = _testMethod.TestMethodName, _testMethod.Skip, _testMethod.Arrange, _testMethod.Act, _testMethod.Assert });
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
                    return Renderer.AssertThrows(_testMethod.ExceptionThrown, TestedValue);
                case AssertType.Boolean:
                    return Renderer.AssertBoolean(Convert.ToBoolean(_testMethod.Expected), TestedValue);
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
                    _testMethod.UseVariableForExpected = false;
                    break;
                case AssertType.Throws:
                    _testMethod.UseVariableForExpected = false;
                    _testMethod.UseVariableForTested = false;
                    break;
            }
        }

        private AssertType CurrentAssertType
        {
            get
            {
                if (_testMethod.ExceptionThrown != null)
                    return AssertType.Throws;

                switch (_testMethod.Expected)
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
            => !(_testMethod.Expected is string) && _testMethod.Expected is IEnumerable enumerable && enumerable.GetEnumerator().MoveNext() == false;

        private enum AssertType
        {
            Equal,
            Empty,
            Null,
            Throws,
            Boolean,
            Matches
        }
    }
}