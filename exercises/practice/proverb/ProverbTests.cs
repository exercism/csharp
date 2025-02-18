public class ProverbTests
{
    [Fact]
    public void Zero_pieces()
    {
        string[] subjects = [];
        string[] expected = [
        ];
        Assert.Equal(expected, Proverb.Recite(subjects));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_piece()
    {
        string[] subjects = ["nail"];
        string[] expected = [
            "And all for the want of a nail."
        ];
        Assert.Equal(expected, Proverb.Recite(subjects));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_pieces()
    {
        string[] subjects = ["nail", "shoe"];
        string[] expected = [
            "For want of a nail the shoe was lost.",
            "And all for the want of a nail."
        ];
        Assert.Equal(expected, Proverb.Recite(subjects));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_pieces()
    {
        string[] subjects = ["nail", "shoe", "horse"];
        string[] expected = [
            "For want of a nail the shoe was lost.",
            "For want of a shoe the horse was lost.",
            "And all for the want of a nail."
        ];
        Assert.Equal(expected, Proverb.Recite(subjects));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_proverb()
    {
        string[] subjects = ["nail", "shoe", "horse", "rider", "message", "battle", "kingdom"];
        string[] expected = [
            "For want of a nail the shoe was lost.",
            "For want of a shoe the horse was lost.",
            "For want of a horse the rider was lost.",
            "For want of a rider the message was lost.",
            "For want of a message the battle was lost.",
            "For want of a battle the kingdom was lost.",
            "And all for the want of a nail."
        ];
        Assert.Equal(expected, Proverb.Recite(subjects));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_pieces_modernized()
    {
        string[] subjects = ["pin", "gun", "soldier", "battle"];
        string[] expected = [
            "For want of a pin the gun was lost.",
            "For want of a gun the soldier was lost.",
            "For want of a soldier the battle was lost.",
            "And all for the want of a pin."
        ];
        Assert.Equal(expected, Proverb.Recite(subjects));
    }
}
