In this exercise you will be doing some more work on remote control cars.

An experimental car has been developed and the test track needs to be adapted to handle both production and experimental models. The two types of car have already been built and you need to find a way to deal with them both on the test track.

In addition, production cars are beginning to have some success. The team boss is keen to maintain the competitive spirit by publishing a ranking of the production cars.

## 1. Enable cars to be driven on the same test track

Please add a method to the `IRemoteControlCar` interface to expose the implementations of `Drive()` for the two types of car.

```csharp
TestTrack.Race(new ProductionRemoteControlCar());
TestTrack.Race(new ExperimentalRemoteControlCar());
// this should execute without an exception being thrown
```

## 2. Enable the distance travelled by different models on the test track to be compared

Please add a property to the `IRemoteControlCar` interface to expose the implementations of the `DistanceTravelled` property for the two types of car.

```csharp
var prod = new ProductionRemoteControlCar();
TestTrack.Race(prod);
var exp = new ExperimentalRemoteControlCar();
TestTrack.Race(exp);
prod.DistanceTravelled
// => 10
exp.DistanceTravelled
// => 20
```

## 3. Allow the production cars to be ranked

Please implement the `IComparable<T>` interface in the `ProductionRemoteControlCar` class. The default sort order for cars should be ascending order of victories.

Implement the static `TestTrack.GetRankedCars()` to return the cars passed is sorted in ascending order of number of victories.

```csharp
var prc1 = new ProductionRemoteControlCar();
var prc2 = new ProductionRemoteControlCar();
prc1.NumberOfVictories = 3;
prc2.NumberOfVictories = 2;
var rankings = TestTrack.GetRankedCars(prc1, prc2);
// => rankings[1] == prc1
```
