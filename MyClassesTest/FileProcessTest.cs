using MyClasses;
namespace MyClassesTest;
[TestClass]
public class FileProcessTest
{
    [TestMethod]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = @"C:\Windows\Regedit.exe";
        bool fromCall;

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert Assert.IsTrue(fromCall);
    }


    [TestMethod]
    public void FileNameDoesNotExist()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = @"C:\DoesNotExist.txt";
        bool fromCall;

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert Assert.IsFalse(fromCall);
    }


    [TestMethod]
    public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
    {
        // Arrange
        FileProcess fp;
        string fileName = string.Empty; bool fromCall = false;

        try
        {
            // Act
            fp = new();

            fromCall = fp.FileExists(fileName);

            // Assert: Fail as we should not get here Assert.Fail("The Call to the FileExists() method did NOT throw an ArgumentNullException and it SHOULD have.");
        }
        catch (ArgumentNullException)
        {
            // Assert: Test was a success Assert.IsFalse(fromCall);
        }
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = string.Empty; bool fromCall;

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert: Fail as we should not get here Assert.Fail("The Call to the FileExists() method did NOT throw an ArgumentNullException and it SHOULD have.");
}

}
