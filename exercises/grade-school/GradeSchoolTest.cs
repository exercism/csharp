using Xunit;

public class GradeSchoolTest
{
    [Fact]
    public void Adding_a_student_adds_them_to_the_sorted_roster()
    {
        var school = new School();
        school.Add("Aimee", 2);

        var actual = school.Roster();

        var expected = new[] { "Aimee" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Adding_more_students_adds_them_to_the_sorted_roster()
    {
        var school = new School();
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
       
        var actual = school.Roster();

        var expected = new[] { "Blair", "James", "Paul" };
        Assert.Equal(expected, actual );
    }

    [Fact(Skip = "Remove to run test")]
    public void Adding_students_to_different_grades_adds_them_to_the_same_sorted_roster()
    {
        var school = new School();
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);

        var actual = school.Roster();

        var expected = new[] { "Chelsea", "Logan"};
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {
        var school = new School();
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        
        var actual = school.Grade(5);

        var expected = new[] { "Bradley", "Franklin" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        var school = new School();

        var actual = school.Grade(1); 

        Assert.Empty(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Student_names_with_grades_are_displayed_in_the_same_sorted_roster()
    {
        var school = new School();
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
              
        var actual = school.Roster();
        

        var expected = new[] { "Christopher", "Jennifer", "Kareem", "Kyle" };
        Assert.Equal(expected, actual);

        
    }
}