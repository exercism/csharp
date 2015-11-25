## Installing C&#35;

### Windows
There are a couple of different ways to get started using C#. The main way is to
install Visual Studio, the IDE for C# and related projects.

If you don't want to use the IDE, files can be compiled via command line using the
compiler provided by the .NET framework.

#### With Visual Studio

Install [Visual Studio Express 2013 for Windows Desktop](http://www.visualstudio.com/downloads/download-visual-studio-vs#d-express-windows-desktop). This will include the IDE and compiler for C#.

You can either start by creating your own project for working with the Exercism problems or you can download a Visual Studio solution that is already set up.

#### Exercism.io Visual Studio Template

This is a Visual Studio template that comes pre-configured to work on the problems in as many languages as Visual Studio supports.

![Solution Explorer](/img/setup/visualstudio/SolutionExplorer.png)

1. Download the [Exercism.io Visual Studio Template](https://github.com/rprouse/Exercism.VisualStudio) from GitHub by clicking the Download Zip button on the page.
2. Unzip the template into your exercises directory, for example `C:\src\exercises`
2. Install the [Exercism CLI](http://help.exercism.io/installing-the-cli.html)
3. Open a command prompt to your exercise directory
4. Add your API key to exercism `exercism configure --key=YOUR_API_KEY`
5. Configure your source directory in exercism `exercism configure --dir=C:\src\exercises`
6. [Fetch your first exercise](http://help.exercism.io/fetching-exercises.html) `exercism fetch csharp`
7. Open the Exercism solution in Visual Studio
8. Expand the Exercism.csharp project
9. Click on **Show All Files** in Solution Explorer (See below)
10. The exercise you just fetched will appear greyed out. Right click on the folder and **Include In Project**
11. Get coding...

![Add files](/img/setup/visualstudio/AddFiles.png)

The NUnit NuGet package is included in the project, so you will not need to install it.

If you have a paid version of Visual Studio install the [NUnit Visual Studio Test Adapter](https://visualstudiogallery.msdn.microsoft.com/6ab922d0-21c0-4f06-ab5f-4ecd1fe7175d). This will allow you to run the tests from within Visual Studio. If you have ReSharper installed, you can also [run the tests using ReSharper](https://www.jetbrains.com/resharper/features/unit_testing.html).

![Test Explorer](/img/setup/visualstudio/TestExplorer.png)

If you are using Visual Studio Express, install [NUnit 2.6.3](http://www.nunit.org/) and run the tests from the command line (see below).

#### Create a New Visual Studio Project

Once installed and started, click on "Create New Project" (alternatively, you can go to File->New->New Project).

![New Project](/img/setup/csharp/newProject.png)

Choose what language and project type (Visual C# and Class Library). Also name your project to whatever you'd like.

![Create Project](/img/setup/csharp/createNewProject.png)

Once created, feel free to drag and drop the C# Exercism folders into the project.

![Drag and Drop Folders](/img/setup/csharp/dragDropFolders.png)

In order to compile, get the [NUnit](http://nunit.org/) assembly referenced for the unit tests. This can be done via [NuGet](http://www.nuget.org/) - a package manager for Visual Studio. The best packages is to get the base [NUnit]() and the [NUnit.Runners](https://www.nuget.org/packages/NUnit.Runners/)
package since it includes the assemblies needed and a GUI test runner.

![Nuget](/img/setup/csharp/nugetMenu.png)

Two options to use Nuget - the NuGet manager or through the Package Manager Console.

The manager is the easiest way to get started.

![Nuget Manager](/img/setup/csharp/nugetManageNunitRunner.png)

The project should now be able to compile.

To start implementing the exercise, in Visual Studio, right click on where you want the file to go to and go to `Add` -> `Class`. Name it what you'd like.

![New Item](/img/setup/csharp/addNewClass.png)

Now you can start coding!

#### With the command line compiler
The .cs files can also be compiled without Visual Studio. Get the latest version of
[.NET installed](http://msdn.microsoft.com/en-us/library/5a4x27ek(v=vs.110).aspx) and there will be an executable called csc.exe.

The compiler executable is usually located in the Microsoft.NET\Framework\Version folder under the Windows directory.

Refer to this [MSDN article](http://msdn.microsoft.com/en-us/library/78f4aasd.aspx) for more information on the command line compiler.

### Mac

Install [Xamarin Studio](http://xamarin.com/download).

While Xamarin is most known for creating iOS and Android applications, it's still a perfect IDE to create C# console
or library projects which is all that's needed for Exercism.

Once installed and running, click on new solution and you'll find the C# library project to select.

![Xamarin New Project](/img/setup/csharp/xamarin-csharp.jpg)

### Linux

[Mono Develop](http://www.mono-project.com/Mono_For_Linux_Developers) is available for Linux.
