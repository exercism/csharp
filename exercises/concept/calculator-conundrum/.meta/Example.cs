using System;
static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        int result = 0;
        try
        {
            switch(operation)
            {
                case "+":
                    result = Calculator.Addition(operand1, operand2);
                    break;
                case "*":
                    result = Calculator.Multiplication(operand1, operand2);
                    break;
                case "/":
                    result = Calculator.Division(operand1, operand2);
                    break;
                case "":
                    throw new ArgumentException("Operation cannot be empty.", operation);
                case null:
                    throw new ArgumentNullException(operation, "Operation cannot be null.");
                default:
                    throw new ArgumentOutOfRangeException(operation, $"Operation {operation} does not exist");
            }
        }
        catch(OverflowException)
        {
            return $"The result of operation {operand1} {operation} {operand2} does not fit into integer type.";
        }
        catch(DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }

        return $"{operand1} {operation} {operand2} = {result}";
    }
}

public static class Calculator
{
    public static int Division(int operand1, int operand2)
    {
        return operand1 / operand2;
    }

    public static int Multiplication(int operand1, int operand2)
    {
        checked
        {
            return operand1 * operand2;
        }
    }
    public static int Addition(int operand1, int operand2)
    {
        checked
        {
            return operand1 + operand2;
        }
    }
}