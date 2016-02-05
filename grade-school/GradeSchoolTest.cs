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
    public void New_school_has_an_empty_roster()
    {
        Assert.That(school.Roster, Has.Count.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {
        school.Add("Aimee", 2);
        var expected = new List<string> { "Aimee" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new List<string> { "Blair", "James", "Paul" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Chelsea" }));
        Assert.That(school.Roster[7], Is.EqualTo(new List<string> { "Logan" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new List<string> { "Bradley", "Franklin" };
        Assert.That(school.Grade(5), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        Assert.That(school.Grade(1), Is.EqualTo(new List<string>()));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Student_names_in_each_grade_in_roster_are_sorted()
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