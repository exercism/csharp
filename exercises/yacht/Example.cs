using System.Collections.Generic;
using System.Linq;

/// <summary>
/// C# solution for 'Yacht (dice game) - https://en.wikipedia.org/wiki/Yacht_(dice_game).
/// </summary>
public static class Yacht
{
    /// <summary>
    ///    Score a single throw of dice in Yacht
    ///    The dice game Yacht is from the same family as Poker Dice, Generala and particularly Yahtzee, 
    ///    of which it is a precursor.In the game, five dice are rolled and the result can be entered 
    ///    in any of twelve categories. The score of a throw of the dice depends on category chosen.
    ///
    ///    Scores in Yacht
    ///    Category    Score Example
    ///    Ones            1 × number of ones      1 1 1 4 5 scores 3
    ///    Twos            2 × number of twos      2 2 3 4 5 scores 4
    ///    Threes          3 × number of threes    3 3 3 3 3 scores 15
    ///    Fours           4 × number of fours     1 2 3 3 5 scores 0
    ///    Fives           5 × number of fives     5 1 5 2 5 scores 15
    ///    Sixes           6 × number of sixes     2 3 4 5 6 scores 6
    ///    Full House      Total of the dice       3 3 3 5 5 scores 19
    ///    Four of a Kind  Total of the four dice  4 4 4 4 6 scores 16
    ///    Little Straight 30 points               1 2 3 4 5 scores 30 
    ///    Big Straight    30 points               2 3 4 5 6 scores 30
    ///    Choice Sum of the dice         2 3 3 4 6 scores 18
    ///    Yacht           50 points               4 4 4 4 4 scores 50
    ///    If the dice do not satisfy the requirements of a category, the score is zero.If, for example,
    ///    Four Of A Kind is entered in the Yacht category, zero points are scored. A Yacht scores zero 
    ///    if entered in the Full House category.
    ///
    ///    Task
    ///    Given a list of values for five dice and a category, your solution should return 
    ///    the score of the dice for that category. If the dice do not satisfy the requirements
    ///    of the category your solution should return 0. You can assume that five values will always be presented,
    ///    and the value of each will be between one and six inclusively. You should not assume that the dice are ordered.
    /// </summary>
    /// <param name="diceSet">Dice Array</param>
    /// <param name="category">Name of category</param>
    /// <returns></returns>
    public static int Score(int[] diceSet, string category)
    {
        switch (category.ToLower())
        {
            //Ones: Any combination The sum of dice with the number 1.
            case "ones": return diceSet.Where(x => x == 1).Sum();
            //Twos: Any combination The sum of dice with the number 2. 
            case "twos": return diceSet.Where(x => x == 2).Sum();
            //Threes: Any combination The sum of dice with the number 3.
            case "threes": return diceSet.Where(x => x == 3).Sum();
            //Fours: Any combination The sum of dice with the number 4.
            case "fours": return diceSet.Where(x => x == 4).Sum();
            //Fives: Any combination The sum of dice with the number 5.
            case "fives": return diceSet.Where(x => x == 5).Sum();
            //Sixes: Any combination The sum of dice with the number 6.
            case "sixes": return diceSet.Where(x => x == 6).Sum();

            //Full House:  Three of one number and two of another.  Sum of all dice.
            case "full house":
                {
                    var testHashSet = new HashSet<int>();
                    diceSet.ToList().ForEach(x => testHashSet.Add(x));
                    return (testHashSet.Count() == 2) ? diceSet.Sum() : 0;
                }
            //Four-Of-A-Kind:  At least four dice showing the same face.   Sum of those four dice.
            case "four-of-a-kind": // ?
            case "four of a kind": // ?
                var testDict = new Dictionary<int, int>();
                diceSet.ToList().ForEach(x =>
                {
                    if (!testDict.ContainsKey(x)) testDict.Add(x, 1); else testDict[x]++;
                });
                if (testDict.Count > 2) return 0;
                else if (testDict.Count == 1 || testDict.ElementAt(0).Value >= 4) return testDict.Keys.ToArray()[0] * 4;
                else if (testDict.ElementAt(1).Value >= 4) return testDict.Keys.ToArray()[1] * 4;
                else return 0;

            //Little Straight: 1 - 2 - 3 - 4 - 5. Score varies. Often 30.
            case "little straight": return (string.Join("-", diceSet.OrderBy(x => x)) == "1-2-3-4-5") ? 30 : 0;
            //Big Straight:    2 - 3 - 4 - 5 - 6. Score varies. Often 30.
            case "big straight": return (string.Join("-", diceSet.OrderBy(x => x)) == "2-3-4-5-6") ? 30 : 0;
            //Choice: Any combination. Sum of all dice Dice.
            case "choice": return diceSet.Sum();
            //Yacht: All five dice showing the same face - scores 50.
            case "yacht":
                {
                    var testHashSet = new HashSet<int>();
                    diceSet.ToList().ForEach(x => testHashSet.Add(x));
                    return (testHashSet.Count() == 1) ? 50 : 0;
                }
            default:
                System.Console.WriteLine("*** Undefined category = '{0}' ***", category.ToLower());
                return 0;
        }
    }
}
