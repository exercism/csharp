using System.Collections.Generic;

public class BowlingGame
{
    private const int NumberOfFrames = 10;
    private const int MaximumFrameScore = 10;

    private readonly List<int> rolls = new List<int>();

    public void Roll(int pins) => rolls.Add(pins);

    public int Score()
    {
        var score = 0;
        var frameIndex = 0;

        for (int i = 0; i < NumberOfFrames; i++)
        {
            if (IsStrike(frameIndex))
            {
                score += 10 + StrikeBonus(frameIndex);
                frameIndex += 1;
            }
            else if (IsSpare(frameIndex))
            {
                score += 10 + SpareBonus(frameIndex);
                frameIndex += 2;
            }
            else
            {
                score += SumOfPinsInFrame(frameIndex);
                frameIndex += 2;
            }
        }

        return score;
    }

    private bool IsStrike(int frameIndex) => rolls[frameIndex] == MaximumFrameScore;
    private bool IsSpare(int frameIndex) => rolls[frameIndex] + rolls[frameIndex + 1] == MaximumFrameScore;

    private int StrikeBonus(int frameIndex) => rolls[frameIndex + 1] + rolls[frameIndex + 2];
    private int SpareBonus(int frameIndex) => rolls[frameIndex + 2];

    private int SumOfPinsInFrame(int frameIndex) => rolls[frameIndex] + rolls[frameIndex + 1];
}