using System;
using System.Collections.Generic;
using System.Linq;

public static class Camicia
{
    public enum GameStatus
    {
        Finished,
        Loop
    }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        Func<string, int> GetValue = (string card) => card switch
        {
            "J" => 1,
            "Q" => 2,
            "K" => 3,
            "A" => 4,
            _ => 0
        };
        Queue<int> handA = new(playerA.Select(GetValue));
        Queue<int> handB = new(playerB.Select(GetValue));
        var turn = "A";
        List<int> pile = new();
        HashSet<string> seen = new();
        int totalTricks = 0;
        int cardsPlayed = 0;
        int currentDebt = 0;

        while (true)
        {
            if (pile.Count == 0)
            {
                var state = $"{string.Join(",", handA)}|{string.Join(",", handB)}|{turn}";
                if (seen.Contains(state))
                {
                    return new GameResult(GameStatus.Loop, totalTricks, cardsPlayed);
                }
                seen.Add(state);
            }

            var activeHand = turn == "A" ? handA : handB;
            var otherHand = turn == "A" ? handB : handA;

            if (activeHand.Count == 0)
            {
                int extraTrick = pile.Count > 0 ? 1 : 0;
                return new GameResult(GameStatus.Finished, totalTricks + extraTrick, cardsPlayed);
            }

            int cardVal = activeHand.Dequeue();
            pile.Add(cardVal);
            cardsPlayed++;

            if (cardVal > 0)
            {
                currentDebt = cardVal;
                turn = turn == "A" ? "B" : "A";
            }
            else
            {
                if (currentDebt > 0)
                {
                    currentDebt--;
                    if (currentDebt == 0)
                    {
                        foreach (int card in pile)
                        {
                            otherHand.Enqueue(card);
                        }
                        pile.Clear();
                        totalTricks++;
                        currentDebt = 0;

                        if (handA.Count == 0 || handB.Count == 0)
                        {
                            return new GameResult(GameStatus.Finished, totalTricks, cardsPlayed);
                        }

                        turn = turn == "A" ? "B" : "A";
                    }
                }
                else
                {
                    turn = turn == "A" ? "B" : "A";
                }
            }
        }
    }
}
