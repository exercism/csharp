using Generators.Output;

namespace Generators.Exercises
{
    public class Proverb : GeneratorExercise
    {
        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if  (testMethodBody.CanonicalDataCase.Properties["input"]["strings"] as string[] == null)
            {
                return TemplateRenderer.RenderInline("Assert.Empty(Proverb.Recite(new string[] { }));", new { });
            }
            return base.RenderTestMethodBodyAssert(testMethodBody);
        }
    }
}