using NUnit.Framework;

[TestFixture]
public class BobTest
{
    private Bob teenager;

    [SetUp]
    public void Init ()
    {
        teenager = new Bob();
    }

    [Test]
    public void StatingSomething ()
    {
        Assert.AreEqual("Whatever.", teenager.Hey("Tom-ay-to, tom-aaaah-to."));
    }

    [Test, Ignore]
    public void Shouting ()
    {
        Assert.AreEqual("Woah, chill out!", teenager.Hey("WATCH OUT!"));
    }

    [Test, Ignore]
    public void AskingAQuestion ()
    {
        Assert.AreEqual("Sure.", teenager.Hey("Does this cryogenic chamber make me look fat?"));
    }

    [Test, Ignore]
    public void AskingANumericQuestion ()
    {
        Assert.AreEqual("Sure.", teenager.Hey("You are, what, like 15?"));
    }

    [Test, Ignore]
    public void TalkingForcefully ()
    {
        Assert.AreEqual("Whatever.", teenager.Hey("Let's go make out behind the gym!"));
    }

    [Test, Ignore]
    public void UsingAcronymsInRegularSearch ()
    {
        Assert.AreEqual("Whatever.", teenager.Hey("It's OK if you don't want to go to the DMV."));
    }

    [Test, Ignore]
    public void ForcefulQuestions ()
    {
        Assert.AreEqual("Woah, chill out!", teenager.Hey("WHAT THE HELL WERE YOU THINKING?"));
    }

    [Test, Ignore]
    public void ShoutingNumbers ()
    {
        Assert.AreEqual("Woah, chill out!", teenager.Hey("1, 2, 3 GO!"));
    }

    [Test, Ignore]
    public void OnlyNumbers ()
    {
        Assert.AreEqual("Whatever.", teenager.Hey("1, 2, 3"));
    }

    [Test, Ignore]
    public void QuestionWithOnlyNumbers ()
    {
        Assert.AreEqual("Sure.", teenager.Hey("4?"));
    }

    [Test, Ignore]
    public void ShoutingWithSpecialCharacters ()
    {
        Assert.AreEqual("Woah, chill out!", teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"));
    }

    [Test, Ignore]
    public void ShoutingWithNoExclamationMark ()
    {
        Assert.AreEqual("Woah, chill out!", teenager.Hey("I HATE YOU"));
    }

    [Test, Ignore]
    public void StatementContainingQuestionMark ()
    {
        Assert.AreEqual("Whatever.", teenager.Hey("Ending with ? means a question."));
    }

    [Test, Ignore]
    public void PrattlingOn ()
    {
        Assert.AreEqual("Sure.", teenager.Hey("Wait! Hang on. Are you going to be OK?"));
    }

    [Test, Ignore]
    public void Silence ()
    {
        Assert.AreEqual("Fine. Be that way!", teenager.Hey(""));
    }

    [Test, Ignore]
    public void ProlongedSilence ()
    {
        Assert.AreEqual("Fine. Be that way!", teenager.Hey("    "));
    }

    [Test, Ignore]
    public void MultipleLineQuestion ()
    {
        Assert.AreEqual("Whatever.", teenager.Hey("Does this cryogenic chamber make me look fat?\nno"));
    }

}