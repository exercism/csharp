public class RelativeDistance
{
    private readonly Dictionary<string, HashSet<string>> relatives;
    
    public RelativeDistance(Dictionary<string, List<string>> familyTree)
    {
        Dictionary<string, HashSet<string>>  parsed = new();
        foreach (var (parent, children) in familyTree)
        {
            var parentConnections = parsed.GetValueOrDefault(parent, []);
            foreach (string child in children)
            {
                parentConnections.Add(child);
                var childConnections = parsed.GetValueOrDefault(child, [])
                    .Union(children.Where(sibling => sibling != child)).ToHashSet();
                childConnections.Add(parent);
                parsed[child] = childConnections;
            }
            
            parsed[parent] = parentConnections;
        }
        relatives = parsed;
    }
    
    public int DegreeOfSeparation(string personA, string personB)
    {
        if (!relatives.ContainsKey(personA) || !relatives.ContainsKey(personB))
        {
            return -1;
        }
        
        Queue<(string Person, int Degree)> queue = new();
        queue.Enqueue((personA, 0));
        HashSet<string> visited = [personA];
        
        while (queue.Count > 0)
        {
            var (currentPerson, degree) = queue.Dequeue();

            if (currentPerson == personB)
            {
                return degree;
            }
            
            var unvisited = relatives[currentPerson].Except(visited).ToHashSet();
            foreach (string neighbor in unvisited)
            {
                queue.Enqueue((neighbor, degree + 1));
            }
            visited.UnionWith(unvisited);
        }
        
        return -1;
    }
}
