using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    private const int RootRecordId = 0;

    public int ParentId { get; set; }
    public int RecordId { get; set; }

    public bool IsRoot => RecordId == RootRecordId;
}

public class Tree
{
    public Tree(int id)
    {
        Id = id;
        Children = new List<Tree>();
    }

    public int Id { get; }

    public List<Tree> Children { get; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    private const int RootRecordId = 0;

    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var orderedRecords = GetOrderedRecords(records);

        if (orderedRecords.Count == 0)
            throw new ArgumentException();

        var nodes = new Dictionary<int, Tree>();
        var previousRecordId = -1;

        foreach (var record in orderedRecords)
        {
            ValidateRecord(record, previousRecordId);

            nodes[record.RecordId] = new Tree(record.RecordId);

            if (!record.IsRoot)
                nodes[record.ParentId].Children.Add(nodes[record.RecordId]);

            previousRecordId++;
        }

        return nodes[RootRecordId];
    }

    private static void ValidateRecord(TreeBuildingRecord record, int previousRecordId)
    {
        if (record.IsRoot && record.ParentId != RootRecordId)
            throw new ArgumentException();
        else if (!record.IsRoot && record.ParentId >= record.RecordId)
            throw new ArgumentException();
        else if (!record.IsRoot && record.RecordId != previousRecordId + 1)
            throw new ArgumentException();
    }

    private static List<TreeBuildingRecord> GetOrderedRecords(IEnumerable<TreeBuildingRecord> records)
    {
        return records.OrderBy(record => record.RecordId).ToList();
    }
}