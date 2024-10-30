using MyClasses;

namespace MyClassesTest;

[TestClass]
public class CollectionAssertClassTest
{
    [TestMethod]
    public void AreCollectionsEqualTestNumbers()
    {
        List<int> expected = new() { 1, 2, 3, 4 };
        List<int> actual = new() { 1, 2, 3, 4 };

        // Compares each item in the two collections
        // to see if they are equal
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsEqualTest()
    {
        PeopleManager mgr = new();
        List<Person> expected;
        List<Person> actual;

        actual = mgr.GetPeople();
        expected = actual;

        // Compares each item in the two collections
        // to see if they are equal
        // ie. they refer to the same object
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsNotEqual()
    {
        PeopleManager mgr = new();
        List<Person> expected = new();
        List<Person> actual;

        expected.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
        expected.Add(new Person() { FirstName = "John", LastName = "Kuhn" });
        expected.Add(new Person() { FirstName = "Jim", LastName = "Ruhl" });

        actual = mgr.GetPeople();

        // Compares each item in the two collections
        // to see if they are equal
        // ie. they refer to the same object
        CollectionAssert.AreNotEqual(expected, actual);
    }

    [TestMethod]
    public void AreNumbersEquivalentTest()
    {
        List<int> expected = new() { 1, 2, 3, 4 };
        List<int> actual = new() { 4, 2, 3, 1 };

        // Checks for same values, but in any order
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void AreCollectionsEquivalentTest()
    {
        PeopleManager mgr = new();
        List<Person> expected = new();
        List<Person> actual;

        // Get collection of people
        actual = mgr.GetPeople();

        // Add same Person objects to new collection
        // but in a different order
        expected.Add(actual[1]);
        expected.Add(actual[2]);
        expected.Add(actual[0]);

        // Checks for same objects, but in any order
        CollectionAssert.AreEquivalent(expected, actual);
    }


    [TestMethod]
    public void AreCollectionsEqualWithComparerTest()
    {
        PeopleManager mgr = new();
        List<Person> expected = new();
        List<Person> actual;

        // Get collection of people
        actual = mgr.GetPeople();

        // Create same exact objects as those returned
        // from the mgr.GetPeople() method
        expected.Add(new() { FirstName = "Paul", LastName = "Sheriff", Age = 59 });
        expected.Add(new() { FirstName = "John", LastName = "Kuhn", Age = 55 });
        expected.Add(new() { FirstName = "Steve", LastName = "Nystrom", Age = 65 });

        // Add an anonymous Comparer method to determine equality
        CollectionAssert.AreEqual(expected, actual,
          Comparer<Person>.Create((x, y) =>
            x.FirstName == y.FirstName &&
            x.LastName == y.LastName &&
            x.Age == y.Age ? 0 : 1));
    }

    [TestMethod]
    public void IsCollectionOfTypeTest()
    {
        PeopleManager mgr = new();
        List<Person> actual;

        // Get collection of supervisors
        actual = mgr.GetSupervisors();

        // Check if all objects in the collection
        // are of the type Supervisor
        CollectionAssert.AllItemsAreInstancesOfType(actual,
          typeof(Supervisor));
    }

}
