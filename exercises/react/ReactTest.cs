using Xunit;
using System.Collections.Generic;

public class ReactTest
{
    [Fact]
    public void Setting_the_value_of_an_input_cell_changes_the_observable_value()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);

        Assert.Equal(1, inputCell1.Value);
        inputCell1.Value = 2;
        Assert.Equal(2, inputCell1.Value);
    }

    [Fact(Skip="Remove to run test")]
    public void The_value_of_a_compute_is_determined_by_the_value_of_the_dependencies()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);

        Assert.Equal(2, computeCell1.Value);
        inputCell1.Value = 2;
        Assert.Equal(3, computeCell1.Value);
    }

    [Fact(Skip="Remove to run test")]
    public void Compute_cells_can_depend_on_other_compute_cells()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);
        var computeCell2 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] - 1);
        var computeCell3 = reactor.CreateComputeCell(new[] { computeCell1, computeCell2 }, (values) => values[0] * values[1]);

        Assert.Equal(0, computeCell3.Value);
        inputCell1.Value = 3;
        Assert.Equal(8, computeCell3.Value);
    }

    [Fact(Skip="Remove to run test")]
    public void Compute_cells_can_have_callbacks()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);
        var observed = new List<int>();
        computeCell1.Changed += (sender, value) => observed.Add(value);

        Assert.Empty(observed);
        inputCell1.Value = 2;
        Assert.Equal(new[] { 3 }, observed);
    }

    [Fact(Skip="Remove to run test")]
    public void Callbacks_only_trigger_on_change()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computecell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] > 2 ? values[0] + 1 : 2);
        var observerCalled = 0;
        computecell1.Changed += (sender, value) => observerCalled++;

        inputCell1.Value = 1;
        Assert.Equal(0, observerCalled);
        inputCell1.Value = 2;
        Assert.Equal(0, observerCalled);
        inputCell1.Value = 3;
        Assert.Equal(1, observerCalled);
    }

    [Fact(Skip="Remove to run test")]
    public void Callbacks_can_be_removed()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);
        var observed1 = new List<int>();
        var observed2 = new List<int>();

        ChangedEventHandler changedHandler1 = (object sender, int value) => observed1.Add(value);
        ChangedEventHandler changedHandler2 = (object sender, int value) => observed2.Add(value);

        computeCell1.Changed += changedHandler1;
        computeCell1.Changed += changedHandler2;

        inputCell1.Value = 2;
        Assert.Equal(new[] { 3 }, observed1);
        Assert.Equal(new[] { 3 }, observed2);

        computeCell1.Changed -= changedHandler1;
        inputCell1.Value = 3;
        Assert.Equal(new[] { 3 }, observed1);
        Assert.Equal(new[] { 3, 4 }, observed2);
    }

    [Fact(Skip="Remove to run test")]
    public void Callbacks_should_only_be_called_once_even_if_multiple_dependencies_have_changed()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);
        var computeCell2 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] - 1);
        var computeCell3 = reactor.CreateComputeCell(new[] { computeCell2 }, (values) => values[0] - 1);
        var computeCell4 = reactor.CreateComputeCell(new[] { computeCell1, computeCell3 }, (values) => values[0] * values[1]);

        var changed4 = 0;
        computeCell4.Changed += (sender, value) => changed4++;

        inputCell1.Value = 3;
        Assert.Equal(1, changed4);
    }
}
