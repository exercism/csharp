using Xunit;
using Exercism.Tests;

public class InternationalCallingConnoisseurTests
{
    [Fact]
    [Task(1)]
    public void Empty_dictionary_is_empty()
    {
        var emptyDict = DialingCodes.GetEmptyDictionary();
        Assert.Empty(emptyDict);
    }

    [Fact]
    [Task(2)]
    public void Existing_dictionary_count_is_3()
    {
        var prePopulated = DialingCodes.GetExistingDictionary();
        Assert.Equal(3, prePopulated.Count);
    }

    [Fact]
    [Task(2)]
    public void Existing_dictionary_1_is_United_States_of_America()
    {
        var prePopulated = DialingCodes.GetExistingDictionary();
        Assert.Equal("United States of America", prePopulated[1]);
    }

    [Fact]
    [Task(2)]
    public void Existing_dictionary_55_is_Brazil()
    {
        var prePopulated = DialingCodes.GetExistingDictionary();
        Assert.Equal("Brazil", prePopulated[55]);
    }

    [Fact]
    [Task(2)]
    public void Existing_dictionary_91_is_India()
    {
        var prePopulated = DialingCodes.GetExistingDictionary();
        Assert.Equal("India", prePopulated[91]);
    }

    [Fact]
    [Task(3)]
    public void Add_country_to_empty_dictionary_single()
    {
        var countryCodes = DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
        Assert.Single(countryCodes);
    }

    [Fact]
    [Task(3)]
    public void Add_country_to_empty_dictionary_44_is_United_Kingdom()
    {
        var countryCodes = DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
        Assert.Equal("United Kingdom", countryCodes[44]);
    }

    [Fact]
    [Task(4)]
    public void Add_country_to_existing_dictionary_count_is_1()
    {
        var countryCodes = DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 44, "United Kingdom");
        Assert.Equal(4, countryCodes.Count);
    }

    [Fact]
    [Task(4)]
    public void Add_country_to_existing_dictionary_1_is_United_States_of_America()
    {
        var countryCodes = DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 44, "United Kingdom");
        Assert.Equal("United States of America", countryCodes[1]);
    }

    [Fact]
    [Task(4)]
    public void Add_country_to_existing_dictionary_44_is_United_Kingdom()
    {
        var countryCodes = DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 44, "United Kingdom");
        Assert.Equal("United Kingdom", countryCodes[44]);
    }

    [Fact]
    [Task(4)]
    public void Add_country_to_existing_dictionary_55_is_Brazil()
    {
        var countryCodes = DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 44, "United Kingdom");
        Assert.Equal("Brazil", countryCodes[55]);
    }

    [Fact]
    [Task(4)]
    public void Add_country_to_existing_dictionary_91_is_India()
    {
        var countryCodes = DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 44, "United Kingdom");
        Assert.Equal("India", countryCodes[91]);
    }

    [Fact]
    [Task(5)]
    public void Get_country_name_from_dictionary()
    {
        var countryName = DialingCodes.GetCountryNameFromDictionary(
            DialingCodes.GetExistingDictionary(), 55);
        Assert.Equal("Brazil", countryName);
    }

    [Fact]
    [Task(5)]
    public void Get_country_name_for_non_existent_country()
    {
        var countryName = DialingCodes.GetCountryNameFromDictionary(
            DialingCodes.GetExistingDictionary(), 999);
        Assert.Equal(string.Empty, countryName);
    }

    [Fact]
    [Task(6)]
    public void Check_country_exists()
    {
        var exists = DialingCodes.CheckCodeExists(
            DialingCodes.GetExistingDictionary(), 55);
        Assert.True(exists);
    }

    [Fact]
    [Task(6)]
    public void Check_country_exists_for_non_existent_country()
    {
        var exists = DialingCodes.CheckCodeExists(
            DialingCodes.GetExistingDictionary(), 999);
        Assert.False(exists);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_count_is_3()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 1, "les États-Unis");
        Assert.Equal(3, countryCodes.Count);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_1_is_les_Etats_Unis()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 1, "les États-Unis");
        Assert.Equal("les États-Unis", countryCodes[1]);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_55_is_Brazil()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 1, "les États-Unis");
        Assert.Equal("Brazil", countryCodes[55]);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_91_is_India()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 1, "les États-Unis");
        Assert.Equal("India", countryCodes[91]);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_for_non_existent_country_count_is_3()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 999, "Newlands");
        Assert.Equal(3, countryCodes.Count);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_for_non_existent_country_1_is_United_States_of_America()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 999, "Newlands");
        Assert.Equal("United States of America", countryCodes[1]);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_for_non_existent_country_55_is_Brazil()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 999, "Newlands");
        Assert.Equal("Brazil", countryCodes[55]);
    }

    [Fact]
    [Task(7)]
    public void Update_country_name_in_dictionary_for_non_existent_country_91_is_India()
    {
        var countryCodes = DialingCodes.UpdateDictionary(
            DialingCodes.GetExistingDictionary(), 999, "Newlands");
        Assert.Equal("India", countryCodes[91]);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_count_is_2()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 91);
        Assert.Equal(2, countryCodes.Count);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_1_is_United_States_of_America()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 91);
        Assert.Equal("United States of America", countryCodes[1]);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_55_is_Brazil()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 91);
        Assert.Equal("Brazil", countryCodes[55]);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_for_non_existent_country_count_is_3()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 999);
        Assert.Equal(3, countryCodes.Count);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_for_non_existent_country_1_is_United_States_of_America()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 999);
        Assert.Equal("United States of America", countryCodes[1]);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_for_non_existent_country_55_is_Brazil()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 999);
        Assert.Equal("Brazil", countryCodes[55]);
    }

    [Fact]
    [Task(8)]
    public void Remove_country_from_dictionary_for_non_existent_country_91_is_India()
    {
        var countryCodes = DialingCodes.RemoveCountryFromDictionary(
            DialingCodes.GetExistingDictionary(), 999);
        Assert.Equal("India", countryCodes[91]);
    }

    [Fact]
    [Task(9)]
    public void Longest_country_name()
    {
        var countryCodes = DialingCodes.AddCountryToExistingDictionary(
            DialingCodes.GetExistingDictionary(), 263, "Zimbabwe");
        var longestCountryName = DialingCodes.FindLongestCountryName(countryCodes);
        Assert.Equal("United States of America", longestCountryName);
    }

    [Fact]
    [Task(9)]
    public void Longest_country_name_for_empty_dictionary()
    {
        var longestCountryName = DialingCodes.FindLongestCountryName(
            DialingCodes.GetEmptyDictionary());
        Assert.Equal(string.Empty, longestCountryName);
    }
}
