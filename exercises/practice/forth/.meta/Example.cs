using System;
using System.Collections.Generic;
using System.Linq;

public static class Forth
{
    private static Dictionary<string, string[]> defines = new Dictionary<string, string[]>();
    public static string Evaluate(string[] instructions)
    {
        if (!instructions.Any())
            return string.Empty;
        var input = new Stack<string>(string.Join(" ", instructions).ToUpper()
            .Split(" ").Reverse());
        var output = new Stack<int>();
        defines = new Dictionary<string, string[]>();
        while (input.Any())
        {
            switch (input.Pop())
            {
                case var st when int.TryParse(st, out int number):
                    output.Push(number);
                    break;
                case var st when defines.ContainsKey(st):
                    foreach (var define in defines[st].Reverse())
                        input.Push(define);
                    break;
                case "+":
                    output.Push(Add(output.Pop(), output.Pop()));
                    break;
                case "-":
                    output.Push(Sub(output.Pop(), output.Pop()));
                    break;
                case "*":
                    output.Push(Mul(output.Pop(), output.Pop()));
                    break;
                case "/":
                    output.Push(Div(output.Pop(), output.Pop()));
                    break;
                case "DUP":
                    output.Push(output.Peek());
                    break;
                case "DROP":
                    output.Pop();
                    break;
                case "SWAP":
                    foreach (var item in new[] { output.Pop(), output.Pop() })
                        output.Push(item);
                    break;
                case "OVER":
                    foreach (var item in new[] { output.Pop(), output.Peek() })
                        output.Push(item);
                    break;
                case ":":
                    Define(ref input);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        return string.Join(" ", output.Reverse());
    }
    private static int Add(int x, int y)
        => y + x;
    private static int Sub(int x, int y)
        => y - x;
    private static int Mul(int x, int y)
        => y * x;
    private static int Div(int x, int y)
        => x == 0 ?
            throw new DivideByZeroException()
            : y / x;
    private static void Define(ref Stack<string> input)
    {
        var key = input.Pop();
        if (int.TryParse(key, out int num))
            throw new InvalidOperationException();
        var values = new List<string>();
        var value = input.Pop();
        while (!value.Equals(";"))
        {
            values.Add(value);
            value = input.Pop();
        }
        defines[key] = values.SelectMany(k => defines.ContainsKey(k) ? defines[k] : new[] { k }).ToArray();
    }
}