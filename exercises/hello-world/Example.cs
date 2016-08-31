public class HelloWorld
{
    public static string Hello(string name)
    {
        return $"Hello, {name ?? "World"}!";
    }
}
