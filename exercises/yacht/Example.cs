using System.Collections.Generic;
using System.Linq;

public static class Yacht
{
    public static int Score(int[] dice, string category)
    {
        switch (category.ToLower())
        {
            //Ones: Any combination The sum of dice with the number 1.
            case "ones": return dice.Where(x => x == 1).Sum();
            //Twos: Any combination The sum of dice with the number 2. 
            case "twos": return dice.Where(x => x == 2).Sum();
            //Threes: Any combination The sum of dice with the number 3.
            case "threes": return dice.Where(x => x == 3).Sum();
            //Fours: Any combination The sum of dice with the number 4.
            case "fours": return dice.Where(x => x == 4).Sum();
            //Fives: Any combination The sum of dice with the number 5.
            case "fives": return dice.Where(x => x == 5).Sum();
            //Sixes: Any combination The sum of dice with the number 6.
            case "sixes": return dice.Where(x => x == 6).Sum();

            //Full House:  Three of one number and two of another.  Sum of all dice.
            case "full house":
                {
                    var testHashSet = new HashSet<int>();
                    dice.ToList().ForEach(x => testHashSet.Add(x));
                    return (testHashSet.Count() == 2) ? dice.Sum() : 0;
                }
            //Four-Of-A-Kind:  At least four dice showing the same face.   Sum of those four dice.
            case "four-of-a-kind": 
            case "four of a kind": 
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
            case "little straight":
                return dice.OrderBy(x => x).SequenceEqual(new[] { 1, 2, 3, 4, 5 }) ? 30 : 0;
            //Big Straight:    2 - 3 - 4 - 5 - 6. Score varies. Often 30.
            case "big straight": 
                return dice.OrderBy(x => x).SequenceEqual(new[] { 2, 3, 4, 5, 6 }) ? 30 : 0;
            //Choice: Any combination. Sum of all dice Dice.
            case "choice": return dice.Sum();
            //Yacht: All five dice showing the same face - scores 50.
            case "yacht":
                {
                    var testHashSet = new HashSet<int>();
                    dice.ToList().ForEach(x => testHashSet.Add(x));
                    return (testHashSet.Count() == 1) ? 50 : 0;
                }
            default:
                System.Console.WriteLine("*** Undefined category = '{0}' ***", category.ToLower());
                return 0;
        }
    }
}
