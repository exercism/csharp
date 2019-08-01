There is a new exercise, [EXERCISE-NAME](https://github.com/exercism/problem-specifications/blob/master/exercises/EXERCISE-NAME/description.md), which data can be found here: https://github.com/exercism/problem-specifications/tree/master/exercises/EXERCISE-NAME

To implement the `EXERCISE-NAME` exercise, first run the `./add-new-exercise EXERCISE-NAME` script that will create and update the files required for the new exercise. After this script has run, it will have done the following:

- Added a new entry for the exercise to the [config.json](https://github.com/exercism/csharp/blob/master/config.json) file.
- Created a default generator in the [generator/Generators/Exercise] directory, which is used to automatically convert the [canonical data](https://github.com/exercism/problem-specifications/blob/master/exercises/EXERCISE-NAME/canonical-data.json) to a test file. For more information on how this works, check the [generators docs](https://github.com/exercism/csharp/blob/master/docs/GENERATORS.md).
- Created the [`exercises/EXERCISE-NAME`] directory, which contains the following exercise-specific files:

  - A project file.
  - A test file.
  - A stub implementation file.
  - An example implementation file.
  - A `README.md` file describing the exercise.
  - An `.editorconfig` file.

Once these files have been created, what's left for you is to:

- Verify the tests in the test file. As the test suite is automatically generated based on the canonical data, any customizations should be done by updating the generator created in the [generator/Generators/Exercises] directory and then regenerating the test suite using `./generate-tests.ps1 EXERCISE-NAME`.
- Modify the stub implementation file to have it compile succesfully together with the test file. This means adding stubs for the functions required in the test suite. For an example, see the [two-fer stub implementation file](https://github.com/exercism/csharp/blob/master/exercises/two-fer/TwoFer.cs))
- Modify the example implementation file to have it pass all the tests. You can verify this by running `./test.ps1 EXERCISE-NAME` from the root directory.
- Update the exercise's entry in the `config.json` file: adding topics, setting the difficulty and indicating if it is a core exercise, or else specifying which exercise unlocks it.

Once all these steps have been completed, the final step is to open a pull request :)
