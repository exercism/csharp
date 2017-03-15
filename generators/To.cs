namespace Generators
{
    public static class To
    {
        public static readonly TestClassNameTransformer TestClassName = new TestClassNameTransformer();
        public static readonly TestMethodNameTransformer TestMethodName = new TestMethodNameTransformer();
    }
}