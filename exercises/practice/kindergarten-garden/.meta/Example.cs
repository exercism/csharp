using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private const int PlantsPerChildPerRow = 2;
    private const char RowSeparator = '\n';

    private static readonly string[] DefaultChildren =
    {
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry"
    };

    private static readonly IDictionary<char, Plant> PlantCodesToPlants = new Dictionary<char, Plant>
    {
        { 'V', Plant.Violets },
        { 'R', Plant.Radishes },
        { 'C', Plant.Clover },
        { 'G', Plant.Grass }
    };

    private readonly IDictionary<string, IEnumerable<Plant>> plantsByChild;

    public KindergartenGarden(string diagram) : this(diagram, DefaultChildren)
    {
    }

    public KindergartenGarden(string diagram, IEnumerable<string> students)
    {
        var plantsPerChild = PlantsPerChild(diagram);
        plantsByChild = students.OrderBy(c => c)
                                .Zip(plantsPerChild, Tuple.Create)
                                .ToDictionary(kv => kv.Item1, kv => kv.Item2);
    }

    public IEnumerable<Plant> Plants(string child)
    {
        return plantsByChild.ContainsKey(child) ? plantsByChild[child] : Enumerable.Empty<Plant>();
    }

    private static Plant PlantFromCode(char code)
    {
        return PlantCodesToPlants[code];
    }

    private static IEnumerable<IEnumerable<Plant>> PlantsPerChild(string windowSills)
    {
        var row = windowSills.Split(RowSeparator).Select(PlantsInRow).ToArray();
        return row[0].Zip(row[1], (row1Plants, row2Plants) => row1Plants.Concat(row2Plants));
    }

    private static IEnumerable<IEnumerable<Plant>> PlantsInRow(string row)
    {
        return Partition(row.Select(PlantFromCode), PlantsPerChildPerRow);
    }

    private static IEnumerable<IEnumerable<T>> Partition<T>(IEnumerable<T> input, int partitionSize)
    {
        return input.Select((item, inx) => new { item, inx })
                    .GroupBy(x => x.inx / partitionSize)
                    .Select(g => g.Select(x => x.item));
    }
}