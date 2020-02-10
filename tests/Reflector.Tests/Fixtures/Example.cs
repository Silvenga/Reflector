namespace Reflector.Tests.Fixtures
{
    public class Example
    {
        public string Field;

        public string Property { get; set; }

        public void Method()
        {
        }

        public string MethodWithReturn()
        {
            return "value";
        }

        public void MethodWithArguments(string input1, string input2)
        {
        }
    }
}