using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output;

internal class TestMethodOutput
{
    private const string SutVariableName = "sut";
    private const string TestedVariableName = "actual";
    private const string ExpectedVariableName = "expected";
        
    private static readonly Render Renderer = new();
    private readonly TestMethod _testMethod;

    public TestMethodOutput(TestMethod testMethod) => _testMethod = testMethod;

    public IEnumerable<string> Variables
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
        
    public IEnumerable<string> InputVariables => Renderer.Variables(_testMethod.InputParameters.ToDictionary(key => key, key => _testMethod.Input[key]));
    public string InputValues => string.Join(", ", _testMethod.InputParameters.Select(key => _testMethod.UseVariablesForInput ? key.ToVariableName() : Renderer.Object(_testMethod.Input[key])));
        
    public IEnumerable<string> ConstructorVariables => Renderer.Variables(_testMethod.ConstructorInputParameters.ToDictionary(key => key, key => _testMethod.Input[key]));
    public string ConstructorValues => string.Join(", ", _testMethod.ConstructorInputParameters.Select(key => _testMethod.UseVariablesForConstructorParameters ? key.ToVariableName() : Renderer.Object(_testMethod.Input[key])));
        
    public string SutVariableDeclaration => Renderer.Variable(SutVariableName, SutParameter);
    public string SutParameter => _testMethod.UseVariableForSut ? $"new {_testMethod.TestedClass}({ConstructorValues})" : SutVariableName;
        
    public string TestedVariable => Renderer.Variable(TestedVariableName, TestedMethodInvocation);
    public string TestedValue
    {
        get
        {
                var value = _testMethod.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
                return _testMethod.ForceEvaluation ? $"{value}.ToArray()" : value;
            }
    }

    public string ExpectedVariable => Renderer.Variable(ExpectedVariableName, Renderer.ObjectMultiLine(_testMethod.Expected));
    public string ExpectedValue => _testMethod.UseVariableForExpected ? ExpectedVariableName : Renderer.Object(_testMethod.Expected);
        
    public string TestedMethodInvocation =>
        _testMethod.TestedMethodType switch
        {
            TestedMethodType.StaticMethod => $"{_testMethod.TestedClass}.{_testMethod.TestedMethod}({InputValues})",
            TestedMethodType.ExtensionMethod => $"{InputValues}.{_testMethod.TestedMethod}()",
            TestedMethodType.InstanceMethod => $"{SutVariableName}.{_testMethod.TestedMethod}({InputValues})",
            TestedMethodType.Property => $"{SutVariableName}.{_testMethod.TestedMethod}",
            TestedMethodType.Constructor => $"new {_testMethod.TestedClass}({ConstructorValues})",
            _ => throw new ArgumentOutOfRangeException()
        };

    public string Render()
    {
            Update();

            _testMethod.Arrange ??= RenderArrange();
            _testMethod.Act ??= RenderAct();
            _testMethod.Assert ??= RenderAssert();

            return Template.Render("TestMethod", RenderValues);
        }

    public string RenderArrange() => Template.Render("Arrange", new { Variables });

    public string RenderAct() => Template.Render("Act", new { });

    public string RenderAssert() =>
        CurrentAssertType switch
        {
            AssertType.Equal => Renderer.AssertEqual(ExpectedValue, TestedValue),
            AssertType.Empty => Renderer.AssertEmpty(ExpectedValue, TestedValue),
            AssertType.Null => Renderer.AssertNull(TestedValue),
            AssertType.Throws => Renderer.AssertThrows(_testMethod.ExceptionThrown!, TestedValue),
            AssertType.Boolean => Renderer.AssertBoolean(Convert.ToBoolean(_testMethod.Expected), TestedValue),
            AssertType.Matches => Renderer.AssertMatches(ExpectedValue, TestedValue),
            _ => throw new ArgumentOutOfRangeException()
        };

    private object RenderValues => new
    {
        Name = _testMethod.TestMethodName, _testMethod.Skip, 
        Body = string.Join(Environment.NewLine, [_testMethod.Arrange, _testMethod.Act, _testMethod.Assert])
    };

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

                return _testMethod.Expected switch
                {
                    null => AssertType.Null,
                    bool _ => AssertType.Boolean,
                    Regex _ => AssertType.Matches,
                    _ => UseEmptyAssertion ? AssertType.Empty : AssertType.Equal
                };
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