namespace MyClassesTest;

[TestClass]
public class AssertEqualityTest
{
    [TestMethod]
    public void AreNumbersEqualTest()
    {
        int value1 = 42;
        int value2 = 42;

        Assert.AreEqual(value1, value2);
    }

    [TestMethod]
    public void AreNumbersNotEqualTest()
    {
        object value1 = 42L;
        object value2 = 42;

        Assert.AreNotEqual(value1, value2);
    }

    [TestMethod]
    public void AreStringsEqualTest()
    {
        string value1 = "Paul";
        string value2 = "Paul";

        Assert.AreEqual(value1, value2);
    }

    [TestMethod]
    public void AreStringsEqualCaseInsensitiveTest()
    {
        string value1 = "Paul";
        string value2 = "paul";

        Assert.AreEqual(value1, value2, true);
    }

    [TestMethod]
    public void AreStringsNotEqualTest()
    {
        string value1 = "Paul";
        string value2 = "John";

        Assert.AreNotEqual(value1, value2);
    }
}
