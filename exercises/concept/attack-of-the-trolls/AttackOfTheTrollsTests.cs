using Xunit;
using Exercism.Tests;

public class AttackOfTheTrollsTests
{
    [Fact]
    public void Permissions_read_write_can_be_combined_as_flags()
    {
        Assert.Equal("Read, Write", (Permission.Read | Permission.Write).ToString());
    }

    [Fact]
    public void Combining_none_delete_permissions_is_same_as_delete_permission()
    {
        Assert.Equal("Delete", (Permission.Delete | Permission.None).ToString());
    }

    [Fact]
    public void Combining_read_write_delete_permissions_is_same_as_all_permission()
    {
        Assert.Equal("All", (Permission.Read | Permission.Write | Permission.Delete).ToString());
    }

    [Fact]
    [Task(1)]
    public void Default_for_guest()
    {
        Assert.Equal(Permission.Read, Permissions.Default(AccountType.Guest));
    }

    [Fact]
    [Task(1)]
    public void Default_for_user()
    {
        Assert.Equal(Permission.Read | Permission.Write, Permissions.Default(AccountType.User));
    }

    [Fact]
    [Task(1)]
    public void Default_for_moderator()
    {
        Assert.Equal(Permission.Read | Permission.Write | Permission.Delete, Permissions.Default(AccountType.Moderator));
    }

    [Fact]
    [Task(1)]
    public void Default_for_unknown()
    {
        Assert.Equal(Permission.None, Permissions.Default((AccountType)123));
    }

    [Fact]
    [Task(2)]
    public void Grant_read_to_none()
    {
        Assert.Equal(Permission.Read, Permissions.Grant(Permission.None, Permission.Read));
    }

    [Fact]
    [Task(2)]
    public void Grant_read_to_read()
    {
        Assert.Equal(Permission.Read, Permissions.Grant(Permission.Read, Permission.Read));
    }

    [Fact]
    [Task(2)]
    public void Grant_all_to_none()
    {
        Assert.Equal(Permission.All, Permissions.Grant(Permission.None, Permission.All));
    }

    [Fact]
    [Task(2)]
    public void Grant_delete_to_read_and_write()
    {
        Assert.Equal(Permission.All, Permissions.Grant(Permission.Read | Permission.Write, Permission.Delete));
    }

    [Fact]
    [Task(2)]
    public void Grant_read_and_write_to_none()
    {
        Assert.Equal(Permission.Read | Permission.Write, Permissions.Grant(Permission.None, Permission.Read | Permission.Write));
    }

    [Fact]
    [Task(3)]
    public void Revoke_none_from_read()
    {
        Assert.Equal(Permission.Read, Permissions.Revoke(Permission.Read, Permission.None));
    }

    [Fact]
    [Task(3)]
    public void Revoke_write_from_write()
    {
        Assert.Equal(Permission.None, Permissions.Revoke(Permission.Write, Permission.Write));
    }

    [Fact]
    [Task(3)]
    public void Revoke_delete_from_all()
    {
        Assert.Equal(Permission.Read | Permission.Write, Permissions.Revoke(Permission.All, Permission.Delete));
    }

    [Fact]
    [Task(3)]
    public void Revoke_read_and_write_from_write_and_delete()
    {
        Assert.Equal(Permission.Delete, Permissions.Revoke(Permission.Write | Permission.Delete, Permission.Read | Permission.Write));
    }

    [Fact]
    [Task(3)]
    public void Revoke_all_from_read_and_write()
    {
        Assert.Equal(Permission.None, Permissions.Revoke(Permission.Read | Permission.Write, Permission.All));
    }

    [Fact]
    [Task(4)]
    public void Check_none_for_read()
    {
        Assert.False(Permissions.Check(Permission.None, Permission.Read));
    }

    [Fact]
    [Task(4)]
    public void Check_write_for_write()
    {
        Assert.True(Permissions.Check(Permission.Write, Permission.Write));
    }

    [Fact]
    [Task(4)]
    public void Check_all_for_write()
    {
        Assert.True(Permissions.Check(Permission.All, Permission.Write));
    }

    [Fact]
    [Task(4)]
    public void Check_read_and_write_for_read()
    {
        Assert.True(Permissions.Check(Permission.Read | Permission.Write, Permission.Read));
    }

    [Fact]
    [Task(4)]
    public void Check_all_for_read_and_write()
    {
        Assert.True(Permissions.Check(Permission.All, Permission.Read | Permission.Write));
    }

    [Fact]
    [Task(4)]
    public void Check_read_and_write_for_read_and_write()
    {
        Assert.True(Permissions.Check(Permission.Read | Permission.Write, Permission.Read | Permission.Write));
    }

    [Fact]
    [Task(4)]
    public void Check_read_and_write_for_read_and_delete()
    {
        Assert.False(Permissions.Check(Permission.Read | Permission.Write, Permission.Read | Permission.Delete));
    }

    [Fact]
    [Task(4)]
    public void Check_read_and_write_and_delete_for_all()
    {
        Assert.True(Permissions.Check(Permission.Read | Permission.Write | Permission.Delete, Permission.All));
    }
}
