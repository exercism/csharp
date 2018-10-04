// This file was auto-generated based on version 1.0.1 of the canonical data.

using Xunit;

public class RestApiTest
{
    [Fact]
    public void No_users()
    {
        var sut = new RestApi("[]");
        var actual = sut.Get("/users");
        Assert.Equal("[]", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_user()
    {
        var sut = new RestApi("[]");
        var actual = sut.Post("/add", "{\"user\":\"Adam\"}");
        Assert.Equal("{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Get_single_user()
    {
        var sut = new RestApi("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}]");
        var actual = sut.Get("/users", "{\"users\":[\"Bob\"]}");
        Assert.Equal("[{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}]", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_users_have_0_balance()
    {
        var sut = new RestApi("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}]");
        var actual = sut.Post("/iou", "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":3.0}");
        Assert.Equal("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0},{\"name\":\"Bob\",\"owes\":{\"Adam\":3.0},\"owed_by\":{},\"balance\":-3.0}]", actual);
    }

    [Fact]
    public void Borrower_has_negative_balance()
    {
        var sut = new RestApi("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{\"Chuck\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Chuck\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0}]");
        var actual = sut.Post("/iou", "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":3.0}");
        Assert.Equal("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0},{\"name\":\"Bob\",\"owes\":{\"Adam\":3.0,\"Chuck\":3.0},\"owed_by\":{},\"balance\":-6}]", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Lender_has_negative_balance()
    {
        var sut = new RestApi("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{\"Chuck\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Chuck\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0}]");
        var actual = sut.Post("/iou", "{\"lender\":\"Bob\",\"borrower\":\"Adam\",\"amount\":3.0}");
        Assert.Equal("[{\"name\":\"Adam\",\"owes\":{\"Bob\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Bob\",\"owes\":{\"Chuck\":3.0},\"owed_by\":{\"Adam\":3.0},\"balance\":0.0}]", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Lender_owes_borrower()
    {
        var sut = new RestApi("[{\"name\":\"Adam\",\"owes\":{\"Bob\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{\"Adam\":3.0},\"balance\":3.0}]");
        var actual = sut.Post("/iou", "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":2.0}");
        Assert.Equal("[{\"name\":\"Adam\",\"owes\":{\"Bob\":1.0},\"owed_by\":{},\"balance\":-1.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{\"Adam\":1.0},\"balance\":1.0}]", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Lender_owes_borrower_less_than_new_loan()
    {
        var sut = new RestApi("[{\"name\":\"Adam\",\"owes\":{\"Bob\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{\"Adam\":3.0},\"balance\":3.0}]");
        var actual = sut.Post("/iou", "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":4.0}");
        Assert.Equal("[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{\"Bob\":1.0},\"balance\":1.0},{\"name\":\"Bob\",\"owes\":{\"Adam\":1.0},\"owed_by\":{},\"balance\":-1.0}]", actual);
    }
}