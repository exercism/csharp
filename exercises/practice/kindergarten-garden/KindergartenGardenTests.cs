public class KindergartenGardenTests
{
    [Fact]
    public void Partial_garden_garden_with_single_student()
    {
        var sut = new KindergartenGarden("RC\nGG");
        Plant[] expected = [Plant.Radishes, Plant.Clover, Plant.Grass, Plant.Grass];
        Assert.Equal(expected, sut.Plants("Alice"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Partial_garden_different_garden_with_single_student()
    {
        var sut = new KindergartenGarden("VC\nRC");
        Plant[] expected = [Plant.Violets, Plant.Clover, Plant.Radishes, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Alice"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Partial_garden_garden_with_two_students()
    {
        var sut = new KindergartenGarden("VVCG\nVVRC");
        Plant[] expected = [Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Bob"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Partial_garden_multiple_students_for_the_same_garden_with_three_students_second_student_s_garden()
    {
        var sut = new KindergartenGarden("VVCCGG\nVVCCGG");
        Plant[] expected = [Plant.Clover, Plant.Clover, Plant.Clover, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Bob"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Partial_garden_multiple_students_for_the_same_garden_with_three_students_third_student_s_garden()
    {
        var sut = new KindergartenGarden("VVCCGG\nVVCCGG");
        Plant[] expected = [Plant.Grass, Plant.Grass, Plant.Grass, Plant.Grass];
        Assert.Equal(expected, sut.Plants("Charlie"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_alice_first_student_s_garden()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Violets, Plant.Radishes, Plant.Violets, Plant.Radishes];
        Assert.Equal(expected, sut.Plants("Alice"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_bob_second_student_s_garden()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Clover, Plant.Grass, Plant.Clover, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Bob"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_charlie()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Violets, Plant.Violets, Plant.Clover, Plant.Grass];
        Assert.Equal(expected, sut.Plants("Charlie"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_david()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Radishes, Plant.Violets, Plant.Clover, Plant.Radishes];
        Assert.Equal(expected, sut.Plants("David"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_eve()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Clover, Plant.Grass, Plant.Radishes, Plant.Grass];
        Assert.Equal(expected, sut.Plants("Eve"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_fred()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Fred"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_ginny()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Clover, Plant.Grass, Plant.Grass, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Ginny"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_harriet()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Violets, Plant.Radishes, Plant.Radishes, Plant.Violets];
        Assert.Equal(expected, sut.Plants("Harriet"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_ileana()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Grass, Plant.Clover, Plant.Violets, Plant.Clover];
        Assert.Equal(expected, sut.Plants("Ileana"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_joseph()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Violets, Plant.Clover, Plant.Violets, Plant.Grass];
        Assert.Equal(expected, sut.Plants("Joseph"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_kincaid_second_to_last_student_s_garden()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Grass, Plant.Clover, Plant.Clover, Plant.Grass];
        Assert.Equal(expected, sut.Plants("Kincaid"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_garden_for_larry_last_student_s_garden()
    {
        var sut = new KindergartenGarden("VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV");
        Plant[] expected = [Plant.Grass, Plant.Violets, Plant.Clover, Plant.Violets];
        Assert.Equal(expected, sut.Plants("Larry"));
    }
}
