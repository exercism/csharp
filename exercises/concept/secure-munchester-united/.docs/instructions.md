Our football club (first encountered in (TODO cross-ref-tba)) is soaring in the leagues, and you have been invited to do some more work, this time on the security pass printing system.

The class hierarchy of the backroom staff is as follows

```
TeamSupport (interface)
├ Chairman
├ Manager
└ Staff (abstract)
    ├ Physio
    ├ OffensiveCoach
    ├ GoalKeepingCoach
    └ Security
        ├ SecurityJunior
        ├ SecurityIntern
        └ PoliceLiaison
```

A complete implementation of the hierarchy is provided as part of the source code for the exercise.

All data passed to the security pass maker has been validated and is guaranteed to be non-null.

## 1. Get display name for a member of the support team as long as they are staff members

Please implement the `SecurityPassMaker.GetDisplayName()` method. It should return the value of the `Title` field instances of all classes derived from `Staff` and, otherwise, "Too Important for a Security Pass".

```csharp
var spm = new SecurityPassMaker();
spm.GetDisplayName(new Manager());
// => "Too Important for a Security Pass"
spm.GetDisplayName(new Physio());
// => "The Physio"
```

## 2. Customize the display name for the security team

Please modify the `SecurityPassMaker.GetDisplayName()` method. It should behave as in Task 1 except that if the staff member is a member of the security team (either of type `Security` or one of its derivatives) then the text " Priority Personnel" should be displayed after the title.

```csharp
var spm = new SecurityPassMaker();
spm.GetDisplayName(new Physio());
// => "The Physio"
var spm2 = new SecurityPassMaker();
spm2.GetDisplayName(new Security());
// => "Security Team Member Priority Personnel"
spm2.GetDisplayName(new SecurityJunior());
// => "Security Junior Priority Personnel"
```

## 3. Only designate principal security team members as priority personnel

Please modify the `SecurityPassMaker.GetDisplayName()` method. It should behave as in Task 2 except that the text " Priority Personnel" should not be displayed for instances of type `SecurityJunior`, `SecurityIntern` and `PoliceLiaison`.

```csharp
var spm2 = new SecurityPassMaker();
spm2.GetDisplayName(new Security());
// => "Security Team Member Priority Personnel"
spm2.GetDisplayName(new SecurityJunior());
// => "Security Junior"
```
