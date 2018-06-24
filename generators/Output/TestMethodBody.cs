using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Helpers;
using Generators.Output.Templates;

namespace Generators.Output
{
    public abstract class TestMethodBody
    {
        private const string SutVariableName = "sut";
        private const string TestedVariableName = "actual";
        private const string ExpectedVariableName = "expected";

        protected TestMethodBody(TestData data) => Data = data;

        public string TemplateName { get; } = "TestMethodBody";

        public TestData Data { get; }

        public string ArrangeTemplateName { get; set; } = "Arrange";
        public object ArrangeTemplateParameters { get; set; }

        public string ActTemplateName { get; set; } = "Act";
        public object ActTemplateParameters { get; set; }

        public string AssertTemplateName { get; set; } = "AssertEqual";
        public object AssertTemplateParameters { get; set; }

        public IEnumerable<string> Act { get; set; }
        public IEnumerable<string> Arrange { get; set; }
        public IEnumerable<string> Assert { get; set; }

        public virtual string Render()
        {
            ArrangeTemplateParameters = ArrangeTemplateParameters ?? new { Variables };
            ActTemplateParameters = ActTemplateParameters ?? new { };
            AssertTemplateParameters = AssertTemplateParameters ?? new { ExpectedParameter, TestedValue };
            
            Arrange = Arrange ?? RenderTestMethodBodyArrange();
            Act = Act ?? RenderTestMethodBodyAct();
            Assert = Assert ?? RenderTestMethodBodyAssert();

            return TemplateRenderer.RenderPartial(TemplateName, new { Arrange, Act, Assert });
        }

        protected string TestedValue => Data.UseVariableForTested ? TestedVariableName : TestedMethodInvocation;
        protected string InputParameters => Data.UseVariablesForInput ? string.Join(", ", Data.InputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(Input);
        protected string ExpectedParameter => Data.UseVariableForExpected ? ExpectedVariableName : ValueFormatter.Format(Data.Expected);
        protected string ConstructorParameters => Data.UseVariablesForConstructorParameters ? string.Join(", ", Data.ConstructorInputParameters.Select(key => key.ToVariableName())) : ValueFormatter.Format(ConstructorInput);

        private IDictionary<string, object> Input => Data.InputParameters.ToDictionary(key => key, key => Data.Input[key]);
        private IDictionary<string, object> ConstructorInput => Data.ConstructorInputParameters.ToDictionary(key => key, key => Data.Input[key]);

        private IEnumerable<string> InputVariablesDeclaration => ValueFormatter.FormatVariables(Input);
        private IEnumerable<string> ExpectedVariableDeclaration => ValueFormatter.FormatVariable(Data.Expected, ExpectedVariableName);
        private IEnumerable<string> ConstructorVariablesDeclaration => ValueFormatter.FormatVariables(ConstructorInput);
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
                    lines.AddRange(ExpectedVariableDeclaration);

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

        private IEnumerable<string> RenderTestMethodBodyArrange()
            => new[] { TemplateRenderer.RenderPartial(ArrangeTemplateName, ArrangeTemplateParameters) };

        private IEnumerable<string> RenderTestMethodBodyAct()
            => new[] { TemplateRenderer.RenderPartial(ActTemplateName, ActTemplateParameters) };

        private IEnumerable<string> RenderTestMethodBodyAssert()
            => new[] { TemplateRenderer.RenderPartial(AssertTemplateName, AssertTemplateParameters) };
    }
}