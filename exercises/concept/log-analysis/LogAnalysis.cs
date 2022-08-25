using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string delimiter)
    {
        string[] arr = str.Split(delimiter);
        return arr[1];
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string delimit1, string delimit2)
    {
        int length1 = delimit1.Length;
        int startPoint = str.IndexOf(delimit1) + length1; // inclusive
        int endPoint = str.IndexOf(delimit2); // exclusive
        int stringLength = endPoint - startPoint;
   
        return str.Substring(startPoint, stringLength);  
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        str = str.Replace("[INFO]: ", "").Replace("[WARNING]: ", "").Replace("[ERROR]: ", "");
        str = str.Trim();
        
        return str;        
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        if (str.Contains("ERROR"))
            return "ERROR";
        else if (str.Contains("WARNING"))
            return "WARNING";
        else
            return "INFO";
    }
}
