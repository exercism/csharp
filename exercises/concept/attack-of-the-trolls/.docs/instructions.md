In this exercise you'll be checking permissions of user accounts on an internet forum. The forum supports three different permissions:

- Read
- Write
- Delete

There are three types of accounts, each with different default permissions:

- Guests: can read posts.
- Users: can read and write posts.
- Moderators: can read, write and delete posts.

Sometimes individual permissions are modified, for example giving a guest account the permission to also write posts.

You have four tasks.

## 1. Get default permissions for an account type

First, define an `AccountType` enum to represent the three account types. Next, define a `Permission` enum to represent the three permission types and two extra ones: one for having no permissions at all, and for having all permissions.

Then implement the (_static_) `Permissions.Default()` method to return the default permissions for a specific account type:

```csharp
Permissions.Default(AccountType.Guest)
// => Permission.Read
```

## 2. Grant a permission

Implement the (_static_) `Permissions.Grant()` method that grants (adds) a permission:

```csharp
Permissions.Grant(current: Permission.None, grant: Permission.Read)
// => Permission.Read
```

## 3. Revoke a permission

Implement the (_static_) `Permissions.Revoke()` method that revokes (removes) a permission:

```csharp
Permissions.Revoke(current: Permission.Read, grant: Permission.Read)
// => Permission.None
```

## 4. Check for a permission

Implement the (_static_) `Permissions.Check()` method that takes the current account's permissions and checks if the account is authorized for a given permission:

```csharp
Permissions.Check(current: Permission.Write, check: Permission.Read)
// => false
```
