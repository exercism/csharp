// This file was auto-generated based on version 3.1.0 of the canonical data.

using Xunit;

public class RobotSimulatorTest
{
    [Fact]
    public void A_robot_is_created_with_a_position_and_a_direction_robots_are_created_with_a_position_and_direction()
    {
        var sut = new RobotSimulator(Direction.North, 0, 0);
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_robot_is_created_with_a_position_and_a_direction_negative_positions_are_allowed()
    {
        var sut = new RobotSimulator(Direction.South, -1, -1);
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(-1, sut.X);
        Assert.Equal(-1, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_north_to_east()
    {
        var sut = new RobotSimulator(Direction.North, 0, 0);
        sut.Move("R");
        Assert.Equal(Direction.East, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_east_to_south()
    {
        var sut = new RobotSimulator(Direction.East, 0, 0);
        sut.Move("R");
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_south_to_west()
    {
        var sut = new RobotSimulator(Direction.South, 0, 0);
        sut.Move("R");
        Assert.Equal(Direction.West, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_clockwise_changes_the_direction_from_west_to_north()
    {
        var sut = new RobotSimulator(Direction.West, 0, 0);
        sut.Move("R");
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_north_to_west()
    {
        var sut = new RobotSimulator(Direction.North, 0, 0);
        sut.Move("L");
        Assert.Equal(Direction.West, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_west_to_south()
    {
        var sut = new RobotSimulator(Direction.West, 0, 0);
        sut.Move("L");
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_south_to_east()
    {
        var sut = new RobotSimulator(Direction.South, 0, 0);
        sut.Move("L");
        Assert.Equal(Direction.East, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotates_the_robots_direction_90_degrees_counter_clockwise_changes_the_direction_from_east_to_north()
    {
        var sut = new RobotSimulator(Direction.East, 0, 0);
        sut.Move("L");
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_increases_the_y_coordinate_one_when_facing_north()
    {
        var sut = new RobotSimulator(Direction.North, 0, 0);
        sut.Move("A");
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(1, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_decreases_the_y_coordinate_by_one_when_facing_south()
    {
        var sut = new RobotSimulator(Direction.South, 0, 0);
        sut.Move("A");
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(0, sut.X);
        Assert.Equal(-1, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_increases_the_x_coordinate_by_one_when_facing_east()
    {
        var sut = new RobotSimulator(Direction.East, 0, 0);
        sut.Move("A");
        Assert.Equal(Direction.East, sut.Direction);
        Assert.Equal(1, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_the_robot_forward_1_space_in_the_direction_it_is_pointing_decreases_the_x_coordinate_by_one_when_facing_west()
    {
        var sut = new RobotSimulator(Direction.West, 0, 0);
        sut.Move("A");
        Assert.Equal(Direction.West, sut.Direction);
        Assert.Equal(-1, sut.X);
        Assert.Equal(0, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_east_and_north_from_readme()
    {
        var sut = new RobotSimulator(Direction.North, 7, 3);
        sut.Move("RAALAL");
        Assert.Equal(Direction.West, sut.Direction);
        Assert.Equal(9, sut.X);
        Assert.Equal(4, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_west_and_north()
    {
        var sut = new RobotSimulator(Direction.North, 0, 0);
        sut.Move("LAAARALA");
        Assert.Equal(Direction.West, sut.Direction);
        Assert.Equal(-4, sut.X);
        Assert.Equal(1, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_west_and_south()
    {
        var sut = new RobotSimulator(Direction.East, 2, -7);
        sut.Move("RRAAAAALA");
        Assert.Equal(Direction.South, sut.Direction);
        Assert.Equal(-3, sut.X);
        Assert.Equal(-8, sut.Y);
    }

    [Fact(Skip = "Remove to run test")]
    public void Where_r_turn_right_l_turn_left_and_a_advance_the_robot_can_follow_a_series_of_instructions_and_end_up_with_the_correct_position_and_direction_instructions_to_move_east_and_north()
    {
        var sut = new RobotSimulator(Direction.South, 8, 4);
        sut.Move("LAAARRRALLLL");
        Assert.Equal(Direction.North, sut.Direction);
        Assert.Equal(11, sut.X);
        Assert.Equal(5, sut.Y);
    }
}