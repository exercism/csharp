using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _list;

    public HighScores(List<int> list) => _list = list;

    public List<int> Scores() => _list;

    public int Latest() => _list.Last();

    public int PersonalBest() => _list.Max();

    public List<int> PersonalTop() => _list.OrderByDescending(score => score).Take(3).ToList();

    public string Report()
    {
        var latestScoreReport = $"Your latest score was {Latest()}.";

        var differenceOfLatestToPersonalBest = PersonalBest() - Latest();
        var latestScoreComparedToPersonalBestReport = 
            differenceOfLatestToPersonalBest == 0
                ? "That's your personal best!"
                : $"That's {differenceOfLatestToPersonalBest} short of your personal best!";

        return $"{latestScoreReport} {latestScoreComparedToPersonalBestReport}";
    }
}