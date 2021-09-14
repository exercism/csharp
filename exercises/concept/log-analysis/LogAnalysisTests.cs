using Xunit;
using Exercism.Tests;
using System;

public class LogAnalysisTests
{
    [Fact]
    public void Word_count_of_words_in_log()
    {
        Assert.Equal(7, "[Error]: {Line 20} - 'Critical error found'".WordCount());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Word_count_of_log_with_space_separated_non_alphabet()
    {
        Assert.Equal(6, "[Error]: {Line 3} - '; expected'".WordCount());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Log_level_of_warning_log()
    {
        Assert.Equal("Warning", "[Warning]: {Line 11} - 'Trim will be deprecated soon'".LogLevel());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Log_level_of_error_log()
    {
        Assert.Equal("Error", "[Error]: {Line 8} - '; expected'".LogLevel());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Log_line_of_log_with_single_digit()
    {
        Assert.Equal("1", "[Warning]: {Line 1} - 'Trim will be deprecated soon'".LogLine());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Log_line_of_log_of_log_with_mulitple_digits()
    {
        Assert.Equal("111", "[Warning]: {Line 111} - 'Trim will be deprecated soon'".LogLine());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Truncate_log_does_not_change_log_with_less_than_10_characters()
    {
        var log = "[Warning]: {Line 9} - 'The library bogo is deprecated.'";
        Assert.Equal("[Warning]: {Line 9} - 'The library bogo is deprecated.'", log.Truncate(10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Truncate_log_trims_log_with_more_than_10_words()
    {
        var log = "[Warning]: {Line 9} - 'The library bogo_sort is deprecated by really_quick_algorithm.'";
        Assert.Equal("Warning - 9", log.Truncate(10));
    }
}
