using System;
using Xunit;
using Exercism.Tests;

public class CastingTests
{
    [Fact]
    public void DisplaySecurityPass_manager()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Too Important for a Security Pass", spm.GetDisplayName(new Manager()));
    }

    [Fact]
    public void DisplaySecurityPass_pysio()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("The Physio", spm.GetDisplayName(new Physio()));
    }

    [Fact]
    public void DisplaySecurityPass_pysio_with_alert()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("The Physio", spm.GetDisplayName(new Physio()));
    }

    [Fact]
    public void DisplaySecurityPass_security()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Security Team Member Priority Personnel", spm.GetDisplayName(new Security()));
    }

    [Fact]
    public void DisplaySecurityPass_security_junior()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Security Junior", spm.GetDisplayName(new SecurityJunior()));
    }

    [Fact]
    public void DisplaySecurityPass_security_police_liaison()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Police Liaison Officer", spm.GetDisplayName(new PoliceLiaison()));
    }

    [Fact]
    public void DisplaySecurityPass_security_intern()
    {
        var spm = new SecurityPassMaker();
        Assert.Equal("Security Intern", spm.GetDisplayName(new SecurityIntern()));
    }
}
