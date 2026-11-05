public enum Color { Red , Green , Ivory , Yellow , Blue }
public enum Nationality { Englishman , Spaniard , Ukrainian , Japanese , Norwegian }
public enum Pet { Dog , Snails , Fox , Horse , Zebra }
public enum Drink { Coffee , Tea , Milk , OrangeJuice , Water }
public enum Hobby { Dancing , Painting , Reading , Football , Chess }

public static class ZebraPuzzle
{
    private static readonly Color[] Colors = (Color[]) Enum.GetValues(typeof(Color));
    private static readonly Nationality[] Nationalities = (Nationality[]) Enum.GetValues(typeof(Nationality));
    private static readonly Pet[] Pets = (Pet[]) Enum.GetValues(typeof(Pet));
    private static readonly Drink[] Drinks = (Drink[]) Enum.GetValues(typeof(Drink));
    private static readonly Hobby[] Hobbies = (Hobby[]) Enum.GetValues(typeof(Hobby));

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
        public Hobby[] Hobbies;
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
        var ukrainianDrinksTea = IsIndexMatch(nationalities, Nationality.Ukrainian, drinks, Drink.Tea); // #5
        var milkDrunkInMiddleHouse = drinks[2] == Drink.Milk; // #9

        return coffeeDrunkInGreenHouse && ukrainianDrinksTea && milkDrunkInMiddleHouse;
    }
    
    private static bool MatchesHobbyRules(Color[] colors, Nationality[] nationalities, Drink[] drinks, Pet[] pets, Hobby[] hobbies)
    {
        var dancerOwnsSnails = IsIndexMatch(hobbies, Hobby.Dancing, pets, Pet.Snails); // #7
        var painterInYellowHouse = IsIndexMatch(colors, Color.Yellow, hobbies, Hobby.Painting); // #8
        var readerNextToHouseWithFox = IsAdjacentMatch(hobbies, Hobby.Reading, pets, Pet.Fox); // #11
        var painterNextToHouseWithHorse = IsAdjacentMatch(hobbies, Hobby.Painting, pets, Pet.Horse); // #12

        var footballerDrinksOrangeJuice = IsIndexMatch(hobbies, Hobby.Football, drinks, Drink.OrangeJuice); // #13
        var japanesePlaysChess = IsIndexMatch(nationalities, Nationality.Japanese, hobbies, Hobby.Chess); // #14

        return
            dancerOwnsSnails &&
            painterInYellowHouse &&
            readerNextToHouseWithFox &&
            painterNextToHouseWithHorse &&
            footballerDrinksOrangeJuice &&
            japanesePlaysChess;
    }

    private static IEnumerable<Solution> Solutions() => 
        from validColors in Colors.Permutations().Where(MatchesColorRules)
        from validNationalities in Nationalities.Permutations().Where(nationalities => MatchesNationalityRules(validColors, nationalities))
        from validPets in Pets.Permutations().Where(pets => MatchesPetRules(validNationalities, pets))
        from validDrinks in Drinks.Permutations().Where(drinks => MatchesDrinkRules(validColors, validNationalities, drinks))
        from validHobbies in Hobbies.Permutations().Where(hobbies => MatchesHobbyRules(validColors, validNationalities, validDrinks, validPets, hobbies))
        select new Solution { Colors = validColors, Nationalities = validNationalities, Pets = validPets, Drinks = validDrinks, Hobbies = validHobbies };
    
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

    private static bool IsIndexMatch<T1, T2>(T1[] values1, T1 value1, T2[] values2, T2 value2) => values2[Array.IndexOf(values1, value1)]!.Equals(value2);

    private static bool IsAdjacentMatch<T1, T2>(T1[] values1, T1 value1, T2[] values2, T2 value2)
    {
        var index = Array.IndexOf(values1, value1);
        return (index > 0 && values2[index - 1]!.Equals(value2)) || (index < values2.Length - 1 && values2[index + 1]!.Equals(value2));
    }
}