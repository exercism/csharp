using Generators.Input;
using Generators.Output;
using System.Collections.Generic;
using System.Linq;

namespace Generators.Exercises
{
    public class Etl : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
                // Make sure to convert keys to ints as stated in canonical data
                canonicalDataCase.Properties["input"] = ConvertInput(canonicalDataCase.Properties["input"]);
                canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
            }
        }

        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            // The ValueFormatter doesn't handle Dictionary<int, IList<string>>. Need to format manually.
            Dictionary<int, string[]> inputDictionary = testMethodBody.CanonicalDataCase.Properties["input"];
            var newInput = FormatMultiLineEnumerable(
                inputDictionary.Keys.Select((key, i) => $"[{ValueFormatter.Format(key)}] = {ValueFormatter.Format(inputDictionary[key])}" + (i < inputDictionary.Keys.Count - 1 ? "," : "")), 
                "input", "new Dictionary<int, IList<string>>");
            newInput = AddTrailingSemicolon(newInput);

            var arrangeVariables = testMethodBody.Data.Variables.ToList();
            arrangeVariables.RemoveAt(0);
            arrangeVariables.InsertRange(0, newInput);
            testMethodBody.ArrangeTemplateParameters = new { Variables = arrangeVariables };

            return base.RenderTestMethodBodyArrange(testMethodBody);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => int.Parse($"{kv.Value}"));

        private static dynamic ConvertInput(dynamic input)
            => ((Dictionary<string, object>)input).ToDictionary(kv => int.Parse(kv.Key), kv => (string[])kv.Value);

        private static string[] FormatMultiLineEnumerable(IEnumerable<string> enumerable, string name, string constructor = null)
            => FormatMultiLineVariable(enumerable.Prepend("{").Append("}"), name, constructor);

        private static string[] FormatMultiLineVariable(IEnumerable<string> enumerable, string name, string constructor = null)
            => enumerable.Select(line => line == "{" || line == "}" ? line : line.Indent())
                .Prepend($"var {name} = {constructor}")
                .ToArray();

        private static string[] AddTrailingSemicolon(string[] array)
        {
            array[array.Length - 1] += ";";
            return array;
        }

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string> { typeof(Dictionary<string, int>).Namespace };
    }
}
