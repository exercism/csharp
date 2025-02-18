using Exercism.Tests;

public class SecureMunchesterUnitedTests
{
    [Fact]
    [Task(1)]
    public void DisplaySecurityPass_manager()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Too Important for a Security Pass", spm.GetDisplayName(new Manager()));
    }

    [Fact]
    [Task(1)]
    public void DisplaySecurityPass_physio()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("The Physio", spm.GetDisplayName(new Physio()));
    }

    [Fact]
    [Task(2)]
    public void DisplaySecurityPass_security()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Security Team Member Priority Personnel", spm.GetDisplayName(new Security()));
    }

    [Fact]
    [Task(3)]
    public void DisplaySecurityPass_security_junior()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Security Junior", spm.GetDisplayName(new SecurityJunior()));
    }

    [Fact]
    [Task(3)]
    public void DisplaySecurityPass_security_police_liaison()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Police Liaison Officer", spm.GetDisplayName(new PoliceLiaison()));
    }

    [Fact]
    [Task(3)]
    public void DisplaySecurityPass_security_intern()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Security Intern", spm.GetDisplayName(new SecurityIntern()));
    }
}
