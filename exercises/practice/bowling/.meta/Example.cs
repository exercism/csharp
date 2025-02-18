using System.Collections.Generic;
using System;

public class BowlingGame
{
    private const int NumberOfFrames = 10;
    private const int MaximumFrameScore = 10;

    private readonly List<int> rolls = new List<int>();

    public void Roll(int pins)
    {
        if (!ValidInput(pins))
            throw new ArgumentException();

        rolls.Add(pins);
    }

    public int? Score()
    {
        var score = 0;
        var frameIndex = 0;

        if (rolls.Count < 12 || rolls.Count > 21)
            throw new ArgumentException();

        for (var i = 1; i <= NumberOfFrames; i++)
        {
            if (rolls.Count <= frameIndex)
            {
                throw new ArgumentException();
            }

            if (IsStrike(frameIndex))
            {
                if (rolls.Count <= frameIndex + 2)
                {
                    throw new ArgumentException();
                }

                var strikeBonus = StrikeBonus(frameIndex);
                if ((strikeBonus > MaximumFrameScore && !IsStrike(frameIndex + 1)) || strikeBonus > 20)
                {
                    throw new ArgumentException();
                }

                score += 10 + strikeBonus;
                frameIndex += i == NumberOfFrames ? 3 : 1;
            }
            else if (IsSpare(frameIndex))
            {
                if (rolls.Count <= frameIndex + 2)
                {
                    throw new ArgumentException();
                }

                score += 10 + SpareBonus(frameIndex);
                frameIndex += i == NumberOfFrames ? 3 : 2;
            }
            else
            {
                var frameScore = FrameScore(frameIndex);
                if (frameScore < 0 || frameScore > 10)
                {
                    throw new ArgumentException();
                }

                score += frameScore;
                frameIndex += 2;
            }
        }

        return CorrectNumberOfRolls(frameIndex) ? score : (int?)null;
    }

    private bool CorrectNumberOfRolls(int frameIndex) => frameIndex == rolls.Count;

    private bool IsStrike(int frameIndex) => rolls[frameIndex] == MaximumFrameScore;
    private bool IsSpare(int frameIndex) => rolls[frameIndex] + rolls[frameIndex + 1] == MaximumFrameScore;

    private int StrikeBonus(int frameIndex) => rolls[frameIndex + 1] + rolls[frameIndex + 2];
    private int SpareBonus(int frameIndex) => rolls[frameIndex + 2];

    private int FrameScore(int frameIndex) => rolls[frameIndex] + rolls[frameIndex + 1];

    private bool ValidInput(int pins)
    {
        if (rolls.Count >= 21 || pins < 0 || pins > 10 ||
            rolls.Count + 1 % 2 == 0 && rolls[rolls.Count - 1] + pins > 10)
        {
            return false;
        }

        if ((rolls.Count + 1) % 2 == 0 && rolls[rolls.Count - 1] != 10 && rolls[rolls.Count - 1] + pins > 10)
        {
            return false;
        }

        if (rolls.Count == 20)
        {
            if (rolls[18] != 10 && rolls[18] + rolls[19] != 10)
                return false;

            if (pins == 10 && (rolls[18] != 10 || rolls[19] != 10 || rolls[19] + pins > 10 && rolls[19] + pins != 20) &&
                rolls[18] + rolls[19] != 10)
                return false;

            if (pins != 10 && rolls[19] + pins > 10 && rolls[19] != 10)
                return false;
        }

        return true;
    }
}