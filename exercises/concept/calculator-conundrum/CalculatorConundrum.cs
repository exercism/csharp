using System;
static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        throw new NotImplementedException();
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