using Xunit;

public class KinderGartenGardenTest
{
    [Fact]
    public void Missing_child()
    {
        var actual = Garden.DefaultGarden("RC\nGG").GetPlants("Potter");
        Assert.Empty(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Alice()
    {
        Assert.Equal(new [] { Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass }, Garden.DefaultGarden("RC\nGG").GetPlants("Alice"));
        Assert.Equal(new[] { Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover }, Garden.DefaultGarden("VC\nRC").GetPlants("Alice"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Small_garden()
    {
        var actual = Garden.DefaultGarden("VVCG\nVVRC").GetPlants("Bob");
        Assert.Equal(new[] { Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover }, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Medium_garden()
    {
        var garden = Garden.DefaultGarden("VVCCGG\nVVCCGG");
        Assert.Equal(new[] { Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover }, garden.GetPlants("Bob"));
        Assert.Equal(new[] { Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass }, garden.GetPlants("Charlie"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_garden()
    {
        var garden = Garden.DefaultGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Assert.Equal(new[] { Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes }, garden.GetPlants("Alice"));
        Assert.Equal(new[] { Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover }, garden.GetPlants("Bob"));
        Assert.Equal(new[] { Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes }, garden.GetPlants("David"));
        Assert.Equal(new[] { Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass }, garden.GetPlants("Eve"));
        Assert.Equal(new[] { Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover }, garden.GetPlants("Fred"));
        Assert.Equal(new[] { Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover }, garden.GetPlants("Ginny"));
        Assert.Equal(new[] { Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets }, garden.GetPlants("Harriet"));
        Assert.Equal(new[] { Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover }, garden.GetPlants("Ileana"));
        Assert.Equal(new[] { Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass }, garden.GetPlants("Joseph"));
        Assert.Equal(new[] { Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass }, garden.GetPlants("Kincaid"));
        Assert.Equal(new[] { Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets }, garden.GetPlants("Larry"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Surprise_garden()
    {
        var garden = new Garden(new [] { "Samantha", "Patricia", "Xander", "Roger" }, "VCRRGVRG\nRVGCCGCV");
        Assert.Equal(new[] { Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Violets }, garden.GetPlants("Patricia"));
        Assert.Equal(new[] { Plant.Radishes, Plant.Radishes, Plant.Grass, Plant.Clover }, garden.GetPlants("Roger"));
        Assert.Equal(new[] { Plant.Grass, Plant.Violets, Plant.Clover, Plant.Grass }, garden.GetPlants("Samantha"));
        Assert.Equal(new[] { Plant.Radishes, Plant.Grass, Plant.Clover, Plant.Violets }, garden.GetPlants("Xander"));
    }
}