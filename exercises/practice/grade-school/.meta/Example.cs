using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly SortedDictionary<int, List<string>> _roster = new();
    
    public bool Add(string student, int grade)
    {
        if (_roster.Values.Any(students => students.Contains(student)))
            return false;

        if (!_roster.TryAdd(grade, new List<string> { student }))
        {
            _roster[grade].Add(student);
            _roster[grade].Sort();
        }

        return true;
    }

    public IEnumerable<string> Roster() => _roster.Values.SelectMany(grade => grade).ToList();

    public IEnumerable<string> Grade(int grade) => _roster.TryGetValue(grade, out var students) ? students : new List<string>();
}