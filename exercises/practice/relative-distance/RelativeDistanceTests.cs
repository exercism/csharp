public class RelativeDistanceTests
{
    [Fact]
    public void Direct_parent_child_relation()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Vera", ["Tomoko"] },
            { "Tomoko", ["Aditi"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(1, rd.DegreeOfSeparation("Vera", "Tomoko"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sibling_relationship()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Dalia", ["Olga", "Yassin"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(1, rd.DegreeOfSeparation("Olga", "Yassin"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_degrees_of_separation_grandchild()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Khadija", ["Mateo"] },
            { "Mateo", ["Rami"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(2, rd.DegreeOfSeparation("Khadija", "Rami"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unrelated_individuals()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Priya", ["Rami"] },
            { "Kaito", ["Elif"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(-1, rd.DegreeOfSeparation("Priya", "Kaito"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Complex_graph_cousins()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Aiko", ["Bao", "Carlos"] },
            { "Bao", ["Dalia", "Elias"] },
            { "Carlos", ["Fatima", "Gustavo"] },
            { "Dalia", ["Hassan", "Isla"] },
            { "Elias", ["Javier"] },
            { "Fatima", ["Khadija", "Liam"] },
            { "Gustavo", ["Mina"] },
            { "Hassan", ["Noah", "Olga"] },
            { "Isla", ["Pedro"] },
            { "Javier", ["Quynh", "Ravi"] },
            { "Khadija", ["Sofia"] },
            { "Liam", ["Tariq", "Uma"] },
            { "Mina", ["Viktor", "Wang"] },
            { "Noah", ["Xiomara"] },
            { "Olga", ["Yuki"] },
            { "Pedro", ["Zane", "Aditi"] },
            { "Quynh", ["Boris"] },
            { "Ravi", ["Celine"] },
            { "Sofia", ["Diego", "Elif"] },
            { "Tariq", ["Farah"] },
            { "Uma", ["Giorgio"] },
            { "Viktor", ["Hana", "Ian"] },
            { "Wang", ["Jing"] },
            { "Xiomara", ["Kaito"] },
            { "Yuki", ["Leila"] },
            { "Zane", ["Mateo"] },
            { "Aditi", ["Nia"] },
            { "Boris", ["Oscar"] },
            { "Celine", ["Priya"] },
            { "Diego", ["Qi"] },
            { "Elif", ["Rami"] },
            { "Farah", ["Sven"] },
            { "Giorgio", ["Tomoko"] },
            { "Hana", ["Umar"] },
            { "Ian", ["Vera"] },
            { "Jing", ["Wyatt"] },
            { "Kaito", ["Xia"] },
            { "Leila", ["Yassin"] },
            { "Mateo", ["Zara"] },
            { "Nia", ["Antonio"] },
            { "Oscar", ["Bianca"] },
            { "Priya", ["Cai"] },
            { "Qi", ["Dimitri"] },
            { "Rami", ["Ewa"] },
            { "Sven", ["Fabio"] },
            { "Tomoko", ["Gabriela"] },
            { "Umar", ["Helena"] },
            { "Vera", ["Igor"] },
            { "Wyatt", ["Jun"] },
            { "Xia", ["Kim"] },
            { "Yassin", ["Lucia"] },
            { "Zara", ["Mohammed"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(9, rd.DegreeOfSeparation("Dimitri", "Fabio"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Complex_graph_no_shortcut_far_removed_nephew()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Aiko", ["Bao", "Carlos"] },
            { "Bao", ["Dalia", "Elias"] },
            { "Carlos", ["Fatima", "Gustavo"] },
            { "Dalia", ["Hassan", "Isla"] },
            { "Elias", ["Javier"] },
            { "Fatima", ["Khadija", "Liam"] },
            { "Gustavo", ["Mina"] },
            { "Hassan", ["Noah", "Olga"] },
            { "Isla", ["Pedro"] },
            { "Javier", ["Quynh", "Ravi"] },
            { "Khadija", ["Sofia"] },
            { "Liam", ["Tariq", "Uma"] },
            { "Mina", ["Viktor", "Wang"] },
            { "Noah", ["Xiomara"] },
            { "Olga", ["Yuki"] },
            { "Pedro", ["Zane", "Aditi"] },
            { "Quynh", ["Boris"] },
            { "Ravi", ["Celine"] },
            { "Sofia", ["Diego", "Elif"] },
            { "Tariq", ["Farah"] },
            { "Uma", ["Giorgio"] },
            { "Viktor", ["Hana", "Ian"] },
            { "Wang", ["Jing"] },
            { "Xiomara", ["Kaito"] },
            { "Yuki", ["Leila"] },
            { "Zane", ["Mateo"] },
            { "Aditi", ["Nia"] },
            { "Boris", ["Oscar"] },
            { "Celine", ["Priya"] },
            { "Diego", ["Qi"] },
            { "Elif", ["Rami"] },
            { "Farah", ["Sven"] },
            { "Giorgio", ["Tomoko"] },
            { "Hana", ["Umar"] },
            { "Ian", ["Vera"] },
            { "Jing", ["Wyatt"] },
            { "Kaito", ["Xia"] },
            { "Leila", ["Yassin"] },
            { "Mateo", ["Zara"] },
            { "Nia", ["Antonio"] },
            { "Oscar", ["Bianca"] },
            { "Priya", ["Cai"] },
            { "Qi", ["Dimitri"] },
            { "Rami", ["Ewa"] },
            { "Sven", ["Fabio"] },
            { "Tomoko", ["Gabriela"] },
            { "Umar", ["Helena"] },
            { "Vera", ["Igor"] },
            { "Wyatt", ["Jun"] },
            { "Xia", ["Kim"] },
            { "Yassin", ["Lucia"] },
            { "Zara", ["Mohammed"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(14, rd.DegreeOfSeparation("Lucia", "Jun"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Complex_graph_some_shortcuts_cross_down_and_cross_up_cousins_several_times_removed_with_unrelated_family_tree()
    {
        Dictionary<string, string[]> familyTree = new()
        {
            { "Aiko", ["Bao", "Carlos"] },
            { "Bao", ["Dalia"] },
            { "Carlos", ["Fatima", "Gustavo"] },
            { "Dalia", ["Hassan", "Isla"] },
            { "Fatima", ["Khadija", "Liam"] },
            { "Gustavo", ["Mina"] },
            { "Hassan", ["Noah", "Olga"] },
            { "Isla", ["Pedro"] },
            { "Javier", ["Quynh", "Ravi"] },
            { "Khadija", ["Sofia"] },
            { "Liam", ["Tariq", "Uma"] },
            { "Mina", ["Viktor", "Wang"] },
            { "Noah", ["Xiomara"] },
            { "Olga", ["Yuki"] },
            { "Pedro", ["Zane", "Aditi"] },
            { "Quynh", ["Boris"] },
            { "Ravi", ["Celine"] },
            { "Sofia", ["Diego", "Elif"] },
            { "Tariq", ["Farah"] },
            { "Uma", ["Giorgio"] },
            { "Viktor", ["Hana", "Ian"] },
            { "Wang", ["Jing"] },
            { "Xiomara", ["Kaito"] },
            { "Yuki", ["Leila"] },
            { "Zane", ["Mateo"] },
            { "Aditi", ["Nia"] },
            { "Boris", ["Oscar"] },
            { "Celine", ["Priya"] },
            { "Diego", ["Qi"] },
            { "Elif", ["Rami"] },
            { "Farah", ["Sven"] },
            { "Giorgio", ["Tomoko"] },
            { "Hana", ["Umar"] },
            { "Ian", ["Vera"] },
            { "Jing", ["Wyatt"] },
            { "Kaito", ["Xia"] },
            { "Leila", ["Yassin"] },
            { "Mateo", ["Zara"] },
            { "Nia", ["Antonio"] },
            { "Oscar", ["Bianca"] },
            { "Priya", ["Cai"] },
            { "Qi", ["Dimitri"] },
            { "Rami", ["Ewa"] },
            { "Sven", ["Fabio"] },
            { "Tomoko", ["Gabriela"] },
            { "Umar", ["Helena"] },
            { "Vera", ["Igor"] },
            { "Wyatt", ["Jun"] },
            { "Xia", ["Kim"] },
            { "Yassin", ["Lucia"] },
            { "Zara", ["Mohammed"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(12, rd.DegreeOfSeparation("Wyatt", "Xia"));
    }
}
