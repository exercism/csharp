using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class GradeSchoolTest
{
    private School school;

    [SetUp]
    public void Setup()
    {
        school = new School();
    }

    [Test]
    public void NewSchoolHasAnEmptyRoster()
    {
        Assert.That(school.Roster, Has.Count.EqualTo(0));
    }

    [Test, Ignore]
    public void AddingAStudentAddsThemToTheRosterForTheGivenGrade()
    {
        school.Add("Aimee", 2);
        var expected = new List<string> { "Aimee" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Test, Ignore]
    public void AddingMoreStudentsToTheSameGradeAddsThemToTheRoster()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new List<string> { "Blair", "James", "Paul" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Test, Ignore]
    public void AddingStudentsToDifferentGradesAddsThemToTheRoster()
    {
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Chelsea" }));
        Assert.That(school.Roster[7], Is.EqualTo(new List<string> { "Logan" }));
    }

    [Test, Ignore]
    public void GradeReturnsTheStudentsInThatGradeInAlphabeticalOrder()
    {
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new List<string> { "Bradley", "Franklin" };
        Assert.That(school.Grade(5), Is.EqualTo(expected));
    }

    [Test, Ignore]
    public void GradeReturnsAnEmptyListIfThereAreNoStudentsInThatGrade()
    {
        Assert.That(school.Grade(1), Is.EqualTo(new List<string>()));
    }

    [Test, Ignore]
    public void StudentNamesInEachGradeInRosterAreSorted()
    {
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
        Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Kyle" }));
        Assert.That(school.Roster[4], Is.EqualTo(new List<string> { "Christopher", "Jennifer" }));
        Assert.That(school.Roster[6], Is.EqualTo(new List<string> { "Kareem" }));
    }
}