using System;
using System.Linq;
using System.Collections.Generic;
using Sprache;

public class ForthState
{
    public Stack<int> Stack { get; } = new Stack<int>();
    public Dictionary<string, IEnumerable<ForthDefinition>> Mapping { get; } = new Dictionary<string, IEnumerable<ForthDefinition>>();

    public override string ToString() => string.Join(" ", Stack.Reverse());
}

public abstract class ForthDefinition
{
    public abstract void Evaluate(ForthState state);
}

public abstract class TermDefinition : ForthDefinition
{
    public TermDefinition(string term)
    {
        Term = term;
    }

    public string Term { get; }

    public override void Evaluate(ForthState state)
    {
        if (IsUserTerm(state))
            EvaluateUserTerm(state);
        else
            EvaluateDefaultTerm(state);
    }

    private bool IsUserTerm(ForthState state) => state.Mapping.ContainsKey(Term);

    public virtual void EvaluateUserTerm(ForthState state)
    {
        foreach (var definition in state.Mapping[Term])
            definition.Evaluate(state);
    }

    public abstract void EvaluateDefaultTerm(ForthState state);
}

public abstract class UnaryOperation: TermDefinition
{
    public UnaryOperation(string term) : base(term)
    {
    }

    public override void EvaluateDefaultTerm(ForthState state)
    {        
        if (state.Stack.Count < 1)
            throw new InvalidOperationException();

        var operand = state.Stack.Pop();

        foreach (var value in operation(operand))
            state.Stack.Push(value);
    }

    public abstract List<int> operation(int x);
}

public abstract class BinaryOperation : TermDefinition
{
    public BinaryOperation(string term) : base(term)
    {
    }

    public override void EvaluateDefaultTerm(ForthState state)
    {
        if (state.Stack.Count <= 1)
            throw new InvalidOperationException();

        var operand2 = state.Stack.Pop();
        var operand1 = state.Stack.Pop();

        foreach (var value in operation(operand1, operand2))
            state.Stack.Push(value);
    }

    public abstract List<int> operation(int x, int y);
}

public class Constant : ForthDefinition
{
    private readonly int n;

    public Constant(int n)
    {
        this.n = n;
    }

    public override void Evaluate(ForthState state) => state.Stack.Push(n);
}

public class Word : TermDefinition
{
    public Word(string str) : base(str)
    {
    }

    public override void EvaluateDefaultTerm(ForthState state)
    {
        if (!state.Mapping.ContainsKey(Term))
            throw new InvalidOperationException();
    }
}

public class Dup: UnaryOperation
{
    public Dup() : base("dup") {}
    public override List<int> operation(int x) => new List<int> { x, x };
}

public class Drop : UnaryOperation
{
    public Drop() : base("drop") {}
    public override List<int> operation(int x) => new List<int>();
}

public class Swap : BinaryOperation
{
    public Swap() : base("swap") {}
    public override List<int> operation(int x, int y) => new List<int> { y, x };
}

public class Over : BinaryOperation
{
    public Over() : base("over") {}
    public override List<int> operation(int x, int y) => new List<int> { x, y, x };
}

public class Plus : BinaryOperation
{
    public Plus() : base("+") {}
    public override List<int> operation(int x, int y) => new List<int> { x + y };
}

public class Minus : BinaryOperation
{
    public Minus() : base("-") {}
    public override List<int> operation(int x, int y) => new List<int> { x - y };
}

public class Multiply : BinaryOperation
{
    public Multiply() : base("*") {}
    public override List<int> operation(int x, int y) => new List<int> { x * y };
}

public class Division : BinaryOperation
{
    public Division() : base("/") {}

    public override List<int> operation(int x, int y)
    {
        if (y == 0)
            throw new InvalidOperationException();

        return new List<int> { x / y };
    }
}

public class CustomTerm : ForthDefinition
{
    private readonly string term;
    private readonly ForthDefinition[] actions;

    public CustomTerm(string term, IEnumerable<ForthDefinition> actions)
    {
        this.term = term;
        this.actions = actions.ToArray();
    }

    public override void Evaluate(ForthState state)
    {
        if (int.TryParse(term, out _))
            throw new InvalidOperationException();

        var normalizedActions = new List<ForthDefinition>();

        foreach (var action in actions)
        {
            if (action is Word word)
                normalizedActions.AddRange(state.Mapping[word.Term]);
            else
                normalizedActions.Add(action);
        }
        
        state.Mapping[term] = normalizedActions;
    }
}

public static class Forth
{
    public static string Evaluate(string[] instructions)
    {
        var state = new ForthState();

        foreach (var instruction in instructions)
        {
            var expression = Expression.Parse(instruction);

            foreach (var definition in expression)
                definition.Evaluate(state);
        }

        return state.ToString();
    }
    
    private static readonly Parser<Constant> Constant =
        from number in Parse.Number
        from whitespace in Parse.WhiteSpace.Optional()
        select new Constant(int.Parse(number));

    private static readonly Parser<string> TermIdentifier =
        from term in Parse.Regex(@"[^\s;]+")
        from whitespace in Parse.WhiteSpace.Optional()
        select term.ToLowerInvariant();

    private static readonly Parser<ForthDefinition> Term = TermIdentifier.Select<string, ForthDefinition>(term =>
    {
        switch (term)
        {
            case "+": return new Plus();
            case "-": return new Minus();
            case "*": return new Multiply();
            case "/": return new Division();
            case "dup": return new Dup();
            case "drop": return new Drop();
            case "swap": return new Swap();
            case "over": return new Over();
            default: return new Word(term);
        }
    });

    private static readonly Parser<ForthDefinition> CustomTerm =
        from a in Parse.Char(':')
        from b in Parse.WhiteSpace
        from customTerm in TermIdentifier
        from definitions in Constant.XOr(Term).AtLeastOnce()            
        from d in Parse.Char(';')
        from e in Parse.WhiteSpace.Optional()
        select new CustomTerm(customTerm, definitions);

    private static readonly Parser<IEnumerable<ForthDefinition>> Expression =
        (CustomTerm.XOr(Constant).XOr(Term)).Many();
}