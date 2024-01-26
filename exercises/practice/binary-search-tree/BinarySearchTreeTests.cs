using Xunit;
using System.Text.RegularExpressions;

public class BinarySearchTreeTests
{
    [Fact]
    public void New_bst_is_empty()
    {
        var sut = new BinarySearchTree<int>();
        Assert.Equal(0, sut.Count);
    }

    [Fact]
    public void New_bst_can_be_serialized_to_json()
    {
        var sut = new BinarySearchTree<int>();
        Assert.Null(sut.ToJson());
    }

    [Fact]
    public void Single_value_can_be_found()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(4);
        Assert.False(sut.Contains(1));
        Assert.True(sut.Contains(4));
    }

    [Fact]
    public void Single_value_can_be_serialized()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(4);
        var expected = """
        {
            "data": 4,
            "left": null,
            "right": null
        }
        """;
        Assert.Equal(WithoutSpaces(expected), WithoutSpaces(sut.ToJson()));
    }

    [Fact]
    public void Insert_data_at_proper_node_42()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(4);
        sut.Add(2);
        var expected = """
        {
            "data": 4,
            "left": {
                "data": 2,
                "left": null,
                "right": null
            },
            "right": null
        }
        """;
        Assert.Equal(WithoutSpaces(expected), WithoutSpaces(sut.ToJson()));
    }

    [Fact]
    public void Insert_data_at_proper_node_44()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(4);
        sut.Add(4);
        var expected = """
        {
            "data": 4,
            "left": {
                "data": 4,
                "left": null,
                "right": null
            },
            "right": null
        }
        """;
        Assert.Equal(WithoutSpaces(expected), WithoutSpaces(sut.ToJson()));
    }

    [Fact]
    public void Insert_data_at_proper_node_45()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(4);
        sut.Add(5);
        var expected = """
        {
            "data": 4,
            "left": null,
            "right": {
                "data": 5,
                "left": null,
                "right": null
            }
        }
        """;
        Assert.Equal(WithoutSpaces(expected), WithoutSpaces(sut.ToJson()));
    }

    [Fact]
    public void Insert_data_at_proper_node_4261357()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(4);
        sut.Add(2);
        sut.Add(6);
        sut.Add(1);
        sut.Add(3);
        sut.Add(5);
        sut.Add(7);
        var expected = """
        {
            "data": 4,
            "left": {
                "data": 2,
                "left": {
                    "data": 1,
                    "left": null,
                    "right": null
                },
                "right": {
                    "data": 3,
                    "left": null,
                    "right": null
                }
            },
            "right": {
                "data": 6,
                "left": {
                    "data": 5,
                    "left": null,
                    "right": null
                },
                "right": {
                    "data": 7,
                    "left": null,
                    "right": null
                }
            }
        }
        """;
        Assert.Equal(WithoutSpaces(expected), WithoutSpaces(sut.ToJson()));
    }

    [Fact]
    public void Can_sort_a_single_number()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(2);
        Assert.Equal(new int[] {2}, sut.GetOrderedValues());
    }

    [Fact]
    public void Can_sort_if_second_number_is_smaller_than_first()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(2);
        sut.Add(1);
        Assert.Equal(new int[] {1, 2}, sut.GetOrderedValues());
    }

    [Fact]
    public void Can_sort_if_second_number_is_same_as_first()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(2);
        sut.Add(2);
        Assert.Equal(new int[] {2, 2}, sut.GetOrderedValues());
    }

    [Fact]
    public void Can_sort_if_second_number_is_greater_than_first()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(2);
        sut.Add(3);
        Assert.Equal(new int[] {2, 3}, sut.GetOrderedValues());
    }

    [Fact]
    public void Can_sort_complex_tree()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(2);
        sut.Add(1);
        sut.Add(3);
        sut.Add(6);
        sut.Add(7);
        sut.Add(5);
        Assert.Equal(new int[] {1, 2, 3, 5, 6, 7}, sut.GetOrderedValues());
    }

    private static string WithoutSpaces(string text)
    => Regex.Replace(text, @"\s+", "");
}