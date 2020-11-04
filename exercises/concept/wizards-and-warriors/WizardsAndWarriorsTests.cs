using Xunit;

public class RolePlayingGameTests
{
    [Fact]
    public void Describe_wizard()
    {
        var wizard = new Wizard();
        Assert.Equal("Character is a Wizard", wizard.ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Describe_warrior()
    {
        var warrior = new Warrior();
        Assert.Equal("Character is a Warrior", warrior.ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Warrior_is_not_vulnerable()
    {
        var warrior = new Warrior();
        Assert.False(warrior.Vulnerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wizard_is_not_vulnerable()
    {
        var wizard = new Wizard();
        Assert.False(wizard.Vulnerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wizard_with_prepared_spell_is_not_vulnerable()
    {
        var wizard = new Wizard();
        wizard.PrepareSpell();
        Assert.False(wizard.Vulnerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wizard_with_no_prepared_spell_is_vulnerable()
    {
        var wizard = new Wizard();
        Assert.True(wizard.Vulnerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Attack_points_for_wizard_with_prepared_spell()
    {
        var wizard = new Wizard();
        var warrior = new Warrior();

        wizard.PrepareSpell();

        Assert.Equal(12, wizard.DamagePoints(warrior));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Attack_points_for_wizard_with_no_prepared_spell()
    {
        var wizard = new Wizard();
        var otherWizard = new Wizard();

        Assert.Equal(3, wizard.DamagePoints(otherWizard));
    }
}
