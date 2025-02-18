using System;

public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}
