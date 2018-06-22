using System.Collections;
using Generators.Output;

namespace Generators.Exercises
{
    public class Connect : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForConstructorParameters = true;
            data.SetConstructorInputParameters("board");
            data.TestedMethod = "Result";
            data.Input["board"] = ToMultiLineString(data.Input["board"]);

            switch (data.Expected)
            {
                case "X":
                    data.Expected = new UnescapedValue("ConnectWinner.Black");
                    break;
                case "O":
                    data.Expected = new UnescapedValue("ConnectWinner.White");
                    break;
                case "":
                    data.Expected = new UnescapedValue("ConnectWinner.None");
                    break;
            }
        }

        private static UnescapedValue ToMultiLineString(IEnumerable input)
        {
            const string template =
@"new [] 
{ 
    {% if input.size == 0 %}string.Empty{% else %}{% for item in {{input}} %}{% if forloop.length == 1 %}""{{item}}""{% break %}{% endif %}""{{item}}""{% if forloop.last == false %},{% else %}{{string.Empty}}{% endif %}
    {% endfor %}{% endif %} 
}";

            return new UnescapedValue(TemplateRenderer.RenderInline(template, new { input }));
        }
    }
}
