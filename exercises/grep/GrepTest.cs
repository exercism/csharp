using System;
using System.IO;
using Xunit;

public class GrepTest : IDisposable
{
    private const string IliadFileName = "iliad.txt";
    private const string IliadContents =
        @"Achilles sing, O Goddess! Peleus' son;
His wrath pernicious, who ten thousand woes
Caused to Achaia's host, sent many a soul
Illustrious into Ades premature,
And Heroes gave (so stood the will of Jove)
To dogs and to all ravening fowls a prey,
When fierce dispute had separated once
The noble Chief Achilles from the son
Of Atreus, Agamemnon, King of men.
";

    private const string MidsummerNightFileName = "midsummer-night.txt";
    private const string MidsummerNightContents =
        @"I do entreat your grace to pardon me.
I know not by what power I am made bold,
Nor how it may concern my modesty,
In such a presence here to plead my thoughts;
But I beseech your grace that I may know
The worst that may befall me in this case,
If I refuse to wed Demetrius.
";

    private const string ParadiseLostFileName = "paradise-lost.txt";
    private const string ParadiseLostContents =
        @"Of Mans First Disobedience, and the Fruit
Of that Forbidden Tree, whose mortal tast
Brought Death into the World, and all our woe,
With loss of Eden, till one greater Man
Restore us, and regain the blissful Seat,
Sing Heav'nly Muse, that on the secret top
Of Oreb, or of Sinai, didst inspire
That Shepherd, who first taught the chosen Seed
";
    
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

    [Fact]
    public void One_file_one_match_no_flags()
    {
        const string pattern = "Agamemnon";
        const string flags = "";
        var files = new[] { IliadFileName };

        const string expected =
            "Of Atreus, Agamemnon, King of men.\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_one_match_print_line_numbers_flag()
    {
        const string pattern = "Forbidden";
        const string flags = "-n";
        var files = new[] { ParadiseLostFileName };

        const string expected =
            "2:Of that Forbidden Tree, whose mortal tast\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_one_match_case_insensitive_flag()
    {
        const string pattern = "Forbidden";
        const string flags = "-i";
        var files = new[] { ParadiseLostFileName };

        const string expected =
            "Of that Forbidden Tree, whose mortal tast\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_one_match_print_file_names_flag()
    {
        const string pattern = "Forbidden";
        const string flags = "-l";
        var files = new[] { ParadiseLostFileName };

        var expected =
            $"{ParadiseLostFileName}\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_one_match_match_entire_lines_flag()
    {
        const string pattern = "With loss of Eden, till one greater Man";
        const string flags = "-x";
        var files = new[] { ParadiseLostFileName };

        const string expected =
            "With loss of Eden, till one greater Man\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_one_match_multiple_flags()
    {
        const string pattern = "OF ATREUS, Agamemnon, KIng of MEN.";
        var files = new[] { IliadFileName };
        const string flags = "-n -i -x";
        const string expected =
            "9:Of Atreus, Agamemnon, King of men.\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_several_matches_no_flags()
    {
        const string pattern = "may";
        const string flags = "";
        var files = new[] { MidsummerNightFileName };

        const string expected =
            "Nor how it may concern my modesty,\n" +
            "But I beseech your grace that I may know\n" +
            "The worst that may befall me in this case,\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_several_matches_print_line_numbers_flag()
    {
        const string pattern = "may";
        const string flags = "-n";
        var files = new[] { MidsummerNightFileName };

        const string expected =
            "3:Nor how it may concern my modesty,\n" +
            "5:But I beseech your grace that I may know\n" +
            "6:The worst that may befall me in this case,\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_several_matches_match_entire_lines_flag()
    {
        const string pattern = "may";
        const string flags = "-x";
        var files = new[] { MidsummerNightFileName };

        const string expected = "";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_several_matches_case_insensitive_flag()
    {
        const string pattern = "ACHILLES";
        const string flags = "-i";
        var files = new[] { IliadFileName };

        const string expected =
            "Achilles sing, O Goddess! Peleus' son;\n" +
            "The noble Chief Achilles from the son\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void One_file_several_matches_inverted_flag()
    {
        const string pattern = "Of";
        const string flags = "-v";
        var files = new[] { ParadiseLostFileName };

        const string expected =
            "Brought Death into the World, and all our woe,\n" +
            "With loss of Eden, till one greater Man\n" +
            "Restore us, and regain the blissful Seat,\n" +
            "Sing Heav'nly Muse, that on the secret top\n" +
            "That Shepherd, who first taught the chosen Seed\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Theory]
    [InlineData("")]
    [InlineData("-n")]
    [InlineData("-l")]
    [InlineData("-x")]
    [InlineData("-i")]
    [InlineData("-n -l -x -i")]
    public void One_file_no_matches_various_flags(string flags)
    {
        const string pattern = "Gandalf";
        var files = new[] { IliadFileName };
        const string expected = "";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_one_match_no_flags()
    {
        const string pattern = "Agamemnon";
        const string flags = "";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{IliadFileName}:Of Atreus, Agamemnon, King of men.\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_several_matches_no_flags()
    {
        const string pattern = "may";
        const string flags = "";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{MidsummerNightFileName}:Nor how it may concern my modesty,\n" +
            $"{MidsummerNightFileName}:But I beseech your grace that I may know\n" +
            $"{MidsummerNightFileName}:The worst that may befall me in this case,\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_several_matches_print_line_numbers_flag()
    {
        const string pattern = "that";
        const string flags = "-n";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{MidsummerNightFileName}:5:But I beseech your grace that I may know\n" +
            $"{MidsummerNightFileName}:6:The worst that may befall me in this case,\n" +
            $"{ParadiseLostFileName}:2:Of that Forbidden Tree, whose mortal tast\n" +
            $"{ParadiseLostFileName}:6:Sing Heav'nly Muse, that on the secret top\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_several_matches_print_file_names_flag()
    {
        const string pattern = "who";
        const string flags = "-l";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{IliadFileName}\n" +
            $"{ParadiseLostFileName}\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_several_matches_case_insensitive_flag()
    {
        const string pattern = "TO";
        const string flags = "-i";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{IliadFileName}:Caused to Achaia's host, sent many a soul\n" +
            $"{IliadFileName}:Illustrious into Ades premature,\n" +
            $"{IliadFileName}:And Heroes gave (so stood the will of Jove)\n" +
            $"{IliadFileName}:To dogs and to all ravening fowls a prey,\n" +
            $"{MidsummerNightFileName}:I do entreat your grace to pardon me.\n" +
            $"{MidsummerNightFileName}:In such a presence here to plead my thoughts;\n" +
            $"{MidsummerNightFileName}:If I refuse to wed Demetrius.\n" +
            $"{ParadiseLostFileName}:Brought Death into the World, and all our woe,\n" +
            $"{ParadiseLostFileName}:Restore us, and regain the blissful Seat,\n" +
            $"{ParadiseLostFileName}:Sing Heav'nly Muse, that on the secret top\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_several_matches_inverted_flag()
    {
        const string pattern = "a";
        const string flags = "-v";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{IliadFileName}:Achilles sing, O Goddess! Peleus' son;\n" +
            $"{IliadFileName}:The noble Chief Achilles from the son\n" +
            $"{MidsummerNightFileName}:If I refuse to wed Demetrius.\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_one_match_match_entire_lines_flag()
    {
        const string pattern = "But I beseech your grace that I may know";
        const string flags = "-x";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        var expected =
            $"{MidsummerNightFileName}:But I beseech your grace that I may know\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Fact]
    public void Multiple_files_one_match_multiple_flags()
    {
        const string pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };
        const string flags = "-n -i -x";
        var expected =
            $"{ParadiseLostFileName}:4:With loss of Eden, till one greater Man\n";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }

    [Theory]
    [InlineData("")]
    [InlineData("-n")]
    [InlineData("-l")]
    [InlineData("-x")]
    [InlineData("-i")]
    [InlineData("-n -l -x -i")]
    public void Multiple_files_no_matches_various_flags(string flags)
    {
        const string pattern = "Frodo";
        var files = new[] { IliadFileName, MidsummerNightFileName, ParadiseLostFileName };

        const string expected = "";

        Assert.Equal(expected, Grep.Find(pattern, flags, files));
    }
}