A user-defined exception is any class defined in your code that is derived from `System.Exception`. It is subject to all the rules of class inheritance but in addition the compiler and language runtime treat such classes in a special way allowing their instances to be thrown and caught outside the normal control flow as discussed in the `exceptions` exercise.

User-defined exceptions are often used to carry extra information such as a message and other relevant data to be made available to the catching routines.
