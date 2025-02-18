public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        if (preOrder.Length != inOrder.Length) throw new ArgumentException("Traversals must have the same length");
        if (!preOrder.Order().SequenceEqual(inOrder.Order())) throw new ArgumentException("Traversals must be consistent");
        if (preOrder.Distinct().Count() != preOrder.Length) throw new ArgumentException("Traversals must not have repeated items");

        int preOrderIndex = 0;
        return TreeFromTraversals(preOrder, inOrder, ref preOrderIndex, 0, preOrder.Length - 1);
    }

    private static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder, ref int preOrderIndex, int left, int right)
    {
        if (left > right) return null;
        
        var preOrderValue = preOrder[preOrderIndex++];
        var inOrderIndex = Array.IndexOf(inOrder, preOrderValue);
        
        return new Tree(
            preOrderValue,
            TreeFromTraversals(preOrder, inOrder, ref preOrderIndex, left, inOrderIndex - 1),
            TreeFromTraversals(preOrder, inOrder, ref preOrderIndex, inOrderIndex + 1, right));
    }
}
