public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    public Allergies(int mask)
    {
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public Allergen[] List()
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}