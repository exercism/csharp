public class DequeTests
{
    [Fact]
    public void Pop_gets_element_from_the_list()
    {
        var sut = new Deque<int>();
        sut.Push(7);
        Assert.Equal(7, sut.Pop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Push_pop_respectively_add_remove_at_the_end_of_the_list()
    {
        var sut = new Deque<int>();
        sut.Push(11);
        sut.Push(13);
        Assert.Equal(13, sut.Pop());
        Assert.Equal(11, sut.Pop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shift_gets_an_element_from_the_list()
    {
        var sut = new Deque<int>();
        sut.Push(17);
        Assert.Equal(17, sut.Shift());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shift_gets_first_element_from_the_list()
    {
        var sut = new Deque<int>();
        sut.Push(23);
        sut.Push(5);
        Assert.Equal(23, sut.Shift());
        Assert.Equal(5, sut.Shift());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unshift_adds_element_at_start_of_the_list()
    {
        var sut = new Deque<int>();
        sut.Unshift(23);
        sut.Unshift(5);
        Assert.Equal(5, sut.Shift());
        Assert.Equal(23, sut.Shift());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Pop_push_shift_and_unshift_can_be_used_in_any_order()
    {
        var sut = new Deque<int>();
        sut.Push(1);
        sut.Push(2);
        Assert.Equal(2, sut.Pop());
        sut.Push(3);
        Assert.Equal(1, sut.Shift());
        sut.Unshift(4);
        sut.Push(5);
        Assert.Equal(4, sut.Shift());
        Assert.Equal(5, sut.Pop());
        Assert.Equal(3, sut.Shift());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Popping_to_empty_doesn_t_break_the_list()
    {
        var sut = new Deque<int>();
        sut.Push(41);
        sut.Push(59);
        sut.Pop();
        sut.Pop();
        sut.Push(47);
        Assert.Equal(47, sut.Pop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shifting_to_empty_doesn_t_break_the_list()
    {
        var sut = new Deque<int>();
        sut.Push(41);
        sut.Push(59);
        sut.Shift();
        sut.Shift();
        sut.Push(47);
        Assert.Equal(47, sut.Shift());
    }
}
