using System.Collections.Generic;
using Generators.Input;

namespace Generators.Output
{
    public abstract class TestMethodBody
    {
        protected TestMethodBody(CanonicalDataCase canonicalDataCase)
        {
            CanonicalDataCase = canonicalDataCase;
            
            Data = new TestMethodBodyData(this);
            InitializeTemplateParameters();
        }

        public string TemplateName { get; set; } = "TestMethodBody";

        public CanonicalDataCase CanonicalDataCase { get; }
        public TestMethodBodyData Data { get; }

        public virtual bool UseVariablesForInput => CanonicalDataCase.UseVariablesForInput;
        public virtual bool UseVariablesForConstructorParameters => CanonicalDataCase.UseVariablesForConstructorParameters;
        public virtual bool UseVariableForExpected => CanonicalDataCase.UseVariableForExpected;
        public virtual bool UseVariableForTested => CanonicalDataCase.UseVariableForTested;
        
        public string ArrangeTemplateName { get; set; } = "Arrange";
        public object ArrangeTemplateParameters { get; set; }
        
        public string ActTemplateName { get; set; } = "Act";
        public object ActTemplateParameters { get; set; }
        
        public string AssertTemplateName { get; set; } = "AssertEqual";
        public object AssertTemplateParameters { get; set; }

        public IEnumerable<string> Act { get; set; }
        public IEnumerable<string> Arrange { get; set; }
        public IEnumerable<string> Assert { get; set; }
        
        public virtual string Render() => TemplateRenderer.RenderPartial(TemplateName, new { Arrange, Act, Assert });

        private void InitializeTemplateParameters()
        {
            ArrangeTemplateParameters = new { Data.Variables };
            ActTemplateParameters = new { };
            AssertTemplateParameters = new { Data.ExpectedParameter, Data.TestedValue };
        }
    }
}