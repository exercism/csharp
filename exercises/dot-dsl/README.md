# DOT DSL

Write a Domain Specific Language similar to the Graphviz dot language.

A [Domain Specific Language
(DSL)](https://en.wikipedia.org/wiki/Domain-specific_language) is a
small language optimized for a specific domain.

For example the dot language of [Graphviz](http://graphviz.org) allows
you to write a textual description of a graph which is then transformed
into a picture by one of the graphviz tools (such as `dot`). A simple
graph looks like this:

    graph {
        graph [bgcolor="yellow"]
        a [color="red"]
        b [color="blue"]
        a -- b [color="green"]
    }

Putting this in a file `example.dot` and running `dot example.dot -T png
-o example.png` creates an image `example.png` with red and blue circle
connected by a green line on a yellow background.

Create a DSL similar to the dot language.

## Hints
This exercise requires you to implement classes with a custom equality check. For more information, see [this page](https://msdn.microsoft.com/en-us/library/bsc2ak47(v=vs.110).aspx).


## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
