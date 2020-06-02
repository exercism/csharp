In this exercise you're going to write some code to help you cook a brilliant lasagna from your favorite cooking book.

You have four tasks, all related to the time spent cooking the lasagna.

## 1. Define the expected oven time in minutes

Define the `Lasagna.ExpectedMinutesInOven()` method that does not take any parameters and returns how many minutes the lasagna should be in the oven. According to the cooking book, the expected oven time in minutes is 40:

```csharp
var lasagna = new Lasagna();
lasagna.ExpectedMinutesInOven();
// => 40
```

## 2. Calculate the remaining oven time in minutes

Define the `Lasagna.RemainingMinutesInOven()` method that takes the actual minutes the lasagna has been in the oven as a parameter and returns how many minutes the lasagna still has to remain in the oven, based on the expected oven time in minutes from the previous task.

```csharp
var lasagna = new Lasagna();
lasagna.RemainingMinutesInOven(30);
// => 10
```

## 3. Calculate the preparation time in minutes

Define the `Lasagna.PreparationTimeInMinutes()` method that takes the number of layers you added to the lasagna as a parameter and returns how many minutes you spent preparing the lasagna, assuming each layer takes you 2 minutes to prepare.

```csharp
var lasagna = new Lasagna();
lasagna.PreparationTimeInMinutes(2);
// => 4
```

## 4. Calculate the elapsed time in minutes

Define the `Lasagna.ElapsedTimeInMinutes()` method that takes two parameters: the first parameter is the number of layers you added to the lasagna, and the second parameter is the number of minutes the lasagna has been in the oven. The function should return how many minutes you've worked on cooking the lasagna, which is the sum of the preparation time in minutes, and the time in minutes the lasagna has spent in the oven at the moment.

```csharp
var lasagna = new Lasagna();
lasagna.ElapsedTimeInMinutes(3, 20);
// => 26
```
