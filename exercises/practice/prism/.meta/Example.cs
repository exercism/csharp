public static class Prism
{
    public readonly record struct LaserInfo(double X, double Y, double Angle);

    public readonly record struct PrismInfo(int Id, double X, double Y, double Angle);

    public static int[] FindSequence(LaserInfo laser, PrismInfo[] prisms)
    {
        var x = laser.X;
        var y = laser.Y;
        var angle = laser.Angle;
        List<int> sequence = new();

        while (true)
        {
            var rad = double.DegreesToRadians(angle);
            var dirX = double.Cos(rad);
            var dirY = double.Sin(rad);

            PrismInfo? nearest = null;
            var nearestDist = double.PositiveInfinity;

            foreach (var prism in prisms)
            {
                var dx = prism.X - x;
                var dy = prism.Y - y;

                var dist = dx * dirX + dy * dirY;
                if (dist <= 1e-6)
                    continue;

                var crossSq = double.Pow(dx - dist * dirX, 2) + double.Pow(dy - dist * dirY, 2);
                if (crossSq >= 1e-6 * double.Max(1, dist * dist))
                    continue;

                if (dist < nearestDist)
                {
                    nearestDist = dist;
                    nearest = prism;
                }
            }

            if (nearest is not { } hit)
                break;

            sequence.Add(hit.Id);
            x = hit.X;
            y = hit.Y;
            angle = (angle + hit.Angle) % 360;
        }

        return sequence.ToArray();
    }
}
