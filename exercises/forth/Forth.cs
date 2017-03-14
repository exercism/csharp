using System;

public enum ForthError
{
    DivisionByZero,
    StackUnderflow,
    InvalidWord,
    UnknownWord
}

public class ForthException : Exception
{
    public ForthException(ForthError error)
    {
        Error = error;
    }

    public ForthError Error { get; }
}

public static class Forth
{
    public static string Eval(string input)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}