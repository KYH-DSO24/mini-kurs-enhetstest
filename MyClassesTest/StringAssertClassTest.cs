using System.Text.RegularExpressions;

using MyClasses;

namespace MyClassesTest;

[TestClass]
public class StringAssertClassTest
{
    [TestMethod]
    public void ContainsTest()
    {
        string value1 = "Steve Nystrom";
        string value2 = "Nystrom";

        StringAssert.Contains(value1, value2);
    }

    [TestMethod]
    public void StartsWithTest()
    {
        string value1 = "all lower case";
        string value2 = "all lower";

        StringAssert.StartsWith(value1, value2);
    }

    [TestMethod]
    public void IsAllLowerCaseTest()
    {
        Regex r = new Regex(@"^([^A-Z])+$");

        StringAssert.Matches("all lower case", r);
    }

    [TestMethod]
    public void IsNotAllLowerCaseTest()
    {
        Regex r = new Regex(@"^([^A-Z])+$");

        StringAssert.DoesNotMatch(
             "All Lower Case", r);
    }
}
