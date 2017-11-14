namespace Generators
{
    public sealed class MissingDataExercise : Exercise
    {
        public MissingDataExercise(string name) => Name = name;

        public override string Name { get; }
    }
}