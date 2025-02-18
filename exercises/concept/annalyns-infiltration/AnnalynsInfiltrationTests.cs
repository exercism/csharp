using Exercism.Tests;

public class AnnalynsInfiltrationTests
{
    [Fact]
    [Task(1)]
    public void Cannot_execute_fast_attack_if_knight_is_awake()
    {
        var knightIsAwake = true;
        Assert.False(QuestLogic.CanFastAttack(knightIsAwake));
    }

    [Fact]
    [Task(1)]
    public void Can_execute_fast_attack_if_knight_is_sleeping()
    {
        var knightIsAwake = false;
        Assert.True(QuestLogic.CanFastAttack(knightIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Cannot_spy_if_everyone_is_sleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        Assert.False(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_everyone_but_knight_is_sleeping()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_everyone_but_archer_is_sleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_everyone_but_prisoner_is_sleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_only_knight_is_sleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_only_archer_is_sleeping()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_only_prisoner_is_sleeping()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(2)]
    public void Can_spy_if_everyone_is_awake()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(3)]
    public void Can_signal_prisoner_if_archer_is_sleeping_and_prisoner_is_awake()
    {
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(3)]
    public void Cannot_signal_prisoner_if_archer_is_awake_and_prisoner_is_sleeping()
    {
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        Assert.False(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(3)]
    public void Cannot_signal_prisoner_if_archer_and_prisoner_are_both_sleeping()
    {
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        Assert.False(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(3)]
    public void Cannot_signal_prisoner_if_archer_and_prisoner_are_both_awake()
    {
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        Assert.False(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_everyone_is_awake_and_pet_dog_is_present()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_everyone_is_awake_and_pet_dog_is_absent()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Can_free_prisoner_if_everyone_is_asleep_and_pet_dog_is_present()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_everyone_is_asleep_and_pet_dog_is_absent()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Can_free_prisoner_if_only_prisoner_is_awake_and_pet_dog_is_present()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Can_free_prisoner_if_only_prisoner_is_awake_and_pet_dog_is_absent()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_archer_is_awake_and_pet_dog_is_present()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_archer_is_awake_and_pet_dog_is_absent()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Can_free_prisoner_if_only_knight_is_awake_and_pet_dog_is_present()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_knight_is_awake_and_pet_dog_is_absent()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_knight_is_asleep_and_pet_dog_is_present()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_knight_is_asleep_and_pet_dog_is_absent()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Can_free_prisoner_if_only_archer_is_asleep_and_pet_dog_is_present()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_archer_is_asleep_and_pet_dog_is_absent()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_prisoner_is_asleep_and_pet_dog_is_present()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact]
    [Task(4)]
    public void Cannot_free_prisoner_if_only_prisoner_is_asleep_and_pet_dog_is_absent()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }
}
