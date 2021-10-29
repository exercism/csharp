using Xunit;
using Exercism.Tests;

public class WizardsAndWarriors2Tests
{
    [Fact]
    [Task(1)]
    public void Describe_warrior_character()
    {
        var character = new Character();
        character.Class = "Warrior";
        character.Level = 16;
        character.HitPoints = 89;

        Assert.Equal("You're a level 16 Warrior with 89 hit points.", GameMaster.Describe(character));
    }

    [Fact]
    [Task(1)]
    public void Describe_wizard_character()
    {
        var character = new Character();
        character.Class = "Wizard";
        character.Level = 7;
        character.HitPoints = 33;

        Assert.Equal("You're a level 7 Wizard with 33 hit points.", GameMaster.Describe(character));
    }

    [Fact]
    [Task(2)]
    public void Describe_small_town_destination()
    {
        var destination = new Destination();
        destination.Name = "Tol Honeth";
        destination.Inhabitants = 41;

        Assert.Equal("You've arrived at Tol Honeth, which has 41 inhabitants.", GameMaster.Describe(destination));
    }

    [Fact]
    [Task(2)]
    public void Describe_large_town_destination()
    {
        var destination = new Destination();
        destination.Name = "Ashaba";
        destination.Inhabitants = 1500;

        Assert.Equal("You've arrived at Ashaba, which has 1500 inhabitants.", GameMaster.Describe(destination));
    }

    [Fact]
    [Task(3)]
    public void Describe_walking_travel_method()
    {
        Assert.Equal("You're traveling to your destination by walking.", GameMaster.Describe(TravelMethod.Walking));
    }

    [Fact]
    [Task(3)]
    public void Describe_horse_travel_method()
    {
        Assert.Equal("You're traveling to your destination on horseback.", GameMaster.Describe(TravelMethod.Horseback));
    }

    [Fact]
    [Task(4)]
    public void Describe_character_traveling_to_destination_with_explicit_travel_method()
    {
        var character = new Character();
        character.Class = "Wizard";
        character.Level = 20;
        character.HitPoints = 120;

        var destination = new Destination();
        destination.Name = "Camaar";
        destination.Inhabitants = 999;

        Assert.Equal("You're a level 20 Wizard with 120 hit points. You're traveling to your destination on horseback. You've arrived at Camaar, which has 999 inhabitants.", GameMaster.Describe(character, destination, TravelMethod.Horseback));
    }

    [Fact]
    [Task(5)]
    public void Describe_character_traveling_to_destination_without_explicit_travel_method()
    {
        var character = new Character();
        character.Class = "Warrior";
        character.Level = 1;
        character.HitPoints = 30;

        var destination = new Destination();
        destination.Name = "Vo Mimbre";
        destination.Inhabitants = 332;

        Assert.Equal("You're a level 1 Warrior with 30 hit points. You're traveling to your destination by walking. You've arrived at Vo Mimbre, which has 332 inhabitants.", GameMaster.Describe(character, destination));
    }
}
