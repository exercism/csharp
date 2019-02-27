There is a new exercise, [EXERCISE-NAME](https://github.com/exercism/problem-specifications/blob/master/exercises/EXERCISE-NAME/description.md), which data can be found here: https://github.com/exercism/problem-specifications/tree/master/exercises/EXERCISE-NAME

To implement the `EXERCISE-NAME` exercise, the following needs to be done:

* Create a directory for the new exercise in the `exercises` directory (note: this has to exactly match `EXERCISE-NAME`).
* Add a new entry to the [config.json](https://github.com/exercism/csharp/blob/master/config.json) file.
* Create a generator to automatically convert the [canonical data](https://github.com/exercism/problem-specifications/blob/master/exercises/EXERCISE-NAME/canonical-data.json) to a test file. For more information on how to do this, check the [generators docs](https://github.com/exercism/csharp/blob/master/docs/GENERATORS.md).
* Create a project file for the project (you can probably best copy and modify one of the existing projects).
* Create a stub implementation file that contains the code necessary to compile (which are the methods called by the test file), but lacks an implementation. (see [this example](https://github.com/exercism/csharp/blob/master/exercises/two-fer/TwoFer.cs)).
* Create an implementation file that passes all the tests. You can verify this by running `./build.sh --exercise=EXERCISE-NAME` or `.\build.ps1 --exercise=EXERCISE-NAME` from the root directory.