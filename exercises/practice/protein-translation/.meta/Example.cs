using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var results = new List<string>();

        for (int i = 0; i < strand.Length / 3; i++)
        {
            var protein = ConvertToProtein(strand.Substring(3 * i, 3));

            if (protein == "STOP")
            {
                break;
            }

            results.Add(protein);
        }

        return results.ToArray();
    }

    private static string ConvertToProtein(string input)
    {
        switch (input)
        {
            case "AUG":
                return "Methionine";
            case "UUU":
            case "UUC":
                return "Phenylalanine";
            case "UUA":
            case "UUG":
                return "Leucine";
            case "UCU":
            case "UCC":
            case "UCA":
            case "UCG":
                return "Serine";
            case "UAU":
            case "UAC":
                return "Tyrosine";
            case "UGU":
            case "UGC":
                return "Cysteine";
            case "UGG":
                return "Tryptophan";
            case "UAA":
            case "UAG":
            case "UGA":
                return "STOP";
            default:
                throw new Exception("Invalid sequence");
        }
    }
}