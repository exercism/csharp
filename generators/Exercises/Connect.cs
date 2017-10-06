using System.Collections.Generic;
using System.Text.RegularExpressions;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Connect : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForConstructorParameters = true;
                canonicalDataCase.SetConstructorInputParameters("board");

                //remove whitespace
                var trimBoard = new List<string>();
                foreach (var row in canonicalDataCase.Properties["board"])
                {
                    trimBoard.Add(Regex.Replace(row, @"\s+", ""));
                }

                canonicalDataCase.Properties["board"] = trimBoard.ToArray();
                canonicalDataCase.Property = "result";

                //convert to enum
                switch (canonicalDataCase.Properties["expected"])
                {
                    case "X":
                        canonicalDataCase.Properties["expected"] = new UnescapedValue("ConnectWinner.Black");
                        break;
                    case "O":
                        canonicalDataCase.Properties["expected"] = new UnescapedValue("ConnectWinner.White");
                        break;
                    case "":
                        canonicalDataCase.Properties["expected"] = new UnescapedValue("ConnectWinner.None");
                        break;
                }
            }
        }
    }
}
