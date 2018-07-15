// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using System.IO;
using Xunit;

public class GrepTest : IDisposable
{
    [Fact]
    public void One_file_one_match_no_flags()
    {
        var pattern = "Agamemnon";
        var flags = "";
        var files = new[] { "iliad.txt" };
        var expected = "Of Atreus, Agamemnon, King of men.";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_one_match_print_line_numbers_flag()
    {
        var pattern = "Forbidden";
        var flags = "-n";
        var files = new[] { "paradise-lost.txt" };
        var expected = "2:Of that Forbidden Tree, whose mortal tast";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_one_match_case_insensitive_flag()
    {
        var pattern = "FORBIDDEN";
        var flags = "-i";
        var files = new[] { "paradise-lost.txt" };
        var expected = "Of that Forbidden Tree, whose mortal tast";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_one_match_print_file_names_flag()
    {
        var pattern = "Forbidden";
        var flags = "-l";
        var files = new[] { "paradise-lost.txt" };
        var expected = "paradise-lost.txt";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_one_match_match_entire_lines_flag()
    {
        var pattern = "With loss of Eden, till one greater Man";
        var flags = "-x";
        var files = new[] { "paradise-lost.txt" };
        var expected = "With loss of Eden, till one greater Man";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_one_match_multiple_flags()
    {
        var pattern = "OF ATREUS, Agamemnon, KIng of MEN.";
        var flags = "-n -i -x";
        var files = new[] { "iliad.txt" };
        var expected = "9:Of Atreus, Agamemnon, King of men.";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_several_matches_no_flags()
    {
        var pattern = "may";
        var flags = "";
        var files = new[] { "midsummer-night.txt" };
        var expected = 
            "Nor how it may concern my modesty,\n" +
            "But I beseech your grace that I may know\n" +
            "The worst that may befall me in this case,";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_several_matches_print_line_numbers_flag()
    {
        var pattern = "may";
        var flags = "-n";
        var files = new[] { "midsummer-night.txt" };
        var expected = 
            "3:Nor how it may concern my modesty,\n" +
            "5:But I beseech your grace that I may know\n" +
            "6:The worst that may befall me in this case,";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_several_matches_match_entire_lines_flag()
    {
        var pattern = "may";
        var flags = "-x";
        var files = new[] { "midsummer-night.txt" };
        var expected = "";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_several_matches_case_insensitive_flag()
    {
        var pattern = "ACHILLES";
        var flags = "-i";
        var files = new[] { "iliad.txt" };
        var expected = 
            "Achilles sing, O Goddess! Peleus' son;\n" +
            "The noble Chief Achilles from the son";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_several_matches_inverted_flag()
    {
        var pattern = "Of";
        var flags = "-v";
        var files = new[] { "paradise-lost.txt" };
        var expected = 
            "Brought Death into the World, and all our woe,\n" +
            "With loss of Eden, till one greater Man\n" +
            "Restore us, and regain the blissful Seat,\n" +
            "Sing Heav'nly Muse, that on the secret top\n" +
            "That Shepherd, who first taught the chosen Seed";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_file_no_matches_various_flags()
    {
        var pattern = "Gandalf";
        var flags = "-n -l -x -i";
        var files = new[] { "iliad.txt" };
        var expected = "";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_one_match_no_flags()
    {
        var pattern = "Agamemnon";
        var flags = "";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = "iliad.txt:Of Atreus, Agamemnon, King of men.";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_several_matches_no_flags()
    {
        var pattern = "may";
        var flags = "";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = 
            "midsummer-night.txt:Nor how it may concern my modesty,\n" +
            "midsummer-night.txt:But I beseech your grace that I may know\n" +
            "midsummer-night.txt:The worst that may befall me in this case,";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_several_matches_print_line_numbers_flag()
    {
        var pattern = "that";
        var flags = "-n";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = 
            "midsummer-night.txt:5:But I beseech your grace that I may know\n" +
            "midsummer-night.txt:6:The worst that may befall me in this case,\n" +
            "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast\n" +
            "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_one_match_print_file_names_flag()
    {
        var pattern = "who";
        var flags = "-l";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = 
            "iliad.txt\n" +
            "paradise-lost.txt";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_several_matches_case_insensitive_flag()
    {
        var pattern = "TO";
        var flags = "-i";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = 
            "iliad.txt:Caused to Achaia's host, sent many a soul\n" +
            "iliad.txt:Illustrious into Ades premature,\n" +
            "iliad.txt:And Heroes gave (so stood the will of Jove)\n" +
            "iliad.txt:To dogs and to all ravening fowls a prey,\n" +
            "midsummer-night.txt:I do entreat your grace to pardon me.\n" +
            "midsummer-night.txt:In such a presence here to plead my thoughts;\n" +
            "midsummer-night.txt:If I refuse to wed Demetrius.\n" +
            "paradise-lost.txt:Brought Death into the World, and all our woe,\n" +
            "paradise-lost.txt:Restore us, and regain the blissful Seat,\n" +
            "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_several_matches_inverted_flag()
    {
        var pattern = "a";
        var flags = "-v";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = 
            "iliad.txt:Achilles sing, O Goddess! Peleus' son;\n" +
            "iliad.txt:The noble Chief Achilles from the son\n" +
            "midsummer-night.txt:If I refuse to wed Demetrius.";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_one_match_match_entire_lines_flag()
    {
        var pattern = "But I beseech your grace that I may know";
        var flags = "-x";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = "midsummer-night.txt:But I beseech your grace that I may know";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_one_match_multiple_flags()
    {
        var pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN";
        var flags = "-n -i -x";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = "paradise-lost.txt:4:With loss of Eden, till one greater Man";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_files_no_matches_various_flags()
    {
        var pattern = "Frodo";
        var flags = "-n -l -x -i";
        var files = new[] { "iliad.txt", "midsummer-night.txt", "paradise-lost.txt" };
        var expected = "";
        Assert.Equal(expected, Grep.Match(pattern, flags, files));
    }

    private const string IliadFileName = "iliad.txt";
    private const string IliadContents =
        "Achilles sing, O Goddess! Peleus' son;\n" +
        "His wrath pernicious, who ten thousand woes\n" +
        "Caused to Achaia's host, sent many a soul\n" +
        "Illustrious into Ades premature,\n" +
        "And Heroes gave (so stood the will of Jove)\n" +
        "To dogs and to all ravening fowls a prey,\n" +
        "When fierce dispute had separated once\n" +
        "The noble Chief Achilles from the son\n" +
        "Of Atreus, Agamemnon, King of men.\n";

    private const string MidsummerNightFileName = "midsummer-night.txt";
    private const string MidsummerNightContents =
        "I do entreat your grace to pardon me.\n" +
        "I know not by what power I am made bold,\n" +
        "Nor how it may concern my modesty,\n" +
        "In such a presence here to plead my thoughts;\n" +
        "But I beseech your grace that I may know\n" +
        "The worst that may befall me in this case,\n" +
        "If I refuse to wed Demetrius.\n";

    private const string ParadiseLostFileName = "paradise-lost.txt";
    private const string ParadiseLostContents =
        "Of Mans First Disobedience, and the Fruit\n" +
        "Of that Forbidden Tree, whose mortal tast\n" +
        "Brought Death into the World, and all our woe,\n" +
        "With loss of Eden, till one greater Man\n" +
        "Restore us, and regain the blissful Seat,\n" +
        "Sing Heav'nly Muse, that on the secret top\n" +
        "Of Oreb, or of Sinai, didst inspire\n" +
        "That Shepherd, who first taught the chosen Seed\n";

    public GrepTest()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        File.WriteAllText(IliadFileName, IliadContents);
        File.WriteAllText(MidsummerNightFileName, MidsummerNightContents);
        File.WriteAllText(ParadiseLostFileName, ParadiseLostContents);
    }

    public void Dispose()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        File.Delete(IliadFileName);
        File.Delete(MidsummerNightFileName);
        File.Delete(ParadiseLostFileName);
    }
}