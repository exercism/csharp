using Xunit;

public class PermissionsTest
{
    [Fact]
    public void DefaultForGuest() =>
        Assert.Equal(Permission.Read, Permissions.Default(AccountType.Guest));

    [Fact]
    public void DefaultForUser() =>
        Assert.Equal(Permission.Read | Permission.Write, Permissions.Default(AccountType.User));

    [Fact]
    public void DefaultForModerator() =>
        Assert.Equal(Permission.Read | Permission.Write | Permission.Delete, Permissions.Default(AccountType.Moderator));

    [Fact]
    public void DefaultForUnknown() =>
        Assert.Equal(Permission.None, Permissions.Default((AccountType)123));

    [Fact]
    public void GrantReadToNone() =>
        Assert.Equal(Permission.Read, Permissions.Grant(Permission.None, Permission.Read));

    [Fact]
    public void GrantReadToRead() =>
        Assert.Equal(Permission.Read, Permissions.Grant(Permission.Read, Permission.Read));

    [Fact]
    public void GrantAllToNone() =>
        Assert.Equal(Permission.All, Permissions.Grant(Permission.None, Permission.All));

    [Fact]
    public void GrantDeleteToReadAndWrite() =>
        Assert.Equal(Permission.All, Permissions.Grant(Permission.Read | Permission.Write, Permission.Delete));

    [Fact]
    public void GrantReadAndWriteToNone() =>
        Assert.Equal(Permission.Read | Permission.Write, Permissions.Grant(Permission.None, Permission.Read | Permission.Write));

    [Fact]
    public void RevokeNoneFromRead() =>
        Assert.Equal(Permission.Read, Permissions.Revoke(Permission.Read, Permission.None));

    [Fact]
    public void RevokeWriteFromWrite() =>
        Assert.Equal(Permission.None, Permissions.Revoke(Permission.Write, Permission.Write));

    [Fact]
    public void RevokeDeleteFromAll() =>
        Assert.Equal(Permission.Read | Permission.Write, Permissions.Revoke(Permission.All, Permission.Delete));

    [Fact]
    public void RevokeReadAndWriteFromWriteAndDelete() =>
        Assert.Equal(Permission.Delete, Permissions.Revoke(Permission.Write | Permission.Delete, Permission.Read | Permission.Write));

    [Fact]
    public void RevokeAllFromReadAndWrite() =>
        Assert.Equal(Permission.None, Permissions.Revoke(Permission.Read | Permission.Write, Permission.All));

    [Fact]
    public void CheckNoneForRead() =>
        Assert.False(Permissions.Check(Permission.None, Permission.Read));

    [Fact]
    public void CheckWriteForWrite() =>
        Assert.True(Permissions.Check(Permission.Write, Permission.Write));

    [Fact]
    public void CheckAllForWrite() =>
        Assert.True(Permissions.Check(Permission.All, Permission.Write));

    [Fact]
    public void CheckReadAndWriteForRead() =>
        Assert.True(Permissions.Check(Permission.Read | Permission.Write, Permission.Read));

    [Fact]
    public void CheckAllForReadAndWrite() =>
        Assert.True(Permissions.Check(Permission.Read | Permission.Write, Permission.Read | Permission.Write));

    [Fact]
    public void CheckReadAndWriteForReadAndWrite() =>
        Assert.True(Permissions.Check(Permission.Read | Permission.Write, Permission.Read | Permission.Write));

    [Fact]
    public void CheckReadAndWriteForReadAndDelete() =>
        Assert.False(Permissions.Check(Permission.Read | Permission.Write, Permission.Read | Permission.Delete));

    [Fact]
    public void CheckReadAndWriteAndDeleteForAll() =>
        Assert.True(Permissions.Check(Permission.Read | Permission.Write | Permission.Delete, Permission.All));
}