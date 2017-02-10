using Xunit;

public class GradeSchoolTest
{
    private readonly School school = new School();
    
    [Fact]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {
        school.Add("Aimee", 2);
        var expected = new [] { "Aimee" };
        Assert.Equal(expected, school.Roster(2));
    }

    [Fact]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new [] { "Blair", "James", "Paul" };
        Assert.Equal(expected, school.Roster(2));
    }

    [Fact]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        Assert.Equal(new [] { "Chelsea" }, school.Roster(3));
        Assert.Equal(new [] { "Logan" }, school.Roster(7));
    }

    [Fact]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new [] { "Bradley", "Franklin" };
        Assert.Equal(expected, school.Grade(5));
    }

    [Fact]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        Assert.Empty(school.Grade(1));
    }

    [Fact]
    public void Student_names_in_each_grade_in_roster_are_sorted()
    {
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
        Assert.Equal(new [] { "Kyle" }, school.Roster(3));
        Assert.Equal(new [] { "Christopher", "Jennifer" }, school.Roster(4));
        Assert.Equal(new [] { "Kareem" }, school.Roster(6));
    }
}