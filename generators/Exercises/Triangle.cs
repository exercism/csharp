using System.Collections;
using Generators.Input;
using Generators.Output;
namespace Generators.Exercises
{
    public class Triangle : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var data in canonicalData.Cases)
            {
                if (data.Property == "equilateral")
                    data.Property = "IsEquilateral";
                else if (data.Property == "isosceles")
                    data.Property = "IsIsosceles";
                else if (data.Property == "scalene")
                    data.Property = "IsScalene";

                data.Input["sides"] = SplitArrayToValues(data.Input["sides"]);
                data.SetInputParameters("sides");
                data.UseFullDescriptionPath = true;

            }
        }

        private UnescapedValue SplitArrayToValues(IEnumerable input)
        {
            const string template = "{% for item in {{input}} %}{{item}}{% if forloop.last == false %}, {% endif %}{% endfor %}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }
    }
}