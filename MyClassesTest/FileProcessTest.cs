using MyClasses;

namespace MyClassesTest;

[TestClass]
public class FileProcessTest : TestBase
{
    #region Class Initialize and Cleanup Methods
    [ClassInitialize()]
    public static void ClassInitialize(TestContext tc)
    {
        // This code runs once before all tests run in this class
        tc.WriteLine("In FileProcessTest.ClassInitialize() method");
    }

    [ClassCleanup()]
    public static void ClassCleanup()
    {
        // This code runs once after all tests in this class have run
        // NOTE: TestContext is not available in here
    }
    #endregion

    #region Test Initialize and Cleanup Methods
    [TestInitialize()]
    public void TestInitialize()
    {
        TestContext?.WriteLine("In FileProcessTest.TestInitialize() method");

        // Check to see which test we are running
        string testName = GetTestName();
        if (testName == "FileNameDoesExist")
        {
            // Get Good File Name
            string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

            // Create the Good File
            File.AppendAllText(fileName, "Some Text");
        }
    }

    [TestCleanup()]
    public void TestCleanup()
    {
        TestContext?.WriteLine("In FileProcessTest.TestCleanup() method");

        // Check to see which test we are running
        string testName = GetTestName();
        if (testName == "FileNameDoesExist")
        {
            // Get Good File Name
            string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

            // Delete the Good File if it Exists
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
    #endregion

    [TestMethod]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fp = new();
        bool fromCall;

        // Add Messages to Test Output
        string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);
        TestContext?.WriteLine($"Checking for file: '{fileName}'");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall, "File '{0}' does NOT exist", fileName);
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