using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Tournament tally system.
/// </summary>
public class Tournament
{
    enum Outcome
    {
        LOSS,
        DRAW,
        WIN
    }
    
    class TeamResult
    {
        internal uint Losses;
        internal uint Draws;
        internal uint Wins;
        
        internal uint Played {
            get {
                return Losses + Draws + Wins;
            }
        }
        
        internal uint Score {
            get {
                return Wins * 3 + Draws;
            }
        }
        
        internal void AddOutcome(Outcome outcome)
        {
            switch (outcome) {
                case Outcome.LOSS:
                    Losses++;
                    break;
                case Outcome.DRAW:
                    Draws++;
                    break;
                case Outcome.WIN:
                    Wins++;
                    break;
            }
        }
    }
    
    private Dictionary<string, TeamResult> teams;
    
    private Tournament()
    {
        teams = new Dictionary<string, TeamResult>();
    }
    
    private void AddResult(string team1, string team2, Outcome outcome)
    {
        // Invert outcome for the second team.
        Outcome outcome2 =
            outcome == Outcome.WIN ? Outcome.LOSS :
            outcome == Outcome.LOSS ? Outcome.WIN :
            Outcome.DRAW;
        AddTeamOutcome(team1, outcome);
        AddTeamOutcome(team2, outcome2);
    }
    
    private void AddTeamOutcome(string team, Outcome outcome)
    {
        TeamResult teamResult;
        if (this.teams.TryGetValue(team, out teamResult)) {
            teamResult.AddOutcome(outcome);
        } else {
            teamResult = new TeamResult();
            teamResult.AddOutcome(outcome);
            this.teams.Add(team, teamResult);
        }
    }
    
    private void WriteResults(TextWriter writer)
    {
        writer.WriteLine(
            "{0,-30:S} | {1,2:D} | {2,2:D} | {3,2:D} | {4,2:D} | {5,2:D}",
            "Team", "MP", "W", "D", "L", "P");
        foreach (var pair in this.teams.OrderByDescending(pair => pair.Value.Score)) {
            writer.WriteLine(
                "{0,-30:S} | {1,2:D} | {2,2:D} | {3,2:D} | {4,2:D} | {5,2:D}",
                pair.Key, pair.Value.Played, pair.Value.Wins,
                pair.Value.Draws, pair.Value.Losses, pair.Value.Score);
        }
        writer.Flush();
    }
    
    public static void Tally(Stream inStream, Stream outStream)
    {
        var tournament = new Tournament();
        var encoding = new System.Text.UTF8Encoding();
        var inReader = new StreamReader(inStream, encoding);
        
        for (var line = inReader.ReadLine(); line != null;
             line = inReader.ReadLine()) {
            var parts = line.Trim().Split(';');
            if (parts.Length != 3)
                continue;
            Outcome outcome;
            switch (parts[2].ToLower()) {
                case "loss":
                    outcome = Outcome.LOSS;
                    break;
                case "draw":
                    outcome = Outcome.DRAW;
                    break;
                case "win":
                    outcome = Outcome.WIN;
                    break;
                default:
                    continue;
            }
            tournament.AddResult(parts[0], parts[1], outcome);
        }
        
        var outWriter = new StreamWriter(outStream, encoding);
        tournament.WriteResults(outWriter);        
    }
}
