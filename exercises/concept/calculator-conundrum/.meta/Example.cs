using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int result;
        try
        {
            switch (operation)
            {
                case "+":
                    result = SimpleOperation.Addition(operand1, operand2);
                    break;
                case "*":
                    result = SimpleOperation.Multiplication(operand1, operand2);
                    break;
                case "/":
                    result = SimpleOperation.Division(operand1, operand2);
                    break;
                case "":
                    throw new ArgumentException("Operation cannot be empty.", "operation");
                case null:
                    throw new ArgumentNullException("operation", "Operation cannot be null.");
                default:
                    throw new ArgumentOutOfRangeException("operation", $"Operation {operation} does not exist.");
            }
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }

        return $"{operand1} {operation} {operand2} = {result}";
    }
}

/**** Please do not modify the code below ****/
public static class SimpleOperation
{
    public static int Division(int operand1, int operand2)
    {
        return operand1 / operand2;
    }

    public static int Multiplication(int operand1, int operand2)
    {
        return operand1 * operand2;
    }
    public static int Addition(int operand1, int operand2)
    {
        return operand1 + operand2;
    }
}
