using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    private static readonly Random Random = new Random();

    public DndCharacter(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Hitpoints = 10 + Modifier(constitution);
    }

    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability() 
        => Enumerable
            .Range(0, 4)
            .Select(_ => RollDie())
            .OrderByDescending(score => score).Take(3).Sum();

    private static int RollDie() => Random.Next(1, 7);

    public static DndCharacter Generate() 
        => new DndCharacter(Ability(), Ability(), Ability(), Ability(), Ability(), Ability());
}
