using System;
using System.Linq;

public static class RotationalCipher
{
    private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
    private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Rotate(string text, int shiftKey) 
        => new string(text.Select(letter => Rotate(letter, shiftKey)).ToArray());

    private static char Rotate(char letter, int shiftKey) 
    {
        if (!char.IsLetter(letter))
            return letter;
        
        return Rotate(letter, shiftKey, char.IsLower(letter) ? LowerCaseLetters : UpperCaseLetters);
    }

    private static char Rotate(char letter, int shiftKey, string key)
        => key[(key.IndexOf(letter) + shiftKey) % key.Length];
}