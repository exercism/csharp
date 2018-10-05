// This file was auto-generated based on version 1.0.1 of the canonical data.

using Xunit;

public class RestApiTest
{
    [Fact]
    public void No_users()
    {
        var url = "/users";
        var database = "[]";
        var sut = new RestApi(database);
        var actual = sut.Get(url);
        var expected = "[]";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_user()
    {
        var url = "/add";
        var payload = "{\"user\":\"Adam\"}";
        var database = "[]";
        var sut = new RestApi(database);
        var actual = sut.Post(url, payload);
        var expected = "{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Get_single_user()
    {
        var url = "/users";
        var payload = "{\"users\":[\"Bob\"]}";
        var database = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}]";
        var sut = new RestApi(database);
        var actual = sut.Get(url, payload);
        var expected = "[{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}]";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_users_have_0_balance()
    {
        var url = "/iou";
        var payload = "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":3.0}";
        var database = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{},\"balance\":0.0}]";
        var sut = new RestApi(database);
        var actual = sut.Post(url, payload);
        var expected = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0},{\"name\":\"Bob\",\"owes\":{\"Adam\":3.0},\"owed_by\":{},\"balance\":-3.0}]";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Borrower_has_negative_balance()
    {
        var url = "/iou";
        var payload = "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":3.0}";
        var database = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{\"Chuck\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Chuck\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0}]";
        var sut = new RestApi(database);
        var actual = sut.Post(url, payload);
        var expected = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0},{\"name\":\"Bob\",\"owes\":{\"Adam\":3.0,\"Chuck\":3.0},\"owed_by\":{},\"balance\":-6}]";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Lender_has_negative_balance()
    {
        var url = "/iou";
        var payload = "{\"lender\":\"Bob\",\"borrower\":\"Adam\",\"amount\":3.0}";
        var database = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{},\"balance\":0.0},{\"name\":\"Bob\",\"owes\":{\"Chuck\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Chuck\",\"owes\":{},\"owed_by\":{\"Bob\":3.0},\"balance\":3.0}]";
        var sut = new RestApi(database);
        var actual = sut.Post(url, payload);
        var expected = "[{\"name\":\"Adam\",\"owes\":{\"Bob\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Bob\",\"owes\":{\"Chuck\":3.0},\"owed_by\":{\"Adam\":3.0},\"balance\":0.0}]";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Lender_owes_borrower()
    {
        var url = "/iou";
        var payload = "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":2.0}";
        var database = "[{\"name\":\"Adam\",\"owes\":{\"Bob\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{\"Adam\":3.0},\"balance\":3.0}]";
        var sut = new RestApi(database);
        var actual = sut.Post(url, payload);
        var expected = "[{\"name\":\"Adam\",\"owes\":{\"Bob\":1.0},\"owed_by\":{},\"balance\":-1.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{\"Adam\":1.0},\"balance\":1.0}]";
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Lender_owes_borrower_less_than_new_loan()
    {
        var url = "/iou";
        var payload = "{\"lender\":\"Adam\",\"borrower\":\"Bob\",\"amount\":4.0}";
        var database = "[{\"name\":\"Adam\",\"owes\":{\"Bob\":3.0},\"owed_by\":{},\"balance\":-3.0},{\"name\":\"Bob\",\"owes\":{},\"owed_by\":{\"Adam\":3.0},\"balance\":3.0}]";
        var sut = new RestApi(database);
        var actual = sut.Post(url, payload);
        var expected = "[{\"name\":\"Adam\",\"owes\":{},\"owed_by\":{\"Bob\":1.0},\"balance\":1.0},{\"name\":\"Bob\",\"owes\":{\"Adam\":1.0},\"owed_by\":{},\"balance\":-1.0}]";
        Assert.Equal(expected, actual);
    }
}