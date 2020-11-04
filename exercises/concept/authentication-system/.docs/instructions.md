The authentication system that you last saw in (TODO cross-ref-tba) is in need of some attention. You have been tasked with cleaning up the code. Such a cleanup project will not only make life easy for future maintainers but will expose and fix some security vulnerabilities.

## 1. Set appropriate fields and properties to const

This is a refactoring task. Add the `const` modifier to any members of `Authenticator` or `Identity` that you think appropriate.

## 2. Set appropriate fields to readonly

This is a refactoring task. Add the `readonly` modifier to any fields of the `Authenticator` class or the `Identity` struct that you think appropriate.

## 3. Ensure that the class cannot be changed once it has been created

Remove the `set` accessor or make it `private` for any appropriate property on the `Authenticator` class or `Identity` struct.

## 4. Ensure that the admin cannot be tampered with

At present the admin identity field is returned by a call to `Admin`. This is not ideal as the caller can modify the field. Find a way to prevent the caller modifying the details of admin on the `Authenticator` object.

## 5. Ensure that the developers cannot be tampered with

At present the dictionary containing the hard coded privileged developer identities is returned by a call to `GetDevelopers()`. This is not ideal as the caller can modify the dictionary. Find a way to prevent the caller modifying the details of admin on the `Authenticator` object.
