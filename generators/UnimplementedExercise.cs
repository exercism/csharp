namespace Generators
{
    public sealed class UnimplementedExercise : Exercise
    {
        public UnimplementedExercise(string name) => Name = name;

        public override string Name { get; }
    }
}
