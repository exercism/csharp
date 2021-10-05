# Instructions

In this exercise you'll be modelling a weighing machine.

You have 6 tasks each of which requires you to implement one or more properties:

## 1. Allow the weighing machine to have a precision.

It important to ensure that our weighing machine is precise.
Implement the `WeigingMachine` class to have a precision property set only from the constructor:

```csharp
var wm = new WeighingMachine(precision:3);

//  => wm.Precision == 3
```

## 2. Allow the weight to be set on the weighing machine

Implement the `WeigingMachine.Weight` property to allow the weight to be get and set:

```csharp
var wm = new WeighingMachine(precision:3);
wm.Weight = 60m;

//  => wm.Weight == 60m
```

## 3. Ensure that a negative input weight is rejected

The weight can be set and retrieved, but it can't be negative.
Add validation to the `WeighingMachine.Weight` property to throw an `ArgumentOutOfRangeException` when trying to set it to a negative weight:

```csharp
var wm = new WeighingMachine(precision:3);
wm.Weight = -10m; // Throws an ArgumentOutOfRangeException
```

## 4. Allow a tare adjustment to be applied to the weighing machine

The tare adjustment can be any value (even negative or a value that makes the display weight negative)
Implement the `WeighingMachine.TareAdjustment` property to allow the tare adjustment to be set:

```csharp
var wm = new WeighingMachine();
wm.TareAdjustment = -10;

// => wm.TareAdjustment == -10
```

## 5. Ensure that the weighing machine has a default tare Adjustment.

A tare adjustment can be applied to the weight they usually have a bias towards overestimating the weight.
Implement the `WeighingMachine.TareAdjustment` property to have the default value as 5.

```csharp
var wm = new WeighingMachine(precision:3);

// => wm.TareAdjustment == 5
```

## 6. Allow the weight to be retrieved

Implement the `WeighingMachine.DisplayWeight` property which shows weight after tare adjustment:
Note that:
``` display-weight = input-weight - tare-adjustment ```

```csharp
var wm = new WeighingMachine();
wm.Weight = 60m;

// => wm.DisplayWeight == 55m
```