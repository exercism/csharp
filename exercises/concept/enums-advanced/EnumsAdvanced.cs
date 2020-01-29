using System;

// TODO: define AccountType enum

// TODO: define Permission enum

public static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        throw new NotImplementedException("Please implement the Permissions.Default method");
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        throw new NotImplementedException("Please implement the Permissions.Grant method");
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        throw new NotImplementedException("Please implement the Permissions.Revoke method");
    }

    public static bool Check(Permission current, Permission check)
    {
        throw new NotImplementedException("Please implement the Permissions.Check method");
    }
}