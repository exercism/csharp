You've been asked to do some more work on the network authentication system.

In addition to the admin identity being hard-coded in the system during development the powers that be also want senior developers to be given the same treatment.

## 1. Store the system admin's details hard-coded in the system and make it available to callers.

The admin's details are as follows:

| Email        | Eye Color | Philtrum Width | Name     | Address 1 | Address 2 |
| ------------ | --------- | -------------- | -------- | --------- | --------- |
| admin@ex.ism | greeen    | 0.9            | Chanakya | Mombai    | India     |

Implement the `Authenticator.Admin` property to return the system admin's identity details. The name and each part of the address should be in a separate element of the `NameAndAddress` list.

```csharp
var authenticator = new Authenticator();
authenticator.Admin;
// => {"admin@ex.ism", {"green", 0.9m}, ["Chanakya", "Mombai", "India"]}
```

## 2 Store the developers' details hard-coded in the system and make them available in the form of a dictionary

The developers' details are as follows:

| Email         | Eye Color | Philtrum Width | Name     | Address 1 | Address 2 |
| ------------- | --------- | -------------- | -------- | --------- | --------- |
| bert@ex.ism   | blue      | 0.8            | Bertrand | Paris     | France    |
| anders@ex.ism | brown     | 0.85           | Anders   | Redmond   | USA       |

Implement the `Authenticator.Developers()` method to return the developers' identity details. The dictionary key is the developer's name.

```csharp
var authenticator = new Authenticator();
authenticator.Developers;
// => {"bert" = {"bert@ex.ism", {"blue", 0.8m}, ["Bertrand", "Paris", "France"]},
// ["anders" = {"bert@ex.ism", {"brown", 0.85m}, ["Anders", "Redmond", "USA"]},

```
