The remote control car project you kicked off in the `classes` exercise has gone well (congratulations!) and due to a number of recent sponsorship deals there is money in the budget for enhancements.

Part of the budget is being used to provide some telemetry.

To keep the sponsors sweet a panel has been installed on the car to display the sponsors names as it goes round the track.

You will note that the introduction of these fancy new technologies has dramatically reduced the car's battery life.

## 1. Enable the remote control car to display sponsor names

Implement `SetSponsors()` to take one or more sponsor names and store them on the car.

Note that the `SetSponsors()` method's argument is guaranteed to be non-null.

Implement `DisplaySponsor()` to display the selected sponsor. The first sponsor passed in has a `sponsorNum` of 0, the second, 1 etc.

```csharp
var car = RemoteControlCar.Buy();
car.SetSponsors("Exercism", "Walker Industries", "Acme Co.");
var sp2 = car.DisplaySponsor(sponsorNum: 1);
// => "Walker Industries"
```

## 2 Get the car's telemetry data

Implement the `RemoteControlCar.GetTelemetryData()` method.

`GetTelemetryData()` should make the battery percentage and distance driven in meters available via `out` parameters.

`GetTelementryData()` should return `false` if the serialNum argument is less than the previously received value. (There is some issue of multiple telemetry nodes being involved). In this case `serialNum` will be set to the highest previous `serialNum` and battery percentage and meters driven will both be set to `-1`. Where the call is successful `serialNum` remains unchanged.

```csharp
var car = RemoteControlCar.Buy();
car.Drive();
car.Drive();
int serialNum = 0;
car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);
// => true, 4L, 80, 4

serialNum = 1;
car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);
// => false, 4L, -1, -1
```

## 3 Add functionality so that the telemetry system can get battery usage per meter

Implement the `TelemetryClient.GetBatteryUsagePerMeter()` method.

This will call `RemoteControlCar.GetTelemetryData()`. If `GetTelemetryData()` returns `false` then this routine should return "no data". If `GetTelemetryData()` returns `true` then a message in the following form should be returned ""usage-per-meter=<BATTERY-USAGE-PER-METER". Where the calculation is (100 - current battery percentge) divided by the distance driven in meters so far.

```csharp
var car = RemoteControlCar.Buy();
car.Drive(); car.Drive();
var tc = new TelemetryClient(car);
int serialNum = 1;
tc.GetBatteryUsagePerMeter(serialNum);
// => "usage-per-meter=5"

serialNum = 4;
tc.GetBatteryUsagePerMeter(serialNum);
// => "no data"
```
