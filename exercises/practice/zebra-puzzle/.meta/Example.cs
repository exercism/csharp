using System;
using System.Collections.Generic;
using System.Linq;

public enum Color { Red , Green , Ivory , Yellow , Blue }
public enum Nationality { Englishman , Spaniard , Ukranian , Japanese , Norwegian }
public enum Pet { Dog , Snails , Fox , Horse , Zebra }
public enum Drink { Coffee , Tea , Milk , OrangeJuice , Water }
public enum Smoke { OldGold , Kools , Chesterfields , LuckyStrike , Parliaments }

public static class ZebraPuzzle
{
    private static readonly Color[] Colors = (Color[]) Enum.GetValues(typeof(Color));
    private static readonly Nationality[] Nationalities = (Nationality[]) Enum.GetValues(typeof(Nationality));
    private static readonly Pet[] Pets = (Pet[]) Enum.GetValues(typeof(Pet));
    private static readonly Drink[] Drinks = (Drink[]) Enum.GetValues(typeof(Drink));
    private static readonly Smoke[] Smokes = (Smoke[]) Enum.GetValues(typeof(Smoke));

    private static IEnumerable<T[]> Permutations<T>(this T[] input) => input.Permutations(input.Length);
    private static IEnumerable<T[]> Permutations<T>(this T[] input, int length)
    {
        if (length == 1)
        {
            return input.Select(t => new[] { t });
        }

        return input.Permutations(length - 1)
            .SelectMany(t => input.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new[] { t2 }).ToArray());
    }
    
    private struct Solution
    {
        public Color[] Colors;
        public Nationality[] Nationalities;
        public Pet[] Pets;
        public Drink[] Drinks;
        public Smoke[] Smokes;
    }

    private static bool MatchesColorRules(Color[] colors)
    {
        var greenRightOfIvoryHouse = Array.IndexOf(colors, Color.Ivory) == Array.IndexOf(colors, Color.Green) - 1; // #6
        return greenRightOfIvoryHouse;
    }
    
    private static bool MatchesNationalityRules(Color[] colors, Nationality[] nationalities)
    {
        var englishManInRedHouse = IsIndexMatch(nationalities, Nationality.Englishman, colors, Color.Red); // #2
        var norwegianInFirstHouse = nationalities[0] == Nationality.Norwegian; // #10
        var norwegianLivesNextToBlueHouse = IsAdjacentMatch(nationalities, Nationality.Norwegian, colors, Color.Blue); // #15

        return englishManInRedHouse && norwegianInFirstHouse && norwegianLivesNextToBlueHouse;
    }
    
    private static bool MatchesPetRules(Nationality[] nationalities, Pet[] pets)
    {
        var spaniardOwnsDog = IsIndexMatch(nationalities, Nationality.Spaniard, pets, Pet.Dog); // #3
        return spaniardOwnsDog;
    }

    private static bool MatchesDrinkRules(Color[] colors, Nationality[] nationalities, Drink[] drinks)
    {
        var coffeeDrunkInGreenHouse = IsIndexMatch(colors, Color.Green, drinks, Drink.Coffee); // #4
        var ukranianDrinksTee = IsIndexMatch(nationalities, Nationality.Ukranian, drinks, Drink.Tea); // #5
        var milkDrunkInMiddleHouse = drinks[2] == Drink.Milk; // #9

        return coffeeDrunkInGreenHouse && ukranianDrinksTee && milkDrunkInMiddleHouse;
    }
    
    private static bool MatchesSmokeRules(Color[] colors, Nationality[] nationalities, Drink[] drinks, Pet[] pets, Smoke[] smokes)
    {
        var oldGoldSmokesOwnsSnails = IsIndexMatch(smokes, Smoke.OldGold, pets, Pet.Snails); // #7
        var koolsSmokedInYellowHouse = IsIndexMatch(colors, Color.Yellow, smokes, Smoke.Kools); // #8
        var chesterfieldsSmokedNextToHouseWithFox = IsAdjacentMatch(smokes, Smoke.Chesterfields, pets, Pet.Fox); // #11
        var koolsSmokedNextToHouseWithHorse = IsAdjacentMatch(smokes, Smoke.Kools, pets, Pet.Horse); // #12

        var luckyStrikeSmokerDrinksOrangeJuice = IsIndexMatch(smokes, Smoke.LuckyStrike, drinks, Drink.OrangeJuice); // #13
        var japaneseSmokesParliaments = IsIndexMatch(nationalities, Nationality.Japanese, smokes, Smoke.Parliaments); // #14

        return
            oldGoldSmokesOwnsSnails &&
            koolsSmokedInYellowHouse &&
            chesterfieldsSmokedNextToHouseWithFox &&
            koolsSmokedNextToHouseWithHorse &&
            luckyStrikeSmokerDrinksOrangeJuice &&
            japaneseSmokesParliaments;
    }

    private static IEnumerable<Solution> Solutions() => 
        from validColors in Colors.Permutations().Where(MatchesColorRules)
        from validNationalities in Nationalities.Permutations().Where(nationalities => MatchesNationalityRules(validColors, nationalities))
        from validPets in Pets.Permutations().Where(pets => MatchesPetRules(validNationalities, pets))
        from validDrinks in Drinks.Permutations().Where(drinks => MatchesDrinkRules(validColors, validNationalities, drinks))
        from validSmokes in Smokes.Permutations().Where(smokes => MatchesSmokeRules(validColors, validNationalities, validDrinks, validPets, smokes))
        select new Solution { Colors = validColors, Nationalities = validNationalities, Pets = validPets, Drinks = validDrinks, Smokes = validSmokes };
    
    private static Solution Solve() => Solutions().First();
    
    public static Nationality DrinksWater()
    {
        var solution = Solve();
        return solution.Nationalities[Array.IndexOf(solution.Drinks, Drink.Water)];
    }

    public static Nationality OwnsZebra()
    {
        var solution = Solve();
        return solution.Nationalities[Array.IndexOf(solution.Pets, Pet.Zebra)];
    }

    private static bool IsIndexMatch<T1, T2>(T1[] values1, T1 value1, T2[] values2, T2 value2) => values2[Array.IndexOf(values1, value1)].Equals(value2);

    private static bool IsAdjacentMatch<T1, T2>(T1[] values1, T1 value1, T2[] values2, T2 value2)
    {
        var index = Array.IndexOf(values1, value1);
        return (index > 0 && values2[index - 1].Equals(value2)) || (index < values2.Length - 1 && values2[index + 1].Equals(value2));
    }
}