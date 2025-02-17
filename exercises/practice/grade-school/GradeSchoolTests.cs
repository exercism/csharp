public class GradeSchoolTests
{
    [Fact]
    public void Roster_is_empty_when_no_student_is_added()
    {
        var sut = new GradeSchool();
        string[] expected = [];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_a_student()
    {
        var sut = new GradeSchool();
        Assert.True(sut.Add("Aimee", 2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Student_is_added_to_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Aimee", 2);
        string[] expected = ["Aimee"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Adding_multiple_students_in_the_same_grade_in_the_roster()
    {
        var sut = new GradeSchool();
        Assert.True(sut.Add("Blair", 2));
        Assert.True(sut.Add("James", 2));
        Assert.True(sut.Add("Paul", 2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_students_in_the_same_grade_are_added_to_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Blair", 2);
        sut.Add("James", 2);
        sut.Add("Paul", 2);
        string[] expected = ["Blair", "James", "Paul"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_add_student_to_same_grade_in_the_roster_more_than_once()
    {
        var sut = new GradeSchool();
        Assert.True(sut.Add("Blair", 2));
        Assert.True(sut.Add("James", 2));
        Assert.False(sut.Add("James", 2));
        Assert.True(sut.Add("Paul", 2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Student_not_added_to_same_grade_in_the_roster_more_than_once()
    {
        var sut = new GradeSchool();
        sut.Add("Blair", 2);
        sut.Add("James", 2);
        sut.Add("James", 2);
        sut.Add("Paul", 2);
        string[] expected = ["Blair", "James", "Paul"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Adding_students_in_multiple_grades()
    {
        var sut = new GradeSchool();
        Assert.True(sut.Add("Chelsea", 3));
        Assert.True(sut.Add("Logan", 7));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Students_in_multiple_grades_are_added_to_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Chelsea", 3);
        sut.Add("Logan", 7);
        string[] expected = ["Chelsea", "Logan"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cannot_add_same_student_to_multiple_grades_in_the_roster()
    {
        var sut = new GradeSchool();
        Assert.True(sut.Add("Blair", 2));
        Assert.True(sut.Add("James", 2));
        Assert.False(sut.Add("James", 3));
        Assert.True(sut.Add("Paul", 3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Student_not_added_to_multiple_grades_in_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Blair", 2);
        sut.Add("James", 2);
        sut.Add("James", 3);
        sut.Add("Paul", 3);
        string[] expected = ["Blair", "James", "Paul"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Students_are_sorted_by_grades_in_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Jim", 3);
        sut.Add("Peter", 2);
        sut.Add("Anna", 1);
        string[] expected = ["Anna", "Peter", "Jim"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Students_are_sorted_by_name_in_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Peter", 2);
        sut.Add("Zoe", 2);
        sut.Add("Alex", 2);
        string[] expected = ["Alex", "Peter", "Zoe"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Students_are_sorted_by_grades_and_then_by_name_in_the_roster()
    {
        var sut = new GradeSchool();
        sut.Add("Peter", 2);
        sut.Add("Anna", 1);
        sut.Add("Barb", 1);
        sut.Add("Zoe", 2);
        sut.Add("Alex", 2);
        sut.Add("Jim", 3);
        sut.Add("Charlie", 1);
        string[] expected = ["Anna", "Barb", "Charlie", "Alex", "Peter", "Zoe", "Jim"];
        Assert.Equal(expected, sut.Roster());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Grade_is_empty_if_no_students_in_the_roster()
    {
        var sut = new GradeSchool();
        string[] expected = [];
        Assert.Equal(expected, sut.Grade(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Grade_is_empty_if_no_students_in_that_grade()
    {
        var sut = new GradeSchool();
        sut.Add("Peter", 2);
        sut.Add("Zoe", 2);
        sut.Add("Alex", 2);
        sut.Add("Jim", 3);
        string[] expected = [];
        Assert.Equal(expected, sut.Grade(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Student_not_added_to_same_grade_more_than_once()
    {
        var sut = new GradeSchool();
        sut.Add("Blair", 2);
        sut.Add("James", 2);
        sut.Add("James", 2);
        sut.Add("Paul", 2);
        string[] expected = ["Blair", "James", "Paul"];
        Assert.Equal(expected, sut.Grade(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Student_not_added_to_multiple_grades()
    {
        var sut = new GradeSchool();
        sut.Add("Blair", 2);
        sut.Add("James", 2);
        sut.Add("James", 3);
        sut.Add("Paul", 3);
        string[] expected = ["Blair", "James"];
        Assert.Equal(expected, sut.Grade(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Student_not_added_to_other_grade_for_multiple_grades()
    {
        var sut = new GradeSchool();
        sut.Add("Blair", 2);
        sut.Add("James", 2);
        sut.Add("James", 3);
        sut.Add("Paul", 3);
        string[] expected = ["Paul"];
        Assert.Equal(expected, sut.Grade(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Students_are_sorted_by_name_in_a_grade()
    {
        var sut = new GradeSchool();
        sut.Add("Franklin", 5);
        sut.Add("Bradley", 5);
        sut.Add("Jeff", 1);
        string[] expected = ["Bradley", "Franklin"];
        Assert.Equal(expected, sut.Grade(5));
    }
}
