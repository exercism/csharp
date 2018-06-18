using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Grep : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "Match";
                canonicalDataCase.Input["flags"] = string.Join(" ", canonicalDataCase.Input["flags"]);
                canonicalDataCase.Expected = ConvertExpected(canonicalDataCase.Expected);
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
            }
        }

        private static dynamic ConvertExpected(dynamic expected)
        {
            var arr = expected as object[];

            if (arr == null || arr.Length == 0)
                return "";

            return new UnescapedValue("\n" + string.Join("\n", arr.Select(((x, i) => $"    \"{x}\\n\"{(i < arr.Length - 1 ? " +" : "")}"))));
        }

        protected override TestClass CreateTestClass()
        {
            var testClass = base.CreateTestClass();
            testClass.TemplateName = "TestClassDisposable";

            return testClass;
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[]
        {
            typeof(IDisposable).Namespace,
            typeof(System.IO.File).Namespace
        };

        protected override string[] RenderAdditionalMethods()
        {
            return new[]
            {
                @"
private const string IliadFileName = ""iliad.txt"";
private const string IliadContents =
    ""Achilles sing, O Goddess! Peleus' son;\n"" +
    ""His wrath pernicious, who ten thousand woes\n"" +
    ""Caused to Achaia's host, sent many a soul\n"" +
    ""Illustrious into Ades premature,\n"" +
    ""And Heroes gave (so stood the will of Jove)\n"" +
    ""To dogs and to all ravening fowls a prey,\n"" +
    ""When fierce dispute had separated once\n"" +
    ""The noble Chief Achilles from the son\n"" +
    ""Of Atreus, Agamemnon, King of men.\n"";",
            @"
private const string MidsummerNightFileName = ""midsummer-night.txt"";
private const string MidsummerNightContents =
    ""I do entreat your grace to pardon me.\n"" +
    ""I know not by what power I am made bold,\n"" +
    ""Nor how it may concern my modesty,\n"" +
    ""In such a presence here to plead my thoughts;\n"" +
    ""But I beseech your grace that I may know\n"" +
    ""The worst that may befall me in this case,\n"" +
    ""If I refuse to wed Demetrius.\n"";",
            @"
private const string ParadiseLostFileName = ""paradise-lost.txt"";
private const string ParadiseLostContents =
    ""Of Mans First Disobedience, and the Fruit\n"" +
    ""Of that Forbidden Tree, whose mortal tast\n"" +
    ""Brought Death into the World, and all our woe,\n"" +
    ""With loss of Eden, till one greater Man\n"" +
    ""Restore us, and regain the blissful Seat,\n"" +
    ""Sing Heav'nly Muse, that on the secret top\n"" +
    ""Of Oreb, or of Sinai, didst inspire\n"" +
    ""That Shepherd, who first taught the chosen Seed\n"";",
            @"
public GrepTest()
{
    Directory.SetCurrentDirectory(Path.GetTempPath());
    File.WriteAllText(IliadFileName, IliadContents);
    File.WriteAllText(MidsummerNightFileName, MidsummerNightContents);
    File.WriteAllText(ParadiseLostFileName, ParadiseLostContents);
}",
            @"
public void Dispose()
{
    Directory.SetCurrentDirectory(Path.GetTempPath());
    File.Delete(IliadFileName);
    File.Delete(MidsummerNightFileName);
    File.Delete(ParadiseLostFileName);
}"
            };
        }
    }
}
