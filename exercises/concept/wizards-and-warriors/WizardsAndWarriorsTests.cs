using Xunit;
using Exercism.Tests;

public class WizardsAndWarriorsTests
{
    [Fact]
    [Task(1)]
    public void Describe_wizard()
    {
        var wizard = new Wizard();
        Assert.Equal("Character is a Wizard", wizard.ToString());
    }

    [Fact]
    [Task(1)]
    public void Describe_warrior()
    {
        var warrior = new Warrior();
        Assert.Equal("Character is a Warrior", warrior.ToString());
    }

    [Fact]
    [Task(2)]
    public void Warrior_is_not_vulnerable()
    {
        var warrior = new Warrior();
        Assert.False(warrior.Vulnerable());
    }

    [Fact]
    [Task(4)]
    public void Wizard_is_vulnerable()
    {
        var wizard = new Wizard();
        Assert.True(wizard.Vulnerable());
    }

    [Fact]
    [Task(4)]
    public void Wizard_with_prepared_spell_is_not_vulnerable()
    {
        var wizard = new Wizard();
        wizard.PrepareSpell();
        Assert.False(wizard.Vulnerable());
    }

    [Fact]
    [Task(4)]
    public void Wizard_with_no_prepared_spell_is_vulnerable()
    {
        var wizard = new Wizard();
        Assert.True(wizard.Vulnerable());
    }

    [Fact]
    [Task(5)]
    public void Attack_points_for_wizard_with_prepared_spell()
    {
        var wizard = new Wizard();
        var warrior = new Warrior();

        wizard.PrepareSpell();

        Assert.Equal(12, wizard.DamagePoints(warrior));
    }

    [Fact]
    [Task(5)]
    public void Attack_points_for_wizard_with_no_prepared_spell()
    {
        var wizard = new Wizard();
        var otherWizard = new Wizard();

        Assert.Equal(3, wizard.DamagePoints(otherWizard));
    }

    [Fact]
    [Task(6)]
    public void Attack_points_for_warrior_with_vulnerable_target()
    {
        var warrior = new Warrior();
        var wizard = new Wizard();

        Assert.Equal(10, warrior.DamagePoints(wizard));
    }

    [Fact]
    [Task(6)]
    public void Attack_points_for_warrior_with_non_vulnerable_target()
    {
        var warrior = new Warrior();
        var wizard = new Wizard();
        wizard.PrepareSpell();

        Assert.Equal(6, warrior.DamagePoints(wizard));
    }
}
