using NUnit.Framework;
using System.Collections.Generic;

public class ReactTest
{
    [Test]
    public void Setting_the_value_of_an_input_cell_changes_the_observable_value()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);

        Assert.That(inputCell1.Value, Is.EqualTo(1));
        inputCell1.Value = 2;
        Assert.That(inputCell1.Value, Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void The_value_of_a_compute_is_determined_by_the_value_of_the_dependencies()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);

        Assert.That(computeCell1.Value, Is.EqualTo(2));
        inputCell1.Value = 2;
        Assert.That(computeCell1.Value, Is.EqualTo(3));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Compute_cells_can_depend_on_other_compute_cells()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);
        var computeCell2 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] - 1);
        var computeCell3 = reactor.CreateComputeCell(new[] { computeCell1, computeCell2 }, (values) => values[0] * values[1]);

        Assert.That(computeCell3.Value, Is.EqualTo(0));
        inputCell1.Value = 3;
        Assert.That(computeCell3.Value, Is.EqualTo(8));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Compute_cells_can_have_callbacks()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computeCell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] + 1);
        var observed = new List<int>();
        computeCell1.Changed += (sender, value) => observed.Add(value);

        Assert.That(observed, Is.Empty);
        inputCell1.Value = 2;
        Assert.That(observed, Is.EquivalentTo(new[] { 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Callbacks_only_trigger_on_change()
    {
        var reactor = new Reactor();
        var inputCell1 = reactor.CreateInputCell(1);
        var computecell1 = reactor.CreateComputeCell(new[] { inputCell1 }, (values) => values[0] > 2 ? values[0] + 1 : 2);
        var observerCalled = 0;
        computecell1.Changed += (sender, value) => observerCalled++;

        inputCell1.Value = 1;
        Assert.That(observerCalled, Is.EqualTo(0));
        inputCell1.Value = 2;
        Assert.That(observerCalled, Is.EqualTo(0));
        inputCell1.Value = 3;
        Assert.That(observerCalled, Is.EqualTo(1));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(observed1, Is.EquivalentTo(new[] { 3 }));
        Assert.That(observed2, Is.EquivalentTo(new[] { 3 }));

        computeCell1.Changed -= changedHandler1;
        inputCell1.Value = 3;
        Assert.That(observed1, Is.EquivalentTo(new[] { 3 }));
        Assert.That(observed2, Is.EquivalentTo(new[] { 3, 4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(changed4, Is.EqualTo(1));
    }
}
