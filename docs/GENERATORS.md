# Test generators

The C# track uses a [test generator](https://exercism.org/docs/building/tooling/test-generators) to auto-generate practice exercise tests.
It uses the fact that most exercises defined in the [problem-specifications repo](https://github.com/exercism/problem-specifications/) also have a `canonical-data.json` file, which contains standardized test inputs and outputs that can be used to implement the exercise.

## Steps

To generate a practice exercise's tests, the test generator:

1. Reads the exercise's test cases from its `canonical-data.json` file
2. Uses `tests.toml` file to omit and excluded test cases
3. Renders the test cases using the exercise's generator template
4. Format the rendered template using Roslyn
5. Writes the formatted template to the exercise's test file

### Step 1: read `canonical-data.json` file

The test generator parses the test cases from the exercise's `canonical-data.json` using the [System.Text.Json namespace](https://learn.microsoft.com/en-us/dotnet/api/system.text.json).

Since some canonical data uses nesting, the parsed test case includes an additional `path` field that contains the `description` properties of any parent elements, as well as the test case's own `description` property.

### Step 2: omit excluded tests from `tests.toml` file

Each exercise has a `tests.toml` file, in which individual tests can be excluded/disabled.
The test generator will remove any test cases that are marked as excluded (`include = false`).

### Step 3: render the test cases

The (potentially transformed) test cases are then passed to the `.meta/Generator.tpl` file, which defines how the tests should be rendered based on those test cases.

### Step 4: format the rendered template using Roslyn

The rendered template is then formatted using [Roslyn](https://github.com/dotnet/roslyn).
This has the following benefits:

- Exercises are formatted consistently
- You're not required to worry much about whitespace and alignment when writing templates

### Step 5: write the rendered template to the exercise's test file

Finally, the output of the rendered template is written to the exercise's test file.

## Templates

The templates are rendered using the [Scriban library](https://github.com/scriban/scriban/).

## Command-line interface

There are two ways in which the test generator can be run:

1. `bin/generate-tests.ps1`: generate the tests for all exercises that have a generator template
2. `bin/generate-tests.ps1 -e <slug>`: generate the tests for the specified exercise, if it has a generator template
