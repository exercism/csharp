Some "other" developers have been working on the remote control car project (TODO cross-ref-tba). You have been called in to clean up the code.

## 1. Separate concerns between the car itself and the telemetry system

Refactor the `RemoteControlCar` class to move to separate out telemetry methods and properties.

```csharp
var car = new RemoteControlCar();
car.Telemetry.Calibrate();
car.Telemetry.SelfTest();
car.Telemetry.ShowSponsor("Walker Industries Inc.");
car.CurrentSponsor
// => "Walker Industries Inc."
car.Telemetry.SetSpeed(100, "cpm");
car.GetSpeed()
// => "100 centimeters per second"
```

## 2. Prevent other code taking too many dependencies on the Telemetry type

Ensure that the `Telemetry` instance cannot be created outside the scope of the car.

## 3. Prevent other code from taking dependencies on the Speed struct

Ensure that the `Speed` struct cannot be used outside the scope of the `RemoteControlCar` class.

## 4. Prevent other code from taking dependencies on the SpeedUnits enum

Ensure that the `SpeedUnits` enum cannot be used outside the scope of the `RemoteControlCar` class.
