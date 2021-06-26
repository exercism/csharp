using System;
using System.Collections.Generic;
using System.IO;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Grep : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "Match";
            testMethod.Input["flags"] = ConvertFlags(testMethod);
            testMethod.Expected = ConvertExpected(testMethod.Expected);
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
        }

        private static dynamic ConvertFlags(TestMethod testMethod) 
            => string.Join(" ", testMethod.Input["flags"]);

        private static MultiLineString ConvertExpected(dynamic expected) 
            => new(expected as string[] ?? Array.Empty<string>());

        protected override void UpdateTestClass(TestClass testClass)
        {
            testClass.IsDisposable = true;

            AddAdditionalMethods(testClass);
        }

        private static void AddAdditionalMethods(TestClass testClass)
        {
            AddIliadData(testClass);
            AddMidsummerNightData(testClass);
            AddParadiseLostData(testClass);
            AddConstructor(testClass);
            AddDisposeMethod(testClass);
        }

        private static void AddIliadData(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
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

        private static void AddMidsummerNightData(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
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

        private static void AddParadiseLostData(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
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

        private static void AddConstructor(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
public GrepTest()
{
    Directory.SetCurrentDirectory(Path.GetTempPath());
    File.WriteAllText(IliadFileName, IliadContents);
    File.WriteAllText(MidsummerNightFileName, MidsummerNightContents);
    File.WriteAllText(ParadiseLostFileName, ParadiseLostContents);
}");
        }

        private static void AddDisposeMethod(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
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
