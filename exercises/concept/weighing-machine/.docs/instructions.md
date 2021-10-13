# Instructions

In this exercise you'll be modelling a weighing machine with Kilograms as a Unit.

You have 6 tasks each of which requires you to implement one or more properties:

## 1. Allow the weighing machine to have a precision

To cater to different demands, we allow each weighing machine to be customized with a precision (the number of digits after the decimal separator).
Implement the `WeigingMachine` class to have a precision property set only from the constructor:

```csharp
var wm = new WeighingMachine(precision: 3);

//  => wm.Precision == 3
```

## 2. Allow the weight to be set on the weighing machine

Implement the `WeigingMachine.Weight` property to allow the weight to be get and set:

```csharp
var wm = new WeighingMachine(precision: 3);
wm.Weight = 60.5;

//  => wm.Weight == 60.5
```

## 3. Ensure that a negative input weight is rejected

Clearly, someone cannot have a negative weight. 
Add validation to the `WeighingMachine.Weight` property to throw an `ArgumentOutOfRangeException` when trying to set it to a negative weight:

```csharp
var wm = new WeighingMachine(precision: 3);
wm.Weight = -10; // Throws an ArgumentOutOfRangeException
```

## 4. Allow a tare adjustment to be applied to the weighing machine

The tare adjustment can be any value (even negative or a value that makes the display weight negative)
Implement the `WeighingMachine.TareAdjustment` property to allow the tare adjustment to be set:

```csharp
var wm = new WeighingMachine(precision: 3);
wm.TareAdjustment = -10.6;

// => wm.TareAdjustment == -10.6
```

## 5. Ensure that the weighing machine has a default tare adjustment

After some thorough testing, it appears that due to a manifacturing issue all weighing machines have a bias towards overestimating the weight by `5`.
Change the `WeighingMachine.TareAdjustment` property to `5` as its default value.

```csharp
var wm = new WeighingMachine(precision: 3);

// => wm.TareAdjustment == 5.0
```

## 6. Allow the weight to be retrieved

Implement the `WeighingMachine.DisplayWeight` property which shows weight after tare adjustment:
Note that:
``` display-weight = input-weight - tare-adjustment ```

```csharp
var wm = new WeighingMachine(precision: 3);
wm.TareAdjustment = 10;
wm.Weight = 60.5;

// => wm.DisplayWeight == 50.5
```