{{ func assertions(node, path)
    id = node.id ?? node.recordId
    children = node.children ?? []

    assertion = children.empty? ? $"AssertTreeIsLeaf({path}, id: {id});" : $"AssertTreeIsBranch({path}, id: {id}, childCount: {children | array.size});"
    checks = [assertion]

    for child in children
        checks = array.add_range checks (assertions child $"{path}.Children[{for.index}]")
    end

    ret checks
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.input.records.empty? }}
        var records = Array.Empty<TreeBuildingRecord>();
        {{- else }}
        var records = new[]
        {
            {{- for record in test.input.records }}
            new TreeBuildingRecord { RecordId = {{ record.recordId }}, ParentId = {{ record.parentId }} }{{ if !for.last }},{{ end }}
            {{- end }}
        };
        {{- end }}

        {{- if test.expected.error || test.expected.empty? }}
        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
        {{- else }}
        var tree = TreeBuilder.BuildTree(records);

        {{ test.expected.node | assertions "tree" | array.join "\n" }}
        {{- end }}
    }
    {{ end }}
    private static void AssertTreeIsBranch(Tree tree, int id, int childCount)
    {
        Assert.Equal(id, tree.Id);
        Assert.False(tree.IsLeaf);
        Assert.Equal(childCount, tree.Children.Count);
    }

    private static void AssertTreeIsLeaf(Tree tree, int id)
    {
        Assert.Equal(id, tree.Id);
        Assert.True(tree.IsLeaf);
    }
}
