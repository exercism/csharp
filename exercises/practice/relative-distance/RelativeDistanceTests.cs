public class RelativeDistanceTests
{
    [Fact]
    public void Direct_parent_child_relation()
    {
        var familyTree = new Dictionary<string, string[]>
        {
            { "Aditi", ["Bao"] },
            { "Bao", ["Carlos"] },
            { "Carlos", ["Dalia"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(3, rd.DegreeOfSeparation("Aditi", "Dalia"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sibling_relationship()
    {
        var familyTree = new Dictionary<string, string[]>
        {
            { "Dalia", ["Olga", "Yassin"] },
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(1, rd.DegreeOfSeparation("Olga", "Yassin"));;
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_degrees_of_separation_grandchild()
    {
        var familyTree = new Dictionary<string, string[]>
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
        var familyTree = new Dictionary<string, string[]>
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
        var familyTree = new Dictionary<string, string[]>
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
    public void Complex_graph_far_removed_nephew()
    {
        var familyTree = new Dictionary<string, string[]>
        {
            { "Mina", ["Viktor", "Wang"] },
            { "Olga", ["Yuki"] },
            { "Javier", ["Quynh", "Ravi"] },
            { "Tariq", ["Farah"] },
            { "Viktor", ["Hana", "Ian"] },
            { "Diego", ["Qi"] },
            { "Carlos", ["Fatima", "Gustavo"] },
            { "Hana", ["Umar"] },
            { "Jing", ["Wyatt"] },
            { "Sven", ["Fabio"] },
            { "Zane", ["Mateo"] },
            { "Isla", ["Pedro"] },
            { "Quynh", ["Boris"] },
            { "Kaito", ["Xia"] },
            { "Liam", ["Tariq", "Uma"] },
            { "Priya", ["Cai"] },
            { "Qi", ["Dimitri"] },
            { "Wang", ["Jing"] },
            { "Yuki", ["Leila"] },
            { "Xia", ["Kim"] },
            { "Pedro", ["Zane", "Aditi"] },
            { "Uma", ["Giorgio"] },
            { "Giorgio", ["Tomoko"] },
            { "Gustavo", ["Mina"] },
            { "Sofia", ["Diego", "Elif"] },
            { "Leila", ["Yassin"] },
            { "Umar", ["Helena"] },
            { "Aiko", ["Bao", "Carlos"] },
            { "Fatima", ["Khadija", "Liam"] },
            { "Oscar", ["Bianca"] },
            { "Wyatt", ["Jun"] },
            { "Ian", ["Vera"] },
            { "Mateo", ["Zara"] },
            { "Noah", ["Xiomara"] },
            { "Celine", ["Priya"] },
            { "Xiomara", ["Kaito"] },
            { "Bao", ["Dalia", "Elias"] },
            { "Elif", ["Rami"] },
            { "Farah", ["Sven"] },
            { "Aditi", ["Nia"] },
            { "Vera", ["Igor"] },
            { "Boris", ["Oscar"] },
            { "Khadija", ["Sofia"] },
            { "Zara", ["Mohammed"] },
            { "Dalia", ["Hassan", "Isla"] },
            { "Ravi", ["Celine"] },
            { "Yassin", ["Lucia"] },
            { "Elias", ["Javier"] },
            { "Nia", ["Antonio"] },
            { "Rami", ["Ewa"] },
            { "Hassan", ["Noah", "Olga"] },
            { "Tomoko", ["Gabriela"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(14, rd.DegreeOfSeparation("Lucia", "Jun"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Complex_graph_cousins_several_times_removed()
    {
        var familyTree = new Dictionary<string, string[]>
        {
            { "Mina", ["Viktor", "Wang"] },
            { "Olga", ["Yuki"] },
            { "Javier", ["Quynh", "Ravi"] },
            { "Tariq", ["Farah"] },
            { "Viktor", ["Hana", "Ian"] },
            { "Diego", ["Qi"] },
            { "Carlos", ["Fatima", "Gustavo"] },
            { "Hana", ["Umar"] },
            { "Jing", ["Wyatt"] },
            { "Sven", ["Fabio"] },
            { "Zane", ["Mateo"] },
            { "Isla", ["Pedro"] },
            { "Quynh", ["Boris"] },
            { "Kaito", ["Xia"] },
            { "Liam", ["Tariq", "Uma"] },
            { "Priya", ["Cai"] },
            { "Qi", ["Dimitri"] },
            { "Wang", ["Jing"] },
            { "Yuki", ["Leila"] },
            { "Xia", ["Kim"] },
            { "Pedro", ["Zane", "Aditi"] },
            { "Uma", ["Giorgio"] },
            { "Giorgio", ["Tomoko"] },
            { "Gustavo", ["Mina"] },
            { "Sofia", ["Diego", "Elif"] },
            { "Leila", ["Yassin"] },
            { "Umar", ["Helena"] },
            { "Aiko", ["Bao", "Carlos"] },
            { "Fatima", ["Khadija", "Liam"] },
            { "Oscar", ["Bianca"] },
            { "Wyatt", ["Jun"] },
            { "Ian", ["Vera"] },
            { "Mateo", ["Zara"] },
            { "Noah", ["Xiomara"] },
            { "Celine", ["Priya"] },
            { "Xiomara", ["Kaito"] },
            { "Bao", ["Dalia"] },
            { "Elif", ["Rami"] },
            { "Farah", ["Sven"] },
            { "Aditi", ["Nia"] },
            { "Vera", ["Igor"] },
            { "Boris", ["Oscar"] },
            { "Khadija", ["Sofia"] },
            { "Zara", ["Mohammed"] },
            { "Dalia", ["Hassan", "Isla"] },
            { "Ravi", ["Celine"] },
            { "Yassin", ["Lucia"] },
            { "Nia", ["Antonio"] },
            { "Rami", ["Ewa"] },
            { "Hassan", ["Noah", "Olga"] },
            { "Tomoko", ["Gabriela"] }
        };
        RelativeDistance rd = new(familyTree);
        Assert.Equal(12, rd.DegreeOfSeparation("Wyatt", "Xia"));
    }
}