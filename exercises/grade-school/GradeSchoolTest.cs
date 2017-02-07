using System.Collections.Generic;
using Xunit;

public class GradeSchoolTest
{
    private School school;

    [SetUp]
    public void Setup()
    {
        school = new School();
    }

    [Fact]
    public void New_school_has_an_empty_roster()
    {
        Assert.That(school.Roster, Has.Count.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {
        school.Add("Aimee", 2);
        var expected = new List<string> { "Aimee" };
        Assert.Equal(expected, school.Roster[2]);
    }

    [Fact(Skip="Remove to run test")]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new List<string> { "Blair", "James", "Paul" };
        Assert.Equal(expected, school.Roster[2]);
    }

    [Fact(Skip="Remove to run test")]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        Assert.Equal(new List<string> { "Chelsea" }, school.Roster[3]);
        Assert.Equal(new List<string> { "Logan" }, school.Roster[7]);
    }

    [Fact(Skip="Remove to run test")]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new List<string> { "Bradley", "Franklin" };
        Assert.Equal(expected, school.Grade(5));
    }

    [Fact(Skip="Remove to run test")]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        Assert.Equal(new List<string>(), school.Grade(1));
    }

    [Fact(Skip="Remove to run test")]
    public void Student_names_in_each_grade_in_roster_are_sorted()
    {
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
        Assert.Equal(new List<string> { "Kyle" }, school.Roster[3]);
        Assert.Equal(new List<string> { "Christopher", "Jennifer" }, school.Roster[4]);
        Assert.Equal(new List<string> { "Kareem" }, school.Roster[6]);
    }
}