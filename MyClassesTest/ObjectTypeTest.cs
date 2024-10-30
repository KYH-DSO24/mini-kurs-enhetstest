using MyClasses;

namespace MyClassesTest;

[TestClass]
public class ObjectTypeTest
{
    [TestMethod]
    public void AreNotSameTest()
    {
        Person x = new();
        Person y = new();

        Assert.AreNotSame(x, y);
    }

    [TestMethod]
    public void AreSameTest()
    {
        Person x = new();
        Person y = x;

        Assert.AreSame(x, y);
    }

    [TestMethod]
    public void IsInstanceOfTypeTest()
    {
        Person per = new()
        {
            FirstName = "Paul",
            LastName = "Sheriff"
        };
        Employee emp = new()
        {
            FirstName = "Paul",
            LastName = "Sheriff"
        };

        // per is a Person
        Assert.IsInstanceOfType(per, typeof(Person));
        // per is not an Employee
        Assert.IsNotInstanceOfType(per, typeof(Employee));
        // emp is a Person
        Assert.IsInstanceOfType(emp, typeof(Person));
        // emp is an Employee
        Assert.IsInstanceOfType(emp, typeof(Employee));
        // emp is not a Supervisor
        Assert.IsNotInstanceOfType(emp, typeof(Supervisor));
    }

    [TestMethod]
    public void IsNullTest()
    {
        PeopleManager mgr = new();
        Person? per;

        per = mgr.GetPerson(1);

        Assert.IsNull(per);

        per = new()
        {
            FirstName = "Paul",
            LastName = "Sheriff"
        };
        Assert.IsNotNull(per);
    }

}
