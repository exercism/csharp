using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Exercises;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Output
{
    public abstract class TestMethod
    {
        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";
        private const string TemplateName = "TestMethod";
        
        private const string ArrangeTemplateName = "Arrange";
        private const string ActTemplateName = "Act";
        
        protected Render Renderer { get; } = new Render();

        protected TestMethod(TestData data) => Data = data;

        public TestData Data { get; }
        
        public object ArrangeTemplateParameters { get; set; }
        public object ActTemplateParameters { get; set; }
        public object AssertTemplateParameters { get; set; }

        public string Act { get; set; }
        public string Arrange { get; set; }
        public string Assert { get; set; }
        
        public string Render()
        {
            ArrangeTemplateParameters = ArrangeTemplateParameters ?? new { Variables };
            ActTemplateParameters = ActTemplateParameters ?? new { };
            AssertTemplateParameters = AssertTemplateParameters ?? new { ExpectedParameter, TestedValue };

            Arrange = Arrange ?? RenderArrange();
            Act = Act ?? RenderAct();
            Assert = Assert ?? RenderAssert();

            return Template.Render(TemplateName, new { Name = Data.TestMethod, Data.Skip, Arrange, Act, Assert });
        }

        public string TestedValue => Data.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        public string ExpectedParameter => Data.UseVariableForExpected ? ExpectedVariableName : Renderer.Object(Data.Expected);
        
        private string InputParameters => string.Join(", ", Data.InputParameters.Select(key => Data.UseVariablesForInput ? key.ToVariableName() : Renderer.Object(Data.Input[key])));
        private string ConstructorParameters => string.Join(", ", Data.ConstructorInputParameters.Select(key => Data.UseVariablesForConstructorParameters ? key.ToVariableName() : Renderer.Object(Data.Input[key])));

        private IDictionary<string, object> Input => Data.InputParameters.ToDictionary(key => key, key => Data.Input[key]);
        private IDictionary<string, object> ConstructorInput => Data.ConstructorInputParameters.ToDictionary(key => key, key => Data.Input[key]);

        private string ExpectedVariableDeclaration => Renderer.Variable(ExpectedVariableName, Data.Expected);
        private IEnumerable<string> InputVariablesDeclaration => Renderer.Variables(Input);
        private IEnumerable<string> ConstructorVariablesDeclaration => Renderer.Variables(ConstructorInput);
        private IEnumerable<string> SutVariableDeclaration => new[] { $"var {SutVariableName} = new {Data.TestedClass}({ConstructorParameters});" };
        private IEnumerable<string> ActualVariableDeclaration => new[] { $"var {TestedVariableName} = {TestedMethodInvocation};" };

        public IEnumerable<string> Variables
        {
            get
            {
                var lines = new List<string>();

                if (Data.UseVariablesForInput)
                    lines.AddRange(InputVariablesDeclaration);

                if (Data.UseVariablesForConstructorParameters)
                    lines.AddRange(ConstructorVariablesDeclaration);

                if (Data.TestedMethodType == TestedMethodType.Instance)
                    lines.AddRange(SutVariableDeclaration);

                if (Data.UseVariableForTested)
                    lines.AddRange(ActualVariableDeclaration);

                if (Data.UseVariableForExpected)
                    lines.Add(ExpectedVariableDeclaration);

                return lines;
            }
        }

        public string TestedMethodInvocation
        {
            get
            {
                switch (Data.TestedMethodType)
                {
                    case TestedMethodType.Static:
                        return $"{Data.TestedClass}.{Data.TestedMethod}({InputParameters})";
                    case TestedMethodType.Instance:
                        return $"{SutVariableName}.{Data.TestedMethod}({InputParameters})";
                    case TestedMethodType.Extension:
                        return $"{InputParameters}.{Data.TestedMethod}()";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private string RenderArrange()
            => Template.Render(ArrangeTemplateName, ArrangeTemplateParameters);

        private string RenderAct()
            => Template.Render(ActTemplateName, ActTemplateParameters);

        protected abstract string RenderAssert();
    }
}