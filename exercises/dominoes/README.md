# Dominoes

Compute whether there exists a way to order a given set of dominoes in such a way that they form a
correct domino chain (the dots on one half of a stone match the dots on the
neighbouring half of an adjacent stone) and that dots on the halfs of the stones
which don't have a neighbour (the first and last stone) match each other.

For example given the stones `21`, `23` and `13` you should declare that there exists a possible chain (for example, `12`, `23` and `31` is a possible chain).

For stones 12, 41 and 23 the resulting chain is not valid: 41 12 23's first and last numbers are not the same. 4 != 3

Some test cases may use duplicate stones in a chain solution, assume that multiple Domino sets are being used.

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
