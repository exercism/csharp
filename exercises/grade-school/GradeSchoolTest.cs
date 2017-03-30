using Xunit;

public class GradeSchoolTest
{
    [Fact]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {
        var school = new School();
        school.Add("Aimee", 2);

        var actual = school.Roster(2);

        var expected = new[] { "Aimee" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {
        var school = new School();
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
       
        var actual = school.Roster(2);

        var expected = new[] { "Blair", "James", "Paul" };
        Assert.Equal(expected, actual );
    }

    [Fact(Skip = "Remove to run test")]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        var school = new School();
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        
        var rosterThree = school.Roster(3);
        var rosterSeven = school.Roster(7);

        var expectedThree = new[] { "Chelsea" };
        Assert.Equal(expectedThree, rosterThree);
        
        var expectedSeven = new[] { "Logan" };
        Assert.Equal(expectedSeven, rosterSeven);
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
    public void Student_names_in_each_grade_in_roster_are_sorted()
    {
        var school = new School();
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
              
        var roster3 = school.Roster(3);
        var roster4 = school.Roster(4);
        var roster6 = school.Roster(6);

        var expected3 = new[] { "Kyle" };
        Assert.Equal(expected3, roster3);

        var expected4 = new[] { "Christopher", "Jennifer" };
        Assert.Equal(expected4, roster4);

        var expected6 = new[] { "Kareem" };
        Assert.Equal(expected6, roster6) ;
    }
}