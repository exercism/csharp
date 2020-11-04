using System;

enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission
{
    None = 0b_0000_0000,
    Read = 0b_0000_0001,
    Write = 0b_0000_0010,
    Delete = 0b_0000_0100,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest:
                return Permission.Read;
            case AccountType.User:
                return Permission.Read | Permission.Write;
            case AccountType.Moderator:
                return Permission.Read | Permission.Write | Permission.Delete;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}
