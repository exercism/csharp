using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Grep : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "Match";
            data.Input["flags"] = string.Join(" ", data.Input["flags"]);
            data.Expected = ConvertExpected(data.Expected);
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }

        private static dynamic ConvertExpected(dynamic expected)
        {
            if (expected is object[] arr && arr.Length != 0)
                return new UnescapedValue(
                    Environment.NewLine +
                    string.Join(
                        Environment.NewLine,
                            arr.Select((x, i) => $"    \"{x}\\n\"{(i < arr.Length - 1 ? " +" : "")}")));

            return "";
        }

        protected override void UpdateTestClass(TestClass @class)
        {
            @class.IsDisposable = true;

            AddAdditionalMethods(@class);
        }

        private static void AddAdditionalMethods(TestClass @class)
        {
            AddIliadData(@class);
            AddMidsummerNightData(@class);
            AddParadiseLostData(@class);
            AddConstructor(@class);
            AddDisposeMethod(@class);
        }

        private static void AddIliadData(TestClass @class)
        {
            @class.Methods.Add(@"
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
    ""Of Atreus, Agamemnon, King of men.\n"";");
        }

        private static void AddMidsummerNightData(TestClass @class)
        {
            @class.Methods.Add(@"
private const string MidsummerNightFileName = ""midsummer-night.txt"";
private const string MidsummerNightContents =
    ""I do entreat your grace to pardon me.\n"" +
    ""I know not by what power I am made bold,\n"" +
    ""Nor how it may concern my modesty,\n"" +
    ""In such a presence here to plead my thoughts;\n"" +
    ""But I beseech your grace that I may know\n"" +
    ""The worst that may befall me in this case,\n"" +
    ""If I refuse to wed Demetrius.\n"";");
        }

        private static void AddParadiseLostData(TestClass @class)
        {
            @class.Methods.Add(@"
private const string ParadiseLostFileName = ""paradise-lost.txt"";
private const string ParadiseLostContents =
    ""Of Mans First Disobedience, and the Fruit\n"" +
    ""Of that Forbidden Tree, whose mortal tast\n"" +
    ""Brought Death into the World, and all our woe,\n"" +
    ""With loss of Eden, till one greater Man\n"" +
    ""Restore us, and regain the blissful Seat,\n"" +
    ""Sing Heav'nly Muse, that on the secret top\n"" +
    ""Of Oreb, or of Sinai, didst inspire\n"" +
    ""That Shepherd, who first taught the chosen Seed\n"";");
        }

        private static void AddConstructor(TestClass @class)
        {
            @class.Methods.Add(@"
public GrepTest()
{
    Directory.SetCurrentDirectory(Path.GetTempPath());
    File.WriteAllText(IliadFileName, IliadContents);
    File.WriteAllText(MidsummerNightFileName, MidsummerNightContents);
    File.WriteAllText(ParadiseLostFileName, ParadiseLostContents);
}");
        }

        private static void AddDisposeMethod(TestClass @class)
        {
            @class.Methods.Add(@"
public void Dispose()
{
    Directory.SetCurrentDirectory(Path.GetTempPath());
    File.Delete(IliadFileName);
    File.Delete(MidsummerNightFileName);
    File.Delete(ParadiseLostFileName);
}");
        }
        
        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IDisposable).Namespace);
            namespaces.Add(typeof(File).Namespace);
        }
    }
}
