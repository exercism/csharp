// This file was auto-generated based on version 2.0.0 of the canonical data.

using FakeItEasy;
using System;
using Xunit;

public class ReactTest
{
    [Fact]
    public void Input_cells_have_a_value()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(10);
        Assert.Equal(10, input.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void An_input_cells_value_can_be_set()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(4);
        input.Value = 20;
        Assert.Equal(20, input.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Compute_cells_calculate_initial_value()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        Assert.Equal(2, output.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Compute_cells_take_inputs_in_the_right_order()
    {
        var sut = new Reactor();
        var one = sut.CreateInputCell(1);
        var two = sut.CreateInputCell(2);
        var output = sut.CreateComputeCell(new[] { one, two }, inputs => inputs[0] + inputs[1] * 10);
        Assert.Equal(21, output.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Compute_cells_update_value_when_dependencies_are_changed()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        input.Value = 3;
        Assert.Equal(4, output.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Compute_cells_can_depend_on_other_compute_cells()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var timesTwo = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] * 2);
        var timesThirty = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] * 30);
        var output = sut.CreateComputeCell(new[] { timesTwo, timesThirty }, inputs => inputs[0] + inputs[1]);
        Assert.Equal(32, output.Value);
        input.Value = 3;
        Assert.Equal(96, output.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Compute_cells_fire_callbacks()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var callback1 = A.Fake<EventHandler<int>>();
        output.Changed += callback1;
        input.Value = 3;
        A.CallTo(() => callback1.Invoke(A<object>._, 4)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
    }

    [Fact(Skip = "Remove to run test")]
    public void Callback_cells_only_fire_on_change()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] < 3 ? 111 : 222);
        var callback1 = A.Fake<EventHandler<int>>();
        output.Changed += callback1;
        input.Value = 2;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
        input.Value = 4;
        A.CallTo(() => callback1.Invoke(A<object>._, 222)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
    }

    [Fact(Skip = "Remove to run test")]
    public void Callbacks_do_not_report_already_reported_values()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var callback1 = A.Fake<EventHandler<int>>();
        output.Changed += callback1;
        input.Value = 2;
        A.CallTo(() => callback1.Invoke(A<object>._, 3)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
        input.Value = 3;
        A.CallTo(() => callback1.Invoke(A<object>._, 4)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
    }

    [Fact(Skip = "Remove to run test")]
    public void Callbacks_can_fire_from_multiple_cells()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var plusOne = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var minusOne = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] - 1);
        var callback1 = A.Fake<EventHandler<int>>();
        plusOne.Changed += callback1;
        var callback2 = A.Fake<EventHandler<int>>();
        minusOne.Changed += callback2;
        input.Value = 10;
        A.CallTo(() => callback1.Invoke(A<object>._, 11)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
        A.CallTo(() => callback2.Invoke(A<object>._, 9)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Callbacks_can_be_added_and_removed()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(11);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var callback1 = A.Fake<EventHandler<int>>();
        output.Changed += callback1;
        var callback2 = A.Fake<EventHandler<int>>();
        output.Changed += callback2;
        input.Value = 31;
        A.CallTo(() => callback1.Invoke(A<object>._, 32)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
        A.CallTo(() => callback2.Invoke(A<object>._, 32)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback2);
        output.Changed -= callback1;
        var callback3 = A.Fake<EventHandler<int>>();
        output.Changed += callback3;
        input.Value = 41;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
    }

    [Fact(Skip = "Remove to run test")]
    public void Removing_a_callback_multiple_times_doesnt_interfere_with_other_callbacks()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var output = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var callback1 = A.Fake<EventHandler<int>>();
        output.Changed += callback1;
        var callback2 = A.Fake<EventHandler<int>>();
        output.Changed += callback2;
        output.Changed -= callback1;
        output.Changed -= callback1;
        output.Changed -= callback1;
        input.Value = 2;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
    }

    [Fact(Skip = "Remove to run test")]
    public void Callbacks_should_only_be_called_once_even_if_multiple_dependencies_change()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var plusOne = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var minusOne1 = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] - 1);
        var minusOne2 = sut.CreateComputeCell(new[] { minusOne1 }, inputs => inputs[0] - 1);
        var output = sut.CreateComputeCell(new[] { plusOne, minusOne2 }, inputs => inputs[0] * inputs[1]);
        var callback1 = A.Fake<EventHandler<int>>();
        output.Changed += callback1;
        input.Value = 4;
        A.CallTo(() => callback1.Invoke(A<object>._, 10)).MustHaveHappenedOnceExactly();
        Fake.ClearRecordedCalls(callback1);
    }

    [Fact(Skip = "Remove to run test")]
    public void Callbacks_should_not_be_called_if_dependencies_change_but_output_value_doesnt_change()
    {
        var sut = new Reactor();
        var input = sut.CreateInputCell(1);
        var plusOne = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] + 1);
        var minusOne = sut.CreateComputeCell(new[] { input }, inputs => inputs[0] - 1);
        var alwaysTwo = sut.CreateComputeCell(new[] { plusOne, minusOne }, inputs => inputs[0] - inputs[1]);
        var callback1 = A.Fake<EventHandler<int>>();
        alwaysTwo.Changed += callback1;
        input.Value = 2;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
        input.Value = 3;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
        input.Value = 4;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
        input.Value = 5;
        A.CallTo(() => callback1.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();
    }
}