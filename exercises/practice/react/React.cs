public class Reactor
{
    public InputCell CreateInputCell(int value)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}

public abstract class Cell
{
}

public class InputCell : Cell
{
}

public class ComputeCell : Cell
{

}