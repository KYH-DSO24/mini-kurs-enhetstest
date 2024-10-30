using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest : TestBase
{
    [TestMethod]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fp = new();
        bool fromCall;

        // Add Messages to Test Output
        string fileName = GetTestSetting<string>("GoodFileName", TestConstants.GOOD_FILE_NAME);
        fileName = fileName.Replace("[AppDataPath]",
            Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData));
        TestContext?.WriteLine($"Checking for file: '{fileName}'");

        // Create the Good File
        File.AppendAllText(fileName, "Some Text");

        // Act
        fromCall = fp.FileExists(fileName);

        // Delete the Good File if it Exists
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        // Assert
        Assert.IsTrue(fromCall);
    }

    [TestMethod]
    public void FileNameDoesNotExist()
    {
        // Arrange
        FileProcess fp = new();
        bool fromCall;

        // Add Messages to Test Output
        string fileName = GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME);
        TestContext?.WriteLine($"Checking file '{fileName}' does NOT exist.");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsFalse(fromCall);
    }

    [TestMethod]
    public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
    {
        // Arrange
        FileProcess fp;
        string fileName = string.Empty;
        bool fromCall = false;

        // Add Messages to Test Output
        OutputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
        TestContext?.WriteLine(OutputMessage);

        try
        {
            // Act
            fp = new();

            fromCall = fp.FileExists(fileName);

            // Assert: Fail because we should not get here
            OutputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
            Assert.Fail(OutputMessage);
        }
        catch (ArgumentNullException)
        {
            // Assert: Test was a success
            Assert.IsFalse(fromCall);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = string.Empty;
        //string fileName = "Test";  // Uncomment to test failure
        bool fromCall;

        // Add Messages to Test Output
        OutputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
        TestContext?.WriteLine(OutputMessage);

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert: Fail because we should not get here
        OutputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
        Assert.Fail(OutputMessage);
    }
}