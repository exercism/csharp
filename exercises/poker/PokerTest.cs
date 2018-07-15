// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class PokerTest
{
    [Fact]
    public void Single_hand_always_wins()
    {
        var hands = new[] { "4S 5S 7H 8D JC" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S 5S 7H 8D JC" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Highest_card_out_of_all_hands_wins()
    {
        var hands = new[] { "4D 5S 6S 8D 3C", "2S 4C 7S 9H 10H", "3S 4S 5D 6H JH" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "3S 4S 5D 6H JH" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_tie_has_multiple_winners()
    {
        var hands = new[] { "4D 5S 6S 8D 3C", "2S 4C 7S 9H 10H", "3S 4S 5D 6H JH", "3H 4H 5C 6C JD" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "3S 4S 5D 6H JH", "3H 4H 5C 6C JD" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_hands_with_the_same_high_cards_tie_compares_next_highest_ranked_down_to_last_card()
    {
        var hands = new[] { "3S 5H 6S 8D 7H", "2S 5D 6D 8C 7S" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "3S 5H 6S 8D 7H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void One_pair_beats_high_card()
    {
        var hands = new[] { "4S 5H 6C 8D KH", "2S 4H 6S 4D JH" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "2S 4H 6S 4D JH" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Highest_pair_wins()
    {
        var hands = new[] { "4S 2H 6S 2D JH", "2S 4H 6C 4D JD" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "2S 4H 6C 4D JD" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_pairs_beats_one_pair()
    {
        var hands = new[] { "2S 8H 6S 8D JH", "4S 5H 4C 8C 5C" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S 5H 4C 8C 5C" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_two_pairs_highest_ranked_pair_wins()
    {
        var hands = new[] { "2S 8H 2D 8D 3H", "4S 5H 4C 8S 5D" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "2S 8H 2D 8D 3H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_two_pairs_with_the_same_highest_ranked_pair_tie_goes_to_low_pair()
    {
        var hands = new[] { "2S QS 2C QD JH", "JD QH JS 8D QC" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "JD QH JS 8D QC" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_two_identically_ranked_pairs_tie_goes_to_remaining_card_kicker_()
    {
        var hands = new[] { "JD QH JS 8D QC", "JS QS JC 2D QD" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "JD QH JS 8D QC" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_of_a_kind_beats_two_pair()
    {
        var hands = new[] { "2S 8H 2H 8D JH", "4S 5H 4C 8S 4H" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S 5H 4C 8S 4H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_three_of_a_kind_tie_goes_to_highest_ranked_triplet()
    {
        var hands = new[] { "2S 2H 2C 8D JH", "4S AH AS 8C AD" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S AH AS 8C AD" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void With_multiple_decks_two_players_can_have_same_three_of_a_kind_ties_go_to_highest_remaining_cards()
    {
        var hands = new[] { "4S AH AS 7C AD", "4S AH AS 8C AD" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S AH AS 8C AD" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void A_straight_beats_three_of_a_kind()
    {
        var hands = new[] { "4S 5H 4C 8D 4H", "3S 4D 2S 6D 5C" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "3S 4D 2S 6D 5C" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Aces_can_end_a_straight_10_j_q_k_a_()
    {
        var hands = new[] { "4S 5H 4C 8D 4H", "10D JH QS KD AC" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "10D JH QS KD AC" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Aces_can_start_a_straight_a_2_3_4_5_()
    {
        var hands = new[] { "4S 5H 4C 8D 4H", "4D AH 3S 2D 5C" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4D AH 3S 2D 5C" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_with_a_straight_tie_goes_to_highest_ranked_card()
    {
        var hands = new[] { "4S 6C 7S 8D 5H", "5S 7H 8S 9D 6H" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "5S 7H 8S 9D 6H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Even_though_an_ace_is_usually_high_a_5_high_straight_is_the_lowest_scoring_straight()
    {
        var hands = new[] { "2H 3C 4D 5D 6H", "4S AH 3S 2D 5H" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "2H 3C 4D 5D 6H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Flush_beats_a_straight()
    {
        var hands = new[] { "4C 6H 7D 8D 5H", "2S 4S 5S 6S 7S" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "2S 4S 5S 6S 7S" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_a_flush_tie_goes_to_high_card_down_to_the_last_one_if_necessary()
    {
        var hands = new[] { "4H 7H 8H 9H 6H", "2S 4S 5S 6S 7S" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4H 7H 8H 9H 6H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_house_beats_a_flush()
    {
        var hands = new[] { "3H 6H 7H 8H 5H", "4S 5H 4C 5D 4H" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S 5H 4C 5D 4H" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_a_full_house_tie_goes_to_highest_ranked_triplet()
    {
        var hands = new[] { "4H 4S 4D 9S 9D", "5H 5S 5D 8S 8D" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "5H 5S 5D 8S 8D" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void With_multiple_decks_both_hands_have_a_full_house_with_the_same_triplet_tie_goes_to_the_pair()
    {
        var hands = new[] { "5H 5S 5D 9S 9D", "5H 5S 5D 8S 8D" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "5H 5S 5D 9S 9D" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_of_a_kind_beats_a_full_house()
    {
        var hands = new[] { "4S 5H 4D 5D 4H", "3S 3H 2S 3D 3C" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "3S 3H 2S 3D 3C" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_four_of_a_kind_tie_goes_to_high_quad()
    {
        var hands = new[] { "2S 2H 2C 8D 2D", "4S 5H 5S 5D 5C" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "4S 5H 5S 5D 5C" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void With_multiple_decks_both_hands_with_identical_four_of_a_kind_tie_determined_by_kicker()
    {
        var hands = new[] { "3S 3H 2S 3D 3C", "3S 3H 4S 3D 3C" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "3S 3H 4S 3D 3C" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Straight_flush_beats_four_of_a_kind()
    {
        var hands = new[] { "4S 5H 5S 5D 5C", "7S 8S 9S 6S 10S" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "7S 8S 9S 6S 10S" };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_hands_have_straight_flush_tie_goes_to_highest_ranked_card()
    {
        var hands = new[] { "4H 6H 7H 8H 5H", "5S 7S 8S 9S 6S" };
        var actual = Poker.BestHands(hands);
        var expected = new[] { "5S 7S 8S 9S 6S" };
        Assert.Equal(expected, actual);
    }
}