using GradeSchool;
using Xunit;

public class GradeSchoolTest
{
    // private readonly School school = new School();

    //[Fact]
    //public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    //{
    //    school.Add("Aimee", 2);
    //    var expected = new[] { "Aimee" };
    //    Assert.Equal(expected, school.Roster(2));
    //}

    [Fact]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {

        //Arrange 

        var school = new School();
        school.Add("Aimee", 2);

        var expected = new[] { "Aimee" };

        //Act 
        var actual = school.Roster(2);

        //Assert 
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {

        // Arrange 

        var school = new School();
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new[] { "Blair", "James", "Paul" };


        //Act 

        var actual = school.Roster(2);

        //Assert 
        Assert.Equal(expected, actual );
    }

    [Fact]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        //Arrange 

        var school = new School();
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        var expectedThree = new[] { "Chelsea" };
        var expectedSeven = new[] { "Logan" }; 

        //Act 

        var rosterThree = school.Roster(3);
        var rosterSeven = school.Roster(7);
        
        //Assert

        Assert.Equal(expectedThree, rosterThree);
        Assert.Equal(expectedSeven, rosterSeven);
    }

    [Fact]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {

        // Arrange 
        var school = new School();
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new[] { "Bradley", "Franklin" };

        // Act 

        var actual = school.Grade(5); 

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        //Arrange 

        var school = new School();

        // Act 
        var actual = school.Grade(1); 

        // Assert
        Assert.Empty(school.Grade(1));
    }

    [Fact]
    public void Student_names_in_each_grade_in_roster_are_sorted()
    {

        //Arrange 

        var school = new School();
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);

        var expected3 = new[] { "Kyle" }; 
        var expected4 = new[] { "Christopher", "Jennifer" };
        var expected6 = new[] { "Kareem" }; 

        //Act 

        var roster3 = school.Roster(3);
        var roster4 = school.Roster(4);
        var roster6 = school.Roster(6); 

        Assert.Equal(expected3, roster3);
        Assert.Equal(expected4, roster4); 
        Assert.Equal(expected6, roster6) ;
    }
}