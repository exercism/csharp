using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output
{
    internal class TestMethodOutput
    {
        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";
        
        private static readonly Render Renderer = new Render();
        private readonly TestMethod _testMethod;

        public TestMethodOutput(TestMethod testMethod) => _testMethod = testMethod;

        private IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (_testMethod.UseVariablesForInput)
                    lines.AddRange(InputVariables);

                if (_testMethod.UseVariablesForConstructorParameters)
                    lines.AddRange(ConstructorVariables);

                if (_testMethod.UseVariableForSut)
                    lines.Add(SutVariableDeclaration);

                if (_testMethod.UseVariableForTested)
                    lines.Add(TestedVariable);

                if (_testMethod.UseVariableForExpected)
                    lines.Add(ExpectedVariable);

                return lines;
            }
        }
        
        private IEnumerable<string> InputVariables => Renderer.Variables(_testMethod.InputParameters.ToDictionary(key => key, key => _testMethod.Input[key]));
        private string InputValues => string.Join(", ", _testMethod.InputParameters.Select(key => _testMethod.UseVariablesForInput ? key.ToVariableName() : Renderer.Object(_testMethod.Input[key])));
        
        private IEnumerable<string> ConstructorVariables => Renderer.Variables(_testMethod.ConstructorInputParameters.ToDictionary(key => key, key => _testMethod.Input[key]));
        private string ConstructorValues => string.Join(", ", _testMethod.ConstructorInputParameters.Select(key => _testMethod.UseVariablesForConstructorParameters ? key.ToVariableName() : Renderer.Object(_testMethod.Input[key])));
        
        private string SutVariableDeclaration => Renderer.Variable(SutVariableName, SutParameter);
        private string SutParameter => _testMethod.UseVariableForSut ? $"new {_testMethod.TestedClass}({ConstructorValues})" : SutVariableName;
        
        private string TestedVariable => Renderer.Variable(TestedVariableName, TestedMethodInvocation);
        private string TestedValue => _testMethod.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        
        private string ExpectedVariable => Renderer.Variable(ExpectedVariableName, Renderer.ObjectMultiLine(_testMethod.Expected));
        private string ExpectedValue => _testMethod.UseVariableForExpected ? ExpectedVariableName : Renderer.Object(_testMethod.Expected);
        
        private string TestedMethodInvocation
        {
            get
            {
                switch (_testMethod.TestedMethodType)
                {
                    case TestedMethodType.StaticMethod:
                        return $"{_testMethod.TestedClass}.{_testMethod.TestedMethod}({InputValues})";
                    case TestedMethodType.ExtensionMethod:
                        return $"{InputValues}.{_testMethod.TestedMethod}()";
                    case TestedMethodType.InstanceMethod:
                        return $"{SutVariableName}.{_testMethod.TestedMethod}({InputValues})";
                    case TestedMethodType.Property:
                        return $"{SutVariableName}.{_testMethod.TestedMethod}";
                    case TestedMethodType.Constructor:
                        return $"new {_testMethod.TestedClass}({ConstructorValues})";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public string Render()
        {
            Update();

            _testMethod.Arrange = _testMethod.Arrange ?? RenderArrange();
            _testMethod.Act = _testMethod.Act ?? RenderAct();
            _testMethod.Assert = _testMethod.Assert ?? RenderAssert();

            return Template.Render("TestMethod", RenderValues);
        }

        private string RenderArrange() => Template.Render("Arrange", new { Variables });

        private string RenderAct() => Template.Render("Act", new { });

        private string RenderAssert()
        {
            switch (CurrentAssertType)
            {
                case AssertType.Equal:
                    return Renderer.AssertEqual(ExpectedValue, TestedValue);
                case AssertType.Empty:
                    return Renderer.AssertEmpty(ExpectedValue, TestedValue);
                case AssertType.Null:
                    return Renderer.AssertNull(TestedValue);
                case AssertType.Throws:
                    return Renderer.AssertThrows(_testMethod.ExceptionThrown, TestedValue);
                case AssertType.Boolean:
                    return Renderer.AssertBoolean(Convert.ToBoolean(_testMethod.Expected), TestedValue);
                case AssertType.Matches:
                    return Renderer.AssertMatches(ExpectedValue, TestedValue);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private object RenderValues => new { Name = _testMethod.TestMethodName, _testMethod.Skip, _testMethod.Arrange, _testMethod.Act, _testMethod.Assert };

        private void Update()
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