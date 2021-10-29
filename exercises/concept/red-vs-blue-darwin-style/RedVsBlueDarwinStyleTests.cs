using System;
using Xunit;
using Exercism.Tests;

public class RedVsBlueDarwinStyleTests
{
    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_is_Combined()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        Assert.NotNull(carBuilderType);
    }

    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_has_method_BuildBlue()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        Assert.NotNull(carBuilderType?.GetMethod("BuildBlue"));
    }

    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_has_method_BuildRed()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        Assert.NotNull(carBuilderType?.GetMethod("BuildRed"));
    }

    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_returns_Blue_Type()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        var returnType = carBuilderType?.GetMethod("BuildBlue")?.ReturnType;
        Assert.Equal("BlueRemoteControlCarTeam.RemoteControlCar", returnType?.FullName);
    }

    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_returns_Red_Type()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        var returnType = carBuilderType?.GetMethod("BuildRed")?.ReturnType;
        Assert.Equal("RedRemoteControlCarTeam.RemoteControlCar", returnType?.FullName);
    }

    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_can_BuildBlue_car()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        var blueRemoteControlCar = carBuilderType?.GetMethod("BuildBlue")?.Invoke(null, null);
        Assert.NotNull(blueRemoteControlCar);
    }

    [Fact]
    [Task(1)]
    public void Namespace_for_CarBuilder_can_BuildRed_car()
    {
        var carBuilderType = Type.GetType("Combined.CarBuilder");
        var redRemoteControlCar = carBuilderType?.GetMethod("BuildRed")?.Invoke(null, null);
        Assert.NotNull(redRemoteControlCar);
    }
}
