public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe(string[] rows)
{
    public State State
    {
        get
        {   
            if (Moves.GetValueOrDefault('X', 0) - Moves.GetValueOrDefault('O', 0) > 1 ||
                Moves.GetValueOrDefault('O', 0) > Moves.GetValueOrDefault('X', 0) ||
                Winners.Distinct().Count() > 1)
                return State.Invalid;

            if (Winners.Length != 0)
                return State.Win;

            if (Cells.Contains(' '))
                return State.Ongoing;
            
            return State.Draw;
        }
    }
    
    private char[] Winners =>
        rows.Concat(Diagonals).Concat(Columns)
            .Where(cells => cells is "XXX" or "OOO")
            .Select(cells => cells[0])
            .ToArray();

    private string[] Diagonals =>
        [
            $"{rows[0][0]}{rows[1][1]}{rows[2][2]}", 
            $"{rows[0][2]}{rows[1][1]}{rows[2][0]}"
        ];
    
    private string[] Columns =>
        [
            $"{rows[0][0]}{rows[1][0]}{rows[2][0]}",
            $"{rows[0][1]}{rows[1][1]}{rows[2][1]}",
            $"{rows[0][2]}{rows[1][2]}{rows[2][2]}",
        ];

    private char[] Cells => rows.SelectMany(row => row).ToArray();

    private Dictionary<char, int> Moves => 
        Cells.Where(char.IsLetter)
            .CountBy(cell => cell)
            .ToDictionary();
}
