using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        throw new NotImplementedException($"Please implement the (static) GetEmptyDictionary() method");
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        throw new NotImplementedException($"Please implement the (static) GetExistingDictionary() method");
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        throw new NotImplementedException($"Please implement the (static) AddCountryToEmptyDictionary() method");
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        throw new NotImplementedException($"Please implement the (static) AddCountryToExistingDictionary() method");
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        throw new NotImplementedException($"Please implement the (static) GetCountryNameFromDictionary() method");
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        throw new NotImplementedException($"Please implement the (static) CheckCodeExists() method");
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        throw new NotImplementedException($"Please implement the (static) UpdateDictionary() method");
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        throw new NotImplementedException($"Please implement the (static) RemoveCountryFromDictionary() method");
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        throw new NotImplementedException($"Please implement the (static) FindLongestCountryName() method");
    }
}