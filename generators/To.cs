namespace Generators
{
    public static class To
    {
        public static readonly TestedClassNameTransformer TestedClassName = new TestedClassNameTransformer();
        public static readonly TestClassNameTransformer TestClassName = new TestClassNameTransformer();
        public static readonly TestedMethodNameTransformer TestedMethodName = new TestedMethodNameTransformer();
        public static readonly TestMethodNameTransformer TestMethodName = new TestMethodNameTransformer();
    }
}