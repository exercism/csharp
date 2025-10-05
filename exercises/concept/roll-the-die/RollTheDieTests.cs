using Exercism.Tests;
using System.Collections.Generic;

public class RollTheDieTests
{
    [Fact]
    [Task(1)]
    public void RollDie()
    {
        var rollCount = 1000;
        var rolls = new HashSet<int>(rollCount);
        var player = new Player();
        for (var i = 0; i < rollCount; i++)
        {
            var roll = player.RollDie();
            rolls.Add(roll);
            Assert.InRange(player.RollDie(), 1, 18);
        }
        Assert.Equal(18, rolls.Count);
    }

    [Fact]
    [Task(2)]
    public void GenerateSpellStrength()
    {
        var rollCount = 100;
        var minUniqueValues = rollCount - 5; // Allow up to 5 duplicates
        var rolls = new HashSet<double>(rollCount);
        var player = new Player();
        for (var i = 0; i < rollCount; i++)
        {
            var strength = player.GenerateSpellStrength();
            rolls.Add(strength);
            Assert.InRange(strength, 0.0, 100.0);
        }
        
        Assert.InRange(rolls.Count, minUniqueValues, rollCount);
    }
}
