using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception("An error occured.");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int result;

        if (int.TryParse(input, out result))
        {
            return result;
        }

        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using (disposableObject)
        {
            throw new Exception("An error occured.");
        }
    }
}
