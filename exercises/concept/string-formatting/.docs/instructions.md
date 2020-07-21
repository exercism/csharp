In this exercise, you are going to help high school sweethearts profess their love on social media.

## 1. Display the couple's name separated by a heart

Please implement the static `HighSchoolSweetheart.DisplaySingleLine()` method to take 2 names and display them separated by a heart centered in a 61 character line.

All names are guaranteed to fit well within the width of the line.

```csharp
HighSchoolSweetheart.DisplaySingleLine("Lance Green", "Pat Riley");
// => "                  Lance Green ♡ Pat Riley                    "
```

## 2. Display the couple's initials in an ascii art heart

Implement the static `HighSchoolSweetheart.DisplayBanner()` method which displays the two sets of initials separated with a plus sign.

```csharp
HighSchoolSweetheart.DisplayBanner("L. G.", "P. R.");
// see the ascii art below
```

```
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     L. G.  +  P. R.     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
```

## 3. German exchange students should be made to feel at home with locale-sensitive declarations.

Implement the static `HighSchoolSweetheart.DisplayGermanExchangeStudents()` method to show date of start of relationship and length of time for our german exchange students.

```csharp
HighSchoolSweetheart.DisplayGermanExchangeStudents("Norbert", "Heidi", new DateTime(2019, 1, 22), 1535.22f);
// => "Norbert and Heidi have been dating since 22.01.2019 - that's 1.535,22 hours"
```
