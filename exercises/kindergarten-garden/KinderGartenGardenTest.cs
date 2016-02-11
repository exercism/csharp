using NUnit.Framework;

public class KinderGartenGardenTest
{
    [Test]
    public void Missing_child()
    {
        var actual = Garden.DefaultGarden("RC\nGG").GetPlants("Potter");
        Assert.That(actual, Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Alice()
    {
        Assert.That(Garden.DefaultGarden("RC\nGG").GetPlants("Alice"), Is.EqualTo(new [] { Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass }));
        Assert.That(Garden.DefaultGarden("VC\nRC").GetPlants("Alice"), Is.EqualTo(new[] { Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Small_garden()
    {
        var actual = Garden.DefaultGarden("VVCG\nVVRC").GetPlants("Bob");
        Assert.That(actual, Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Medium_garden()
    {
        var garden = Garden.DefaultGarden("VVCCGG\nVVCCGG");
        Assert.That(garden.GetPlants("Bob"), Is.EqualTo(new[] { Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover }));
        Assert.That(garden.GetPlants("Charlie"), Is.EqualTo(new[] { Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Full_garden()
    {
        var garden = Garden.DefaultGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Assert.That(garden.GetPlants("Alice"), Is.EqualTo(new[] { Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes }));
        Assert.That(garden.GetPlants("Bob"), Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover }));
        Assert.That(garden.GetPlants("David"), Is.EqualTo(new[] { Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes }));
        Assert.That(garden.GetPlants("Eve"), Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass }));
        Assert.That(garden.GetPlants("Fred"), Is.EqualTo(new[] { Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover }));
        Assert.That(garden.GetPlants("Ginny"), Is.EqualTo(new[] { Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover }));
        Assert.That(garden.GetPlants("Harriet"), Is.EqualTo(new[] { Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets }));
        Assert.That(garden.GetPlants("Ileana"), Is.EqualTo(new[] { Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover }));
        Assert.That(garden.GetPlants("Joseph"), Is.EqualTo(new[] { Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass }));
        Assert.That(garden.GetPlants("Kincaid"), Is.EqualTo(new[] { Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass }));
        Assert.That(garden.GetPlants("Larry"), Is.EqualTo(new[] { Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Surprise_garden()
    {
        var garden = new Garden(new [] { "Samantha", "Patricia", "Xander", "Roger" }, "VCRRGVRG\nRVGCCGCV");
        Assert.That(garden.GetPlants("Patricia"), Is.EqualTo(new[] { Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Violets }));
        Assert.That(garden.GetPlants("Roger"), Is.EqualTo(new[] { Plant.Radishes, Plant.Radishes, Plant.Grass, Plant.Clover }));
        Assert.That(garden.GetPlants("Samantha"), Is.EqualTo(new[] { Plant.Grass, Plant.Violets, Plant.Clover, Plant.Grass }));
        Assert.That(garden.GetPlants("Xander"), Is.EqualTo(new[] { Plant.Radishes, Plant.Grass, Plant.Clover, Plant.Violets }));
    }
}