In this exercise you will implement a partial set of utility routines to help a developer
clean up identifier names.

In the 4 tasks you will gradually build up the routine `Clean` A valid identifier comprises
zero or more letters and underscores.

In all cases the input string is guaranteed to be non-null. Note that the `Clean` method should treat an empty string as valid.

### 1. Replace any spaces encountered with underscores

Implement the (_static_) `Identifier.Clean()` method to replace any spaces with underscores. This also applies to leading and trailing spaces.

```csharp
Identifier.Clean("my   Id");
// => "my___Id"
```

### 2. Replace control characters with the upper case string "CTRL"

Modify the (_static_) `Identifier.Clean()` method to replace control characters with the upper case string `"CTRL"`.

```csharp
Identifier.Clean("my\0Id");
// => "myCTRLId",
```

### 3. Convert kebab-case to camelCase

Modify the (_static_) `Identifier.Clean()` method to convert kebab-case to camelCase.

```csharp
Identifier.Clean("à-ḃç");
// => "àḂç"
```

### 4. Omit Greek lower case letters

Modify the (_static_) `Identifier.Clean()` method to omit any Greek letters in the range 'α' to 'ω'.

```csharp
Identifier.Clean("MyΟβιεγτFinder");
// => "MyΟFinder"
```
