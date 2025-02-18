public class BinTree
{
    public BinTree(int value, BinTree? left, BinTree? right)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public int Value { get; }
    public BinTree? Left { get; }
    public BinTree? Right { get; }
}

public class Zipper
{   
    public int Value()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Zipper SetValue(int newValue)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Zipper SetLeft(BinTree? binTree)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Zipper SetRight(BinTree? binTree) 
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Zipper? Left()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Zipper? Right()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Zipper? Up()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public BinTree ToTree()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public static Zipper FromTree(BinTree tree)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}