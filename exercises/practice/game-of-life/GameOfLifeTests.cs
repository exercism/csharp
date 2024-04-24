using System;
using Xunit;

public class GameOfLifeTests
{
    [Fact]
    public void Empty_matrix()
    {
        var matrix = new int[,] { };
        Assert.Empty(GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Live_cells_with_zero_live_neighbors_die()
    {
        var matrix = new[,]
        {
             { 0, 0, 0 },
             { 0, 1, 0 },
             { 0, 0, 0 }
        };
        var expected = new[,]
        {
             { 0, 0, 0 },
             { 0, 0, 0 },
             { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Live_cells_with_only_one_live_neighbor_die()
    {
        var matrix = new[,]
        {
             { 0, 0, 0 },
             { 0, 1, 0 },
             { 0, 1, 0 }
        };
        var expected = new[,]
        {
             { 0, 0, 0 },
             { 0, 0, 0 },
             { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Live_cells_with_two_live_neighbors_stay_alive()
    {
        var matrix = new[,]
        {
             { 1, 0, 1 },
             { 1, 0, 1 },
             { 1, 0, 1 }
        };
        var expected = new[,]
        {
             { 0, 0, 0 },
             { 1, 0, 1 },
             { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Live_cells_with_three_live_neighbors_stay_alive()
    {
        var matrix = new[,]
        {
             { 0, 1, 0 },
             { 1, 0, 0 },
             { 1, 1, 0 }
        };
        var expected = new[,]
        {
             { 0, 0, 0 },
             { 1, 0, 0 },
             { 1, 1, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Dead_cells_with_three_live_neighbors_become_alive()
    {
        var matrix = new[,]
        {
             { 1, 1, 0 },
             { 0, 0, 0 },
             { 1, 0, 0 }
        };
        var expected = new[,]
        {
             { 0, 0, 0 },
             { 1, 1, 0 },
             { 0, 0, 0 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Live_cells_with_four_or_more_neighbors_die()
    {
        var matrix = new[,]
        {
             { 1, 1, 1 },
             { 1, 1, 1 },
             { 1, 1, 1 }
        };
        var expected = new[,]
        {
             { 1, 0, 1 },
             { 0, 0, 0 },
             { 1, 0, 1 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Bigger_matrix()
    {
        var matrix = new[,]
        {
             { 1, 1, 0, 1, 1, 0, 0, 0 },
             { 1, 0, 1, 1, 0, 0, 0, 0 },
             { 1, 1, 1, 0, 0, 1, 1, 1 },
             { 0, 0, 0, 0, 0, 1, 1, 0 },
             { 1, 0, 0, 0, 1, 1, 0, 0 },
             { 1, 1, 0, 0, 0, 1, 1, 1 },
             { 0, 0, 1, 0, 1, 0, 0, 1 },
             { 1, 0, 0, 0, 0, 0, 1, 1 }
        };
        var expected = new[,]
        {
             { 1, 1, 0, 1, 1, 0, 0, 0 },
             { 0, 0, 0, 0, 0, 1, 1, 0 },
             { 1, 0, 1, 1, 1, 1, 0, 1 },
             { 1, 0, 0, 0, 0, 0, 0, 1 },
             { 1, 1, 0, 0, 1, 0, 0, 1 },
             { 1, 1, 0, 1, 0, 0, 0, 1 },
             { 1, 0, 0, 0, 0, 0, 0, 0 },
             { 0, 0, 0, 0, 0, 0, 1, 1 }
        };
        Assert.Equal(expected, GameOfLife.Tick(matrix));
    }
}
