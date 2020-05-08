using Xunit;

public class QuestLogicTests
{
    [Fact]
    public void CannotExecuteFastAttackIfKnightIsAwake()
    {
        var knightIsAwake = true;
        Assert.False(QuestLogic.CanFastAttack(knightIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanExecuteFastAttackIfKnightIsSleeping()
    {
        var knightIsAwake = false;
        Assert.True(QuestLogic.CanFastAttack(knightIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotSpyIfEveryoneIsSleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        Assert.False(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfEveryoneButKnightIsSleeping()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfEveryoneButArcherIsSleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfEveryoneButPrisonerIsSleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;


        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfOnlyKnightIsSleeping()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfOnlyArcherIsSleeping()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfOnlyPrisonerIsSleeping()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSpyIfEveryoneIsAwake()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSpy(knightIsAwake, archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanSignalPrisonerIfarcherIsSleepingAndPrisonerIsAwake()
    {
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        Assert.True(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotSignalPrisonerIfarcherIsAwakeAndPrisonerIsSleeping()
    {
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        Assert.False(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotSignalPrisonerIfarcherAndPrisonerAreBothSleeping()
    {
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        Assert.False(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotSignalPrisonerIfarcherAndPrisonerAreBothAwake()
    {
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        Assert.False(QuestLogic.CanSignalPrisoner(archerIsAwake, prisonerIsAwake));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfEveryoneIsAwakeAndPetDogIsPresent()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfEveryoneIsAwakeAndPetDogIsAbsent()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanReleasePrisonerIfEveryoneIsAsleepAndPetDogIsPresent()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfEveryoneIsAsleepAndPetDogIsAbsent()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanReleasePrisonerIfOnlyPrisonerIsAwakeAndPetDogIsPresent()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanReleasePrisonerIfOnlyPrisonerIsAwakeAndPetDogIsAbsent()
    {
        var knightIsAwake = false;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyArcherIsAwakeAndPetDogIsPresent()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyArcherIsAwakeAndPetDogIsAbsent()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanReleasePrisonerIfOnlyKnightIsAwakeAndPetDogIsPresent()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyKnightIsAwakeAndPetDogIsAbsent()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyKnightIsAsleepAndPetDogIsPresent()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyKnightIsAsleepAndPetDogIsAbsent()
    {
        var knightIsAwake = false;
        var archerIsAwake = true;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CanReleasePrisonerIfOnlyArcherIsAsleepAndPetDogIsPresent()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = true;
        Assert.True(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyArcherIsAsleepAndPetDogIsAbsent()
    {
        var knightIsAwake = true;
        var archerIsAwake = false;
        var prisonerIsAwake = true;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyPrisonerIsAsleepAndPetDogIsPresent()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = true;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CannotReleasePrisonerIfOnlyPrisonerIsAsleepAndPetDogIsAbsent()
    {
        var knightIsAwake = true;
        var archerIsAwake = true;
        var prisonerIsAwake = false;
        var petDogIsPresent = false;
        Assert.False(QuestLogic.CanFreePrisoner(knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent));
    }
}
