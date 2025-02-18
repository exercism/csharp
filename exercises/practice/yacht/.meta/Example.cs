using System.Collections.Generic;
using System.Linq;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        switch (category)
        {
            //Ones: Any combination. The sum of dice with the number 1.
            case YachtCategory.Ones: return dice.Where(x => x == 1).Sum();
            //Twos: Any combination. The sum of dice with the number 2. 
            case YachtCategory.Twos: return dice.Where(x => x == 2).Sum();
            //Threes: Any combination. The sum of dice with the number 3.
            case YachtCategory.Threes: return dice.Where(x => x == 3).Sum();
            //Fours: Any combination The sum of dice with the number 4.
            case YachtCategory.Fours: return dice.Where(x => x == 4).Sum();
            //Fives: Any combination. The sum of dice with the number 5.
            case YachtCategory.Fives: return dice.Where(x => x == 5).Sum();
            //Sixes: Any combination. The sum of dice with the number 6.
            case YachtCategory.Sixes: return dice.Where(x => x == 6).Sum();

            //Full House:  Three of one number and two of another.  Sum of all dice.
            case YachtCategory.FullHouse:
                var diceByValue = dice.ToLookup(x => x);
                return diceByValue.Count == 2 && diceByValue.First().Count() == 2 || diceByValue.First().Count() == 3 ? dice.Sum() : 0;
            //Four-Of-A-Kind:  At least four dice showing the same face.   Sum of those four dice.
            case YachtCategory.FourOfAKind: 
                var testDict = new Dictionary<int, int>();
                dice.ToList().ForEach(x =>
                {
                    if (!testDict.ContainsKey(x)) testDict.Add(x, 1); else testDict[x]++;
                });
                if (testDict.Count > 2) return 0;
                else if (testDict.Count == 1 || testDict.ElementAt(0).Value >= 4) return testDict.Keys.ElementAt(0) * 4;
                else if (testDict.ElementAt(1).Value >= 4) return testDict.Keys.ElementAt(1) * 4;
                else return 0;
            //Little Straight: 1 - 2 - 3 - 4 - 5. Score varies. Often 30.
            case YachtCategory.LittleStraight:
                return dice.OrderBy(x => x).SequenceEqual(new[] { 1, 2, 3, 4, 5 }) ? 30 : 0;
            //Big Straight:    2 - 3 - 4 - 5 - 6. Score varies. Often 30.
            case YachtCategory.BigStraight: 
                return dice.OrderBy(x => x).SequenceEqual(new[] { 2, 3, 4, 5, 6 }) ? 30 : 0;
            //Choice: Any combination. Sum of all dice Dice.
            case YachtCategory.Choice: return dice.Sum();
            //Yacht: All five dice showing the same face - scores 50.
            case YachtCategory.Yacht:
                return dice.Distinct().Count() == 1 ? 50 : 0;
            default: return 0;
        }
    }
}
