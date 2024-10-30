namespace MyClassesTest;

[TestClass]
public class AssemblyInitCleanup
{
    [AssemblyInitialize()]
    public static void AssemblyInitialize(TestContext tc)
    {
        // This code runs once before all tests in this assembly
        tc.WriteLine("In MyClassesTest.AssemblyInitCleanup.AssemblyInitialize() method");
    }

    [AssemblyCleanup()]
    public static void AssemblyCleanup()
    {
        // This code runs once after all tests have run in this assembly
        // NOTE: TestContext is not available in here
    }
}
