public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);

    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}
