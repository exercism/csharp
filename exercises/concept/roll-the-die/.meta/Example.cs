using System;

public class Player
{
    private static Random random = new Random();
    private const int DIE_HIGH = 18;

    public int RollDie()
    {
        return random.Next(1, DIE_HIGH + 1);
    }

    public double GenerateSpellStrength()
    {
        return random.NextDouble() * 100;
    }
}
