using Xunit;

public class PokerTests
{
    [Fact]
    public void Single_hand_always_wins()
    {
        string[] hands = ["4S 5S 7H 8D JC"];
        string[] expected = ["4S 5S 7H 8D JC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Highest_card_out_of_all_hands_wins()
    {
        string[] hands = ["4D 5S 6S 8D 3C", "2S 4C 7S 9H 10H", "3S 4S 5D 6H JH"];
        string[] expected = ["3S 4S 5D 6H JH"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_tie_has_multiple_winners()
    {
        string[] hands = ["4D 5S 6S 8D 3C", "2S 4C 7S 9H 10H", "3S 4S 5D 6H JH", "3H 4H 5C 6C JD"];
        string[] expected = ["3S 4S 5D 6H JH", "3H 4H 5C 6C JD"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_hands_with_the_same_high_cards_tie_compares_next_highest_ranked_down_to_last_card()
    {
        string[] hands = ["3S 5H 6S 8D 7H", "2S 5D 6D 8C 7S"];
        string[] expected = ["3S 5H 6S 8D 7H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Winning_high_card_hand_also_has_the_lowest_card()
    {
        string[] hands = ["2S 5H 6S 8D 7H", "3S 4D 6D 8C 7S"];
        string[] expected = ["2S 5H 6S 8D 7H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_pair_beats_high_card()
    {
        string[] hands = ["4S 5H 6C 8D KH", "2S 4H 6S 4D JH"];
        string[] expected = ["2S 4H 6S 4D JH"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Highest_pair_wins()
    {
        string[] hands = ["4S 2H 6S 2D JH", "2S 4H 6C 4D JD"];
        string[] expected = ["2S 4H 6C 4D JD"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_the_same_pair_high_card_wins()
    {
        string[] hands = ["4H 4S AH JC 3D", "4C 4D AS 5D 6C"];
        string[] expected = ["4H 4S AH JC 3D"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_pairs_beats_one_pair()
    {
        string[] hands = ["2S 8H 6S 8D JH", "4S 5H 4C 8C 5C"];
        string[] expected = ["4S 5H 4C 8C 5C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_two_pairs_highest_ranked_pair_wins()
    {
        string[] hands = ["2S 8H 2D 8D 3H", "4S 5H 4C 8S 5D"];
        string[] expected = ["2S 8H 2D 8D 3H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_two_pairs_with_the_same_highest_ranked_pair_tie_goes_to_low_pair()
    {
        string[] hands = ["2S QS 2C QD JH", "JD QH JS 8D QC"];
        string[] expected = ["JD QH JS 8D QC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_two_identically_ranked_pairs_tie_goes_to_remaining_card_kicker()
    {
        string[] hands = ["JD QH JS 8D QC", "JS QS JC 2D QD"];
        string[] expected = ["JD QH JS 8D QC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_two_pairs_that_add_to_the_same_value_win_goes_to_highest_pair()
    {
        string[] hands = ["6S 6H 3S 3H AS", "7H 7S 2H 2S AC"];
        string[] expected = ["7H 7S 2H 2S AC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_pairs_first_ranked_by_largest_pair()
    {
        string[] hands = ["5C 2S 5S 4H 4C", "6S 2S 6H 7C 2C"];
        string[] expected = ["6S 2S 6H 7C 2C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_of_a_kind_beats_two_pair()
    {
        string[] hands = ["2S 8H 2H 8D JH", "4S 5H 4C 8S 4H"];
        string[] expected = ["4S 5H 4C 8S 4H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_three_of_a_kind_tie_goes_to_highest_ranked_triplet()
    {
        string[] hands = ["2S 2H 2C 8D JH", "4S AH AS 8C AD"];
        string[] expected = ["4S AH AS 8C AD"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_multiple_decks_two_players_can_have_same_three_of_a_kind_ties_go_to_highest_remaining_cards()
    {
        string[] hands = ["5S AH AS 7C AD", "4S AH AS 8C AD"];
        string[] expected = ["4S AH AS 8C AD"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_straight_beats_three_of_a_kind()
    {
        string[] hands = ["4S 5H 4C 8D 4H", "3S 4D 2S 6D 5C"];
        string[] expected = ["3S 4D 2S 6D 5C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Aces_can_end_a_straight_10_j_q_k_a()
    {
        string[] hands = ["4S 5H 4C 8D 4H", "10D JH QS KD AC"];
        string[] expected = ["10D JH QS KD AC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Aces_can_start_a_straight_a_2_3_4_5()
    {
        string[] hands = ["4S 5H 4C 8D 4H", "4D AH 3S 2D 5C"];
        string[] expected = ["4D AH 3S 2D 5C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Aces_cannot_be_in_the_middle_of_a_straight_q_k_a_2_3()
    {
        string[] hands = ["2C 3D 7H 5H 2S", "QS KH AC 2D 3S"];
        string[] expected = ["2C 3D 7H 5H 2S"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_with_a_straight_tie_goes_to_highest_ranked_card()
    {
        string[] hands = ["4S 6C 7S 8D 5H", "5S 7H 8S 9D 6H"];
        string[] expected = ["5S 7H 8S 9D 6H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Even_though_an_ace_is_usually_high_a_5_high_straight_is_the_lowest_scoring_straight()
    {
        string[] hands = ["2H 3C 4D 5D 6H", "4S AH 3S 2D 5H"];
        string[] expected = ["2H 3C 4D 5D 6H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Flush_beats_a_straight()
    {
        string[] hands = ["4C 6H 7D 8D 5H", "2S 4S 5S 6S 7S"];
        string[] expected = ["2S 4S 5S 6S 7S"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_a_flush_tie_goes_to_high_card_down_to_the_last_one_if_necessary()
    {
        string[] hands = ["2H 7H 8H 9H 6H", "3S 5S 6S 7S 8S"];
        string[] expected = ["2H 7H 8H 9H 6H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_house_beats_a_flush()
    {
        string[] hands = ["3H 6H 7H 8H 5H", "4S 5H 4C 5D 4H"];
        string[] expected = ["4S 5H 4C 5D 4H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_a_full_house_tie_goes_to_highest_ranked_triplet()
    {
        string[] hands = ["4H 4S 4D 9S 9D", "5H 5S 5D 8S 8D"];
        string[] expected = ["5H 5S 5D 8S 8D"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_multiple_decks_both_hands_have_a_full_house_with_the_same_triplet_tie_goes_to_the_pair()
    {
        string[] hands = ["5H 5S 5D 9S 9D", "5H 5S 5D 8S 8D"];
        string[] expected = ["5H 5S 5D 9S 9D"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_of_a_kind_beats_a_full_house()
    {
        string[] hands = ["4S 5H 4D 5D 4H", "3S 3H 2S 3D 3C"];
        string[] expected = ["3S 3H 2S 3D 3C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_four_of_a_kind_tie_goes_to_high_quad()
    {
        string[] hands = ["2S 2H 2C 8D 2D", "4S 5H 5S 5D 5C"];
        string[] expected = ["4S 5H 5S 5D 5C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_multiple_decks_both_hands_with_identical_four_of_a_kind_tie_determined_by_kicker()
    {
        string[] hands = ["3S 3H 2S 3D 3C", "3S 3H 4S 3D 3C"];
        string[] expected = ["3S 3H 4S 3D 3C"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Straight_flush_beats_four_of_a_kind()
    {
        string[] hands = ["4S 5H 5S 5D 5C", "7S 8S 9S 6S 10S"];
        string[] expected = ["7S 8S 9S 6S 10S"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Aces_can_end_a_straight_flush_10_j_q_k_a()
    {
        string[] hands = ["KC AH AS AD AC", "10C JC QC KC AC"];
        string[] expected = ["10C JC QC KC AC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Aces_can_start_a_straight_flush_a_2_3_4_5()
    {
        string[] hands = ["KS AH AS AD AC", "4H AH 3H 2H 5H"];
        string[] expected = ["4H AH 3H 2H 5H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Aces_cannot_be_in_the_middle_of_a_straight_flush_q_k_a_2_3()
    {
        string[] hands = ["2C AC QC 10C KC", "QH KH AH 2H 3H"];
        string[] expected = ["2C AC QC 10C KC"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Both_hands_have_a_straight_flush_tie_goes_to_highest_ranked_card()
    {
        string[] hands = ["4H 6H 7H 8H 5H", "5S 7S 8S 9S 6S"];
        string[] expected = ["5S 7S 8S 9S 6S"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Even_though_an_ace_is_usually_high_a_5_high_straight_flush_is_the_lowest_scoring_straight_flush()
    {
        string[] hands = ["2H 3H 4H 5H 6H", "4D AD 3D 2D 5D"];
        string[] expected = ["2H 3H 4H 5H 6H"];
        Assert.Equal(expected, Poker.BestHands(hands));
    }
}
