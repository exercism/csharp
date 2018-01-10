C# is a multi-paradigm statically-typed programming language with object-oriented, declarative, functional, generic, lazy integrated querying features and type inference. 

__Statically-typed__ means that identifiers have a type set at compile time--like those in Java, C++ or Haskell--instead of holding data of any type like those in Python, Ruby or JavaScript.

__Object-oriented__ means that C# provides imperative class-based ojects with features such as single inheritance, interfaces and encapsulation.  

__Declarative__ means programming what is to be done, as opposed to how it is done (which is an implementation detail which can distract from the domain or business logic).

__Functional__ means that functions are first-class data types that can be passed as arguments to and returned from other functions.

__Generic__ means that algorithms are written in terms of types to-be-specified-later that are then instantiated when needed for specific types provided as parameters. 

__Lazy__ (a.k.a "non-strict") means that the compiler will put off evaluating a thing until absolutely neccessary. This lets you safely do weird stuff like operating on an infinite list--the language will only create it up to the last value you actually use.

__Integrated Querying__ means the C# language feaure called [LINQ "Language-Integrated Query"](https://msdn.microsoft.com/en-us/library/bb308959.aspx), which enables querying directly within the language, not only its own objects but, also, external data sources through formats such as XML, Json, SQL, NoSQL DBs and event streams.  

__Type inference__ means that the compiler will often figure out the type of an identifier by itself so you don't have to specify it. Scala and F# both do this.

__Syntax__ is similar to that of other C-style languages such as C, C++ and Java.

__.NET__ is the managed environment within which C# runs. This used to be Windows-only but, with the release of [.NET Core](https://www.microsoft.com/net/core) -- as well as [MONO](http://www.mono-project.com/) -- you can also use C# on Mac, Linux or Unix-based systems.

C# also has features to enable programmnig multiple threads, multiple processes, parallelisation and asynchrony easier.It is developed and maintained by Microsoft, who provides the official [documentation](https://docs.microsoft.com/en-us/dotnet/csharp/).
