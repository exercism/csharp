// This file was auto-generated based on version 2.2.0 of the canonical data.

using Xunit;

public class RobotSimulatorTest
{
    [Fact]
    public void A_robot_is_created_with_a_position_and_a_direction_robots_are_created_with_a_position_and_direction()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(0, sut.Coordinate.X);
        Assert.Equal(0, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_robot_is_created_with_a_position_and_a_direction_negative_positions_are_allowed()
    {
        var sut = new RobotSimulator(Direction.South, new Coordinate(-1, -1));
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(-1, sut.Coordinate.X);
        Assert.Equal(-1, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_does_not_change_the_position()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.TurnRight();
        Assert.Equal(0, sut.Coordinate.X);
        Assert.Equal(0, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_north_to_east()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.TurnRight();
        Assert.Equal(Direction.East, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_east_to_south()
    {
        var sut = new RobotSimulator(Direction.East, new Coordinate(0, 0));
        sut.TurnRight();
        Assert.Equal(Direction.South, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_south_to_west()
    {
        var sut = new RobotSimulator(Direction.South, new Coordinate(0, 0));
        sut.TurnRight();
        Assert.Equal(Direction.West, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_west_to_north()
    {
        var sut = new RobotSimulator(Direction.West, new Coordinate(0, 0));
        sut.TurnRight();
        Assert.Equal(Direction.North, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_does_not_change_the_position()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.TurnLeft();
        Assert.Equal(0, sut.Coordinate.X);
        Assert.Equal(0, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_north_to_west()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.TurnLeft();
        Assert.Equal(Direction.West, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_west_to_south()
    {
        var sut = new RobotSimulator(Direction.West, new Coordinate(0, 0));
        sut.TurnLeft();
        Assert.Equal(Direction.South, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_south_to_east()
    {
        var sut = new RobotSimulator(Direction.South, new Coordinate(0, 0));
        sut.TurnLeft();
        Assert.Equal(Direction.East, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_east_to_north()
    {
        var sut = new RobotSimulator(Direction.East, new Coordinate(0, 0));
        sut.TurnLeft();
        Assert.Equal(Direction.North, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_does_not_change_the_direction()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.Advance();
        Assert.Equal(Direction.North, sut.Direction);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_increases_the_y_coordinate_one_when_facing_north()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.Advance();
        Assert.Equal(0, sut.Coordinate.X);
        Assert.Equal(1, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_decreases_the_y_coordinate_by_one_when_facing_south()
    {
        var sut = new RobotSimulator(Direction.South, new Coordinate(0, 0));
        sut.Advance();
        Assert.Equal(0, sut.Coordinate.X);
        Assert.Equal(-1, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_increases_the_x_coordinate_by_one_when_facing_east()
    {
        var sut = new RobotSimulator(Direction.East, new Coordinate(0, 0));
        sut.Advance();
        Assert.Equal(1, sut.Coordinate.X);
        Assert.Equal(0, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_decreases_the_x_coordinate_by_one_when_facing_west()
    {
        var sut = new RobotSimulator(Direction.West, new Coordinate(0, 0));
        sut.Advance();
        Assert.Equal(-1, sut.Coordinate.X);
        Assert.Equal(0, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_west_and_north()
    {
        var sut = new RobotSimulator(Direction.North, new Coordinate(0, 0));
        sut.Simulate("LAAARALA");
        Assert.Equal(Direction.West, sut.Direction);
        Assert.Equal(-4, sut.Coordinate.X);
        Assert.Equal(1, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_west_and_south()
    {
        var sut = new RobotSimulator(Direction.East, new Coordinate(2, -7));
        sut.Simulate("RRAAAAALA");
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(-3, sut.Coordinate.X);
        Assert.Equal(-8, sut.Coordinate.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_east_and_north()
    {
        var sut = new RobotSimulator(Direction.South, new Coordinate(8, 4));
        sut.Simulate("LAAARRRALLLL");
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(11, sut.Coordinate.X);
        Assert.Equal(5, sut.Coordinate.Y);
    }
}