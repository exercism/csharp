### Windows
All tests have been ignored except the first one for you to work on. To continue, just remove the ```[Ignore]``` attribute on the test to start working on it.

Make sure [NUnit](http://nunit.org/?p=download) version 3.x is installed, if not already installed from the setup from above.

This installation should include the NUnit-Gui executable. Run this and, after compiling, open the assembly from the Gui and you are able to run the tests.

**Note:** You may need to include the nunit-framework.dll in the same directory as the source code you're compiling if you get an error saying it can't find the ```nunit.framework.dll```.

If you installed the NUnit runner through NuGet, the runner will be located in the ```\packages\NUnit.Console(version number)\tools``` folder where your project is.

If you installed NUnit manually the runner will be in the ```Program Files (x86)\NUnit(version number)\bin``` folder.

![NUnit Runner](http://x.exercism.io/v3/tracks/csharp/docs/img/nUnitRunner.png)

Once you have been able to compile the code it will create a DLL in the ```\bin\Debug``` folder of your project. In the NUnit runner, select "Open Project" and select the DLL that was created from compiling. This will load all the tests and allow you to run them.

![NUnit Runner Execute Tests](http://x.exercism.io/v3/tracks/csharp/docs/img/nUnitExecuteTests.png)

The NUnit runner will automatically reload the DLL if it has been updated.

### Mac
Xamarin Studio also ships with NUnit. To set the tests up you will have to add NUnit as a new project to your solution, name it correctly and set a reference to your solution.

This is the example setup for the "leap" exercise. We assume you created a solution called `LeapCalculator`.

Right-click the solution and choose *Add* -> *Add New Project*.
![Add Xamarin NUnit Test](http://x.exercism.io/v3/tracks/csharp/docs/img/xamarin-add-new-project.png)

Then from the new project dialog, select an NUnit Library Project.
![Xamarin NUnit](http://x.exercism.io/v3/tracks/csharp/docs/img/xamarin-nunit.jpg)

For the project name append `.Tests` to the name of your solution. So in our case `LeapCalculator.Tests`
![Xamarin NUnit](http://x.exercism.io/v3/tracks/csharp/docs/img/xamarin-naming.png)

Set a reference to your solution with right-click on references in your test project. Then choose the Projects tab and tick the box to your solution and  click `ok`.

![Xamarin NUnit](http://x.exercism.io/v3/tracks/csharp/docs/img/xamarin-edit-reference.png)

![Xamarin NUnit](http://x.exercism.io/v3/tracks/csharp/docs/img/xamarin-add-reference.png)

Add some of the tests from the exercise or write your own.

To run the tests open the `Unit Tests` pad within Xamarin (View -> Pads -> Unit Tests) and click `Run All`.

![Xamarin NUnit](http://x.exercism.io/v3/tracks/csharp/docs/img/xamarin-tests.png)
