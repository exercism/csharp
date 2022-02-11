using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var element in input)
        {
            var enumerable = element as IEnumerable;
            if (enumerable != null)
            {
                foreach (var flattenedElement in Flatten(enumerable))
                {
                    yield return flattenedElement;
                }
            }
            else if (element != null)
            {
                yield return element;
            }
        }
    }
}