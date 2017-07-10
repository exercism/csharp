# Word Search

In word search puzzles you get a square of letters and have to find specific
words in them.

For example:

```
jefblpepre
camdcimgtc
oivokprjsm
pbwasqroua
rixilelhrs
wolcqlirpc
screeaumgr
alxhpburyi
jalaycalmp
clojurermt
```

There are several programming languages hidden in the above square.

Words can be hidden in all kinds of directions: left-to-right, right-to-left,
vertical and diagonal.

Given a puzzle and a list of words return the location of the first and last
letter of each word.

## HINTS

One of the uses of Tuples is returning multiple values from a function.   In this exercise, write
a function that returns a Tuple (the x- and y- part of a coordinate).

For more information on Tuples, see [this link](https://msdn.microsoft.com/en-us/library/system.tuple(v=vs.110).aspx).

### Submitting Exercises

Note that, when trying to submit an exercise, make sure you're exercise file you're submitting is in the `exercism/csharp/<exerciseName>` directory.

For example, if you're submitting `bob.cs` for the Bob exercise, the submit command would be something like `exercism submit <path_to_exercism_dir>/csharp/bob/bob.cs`.

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
