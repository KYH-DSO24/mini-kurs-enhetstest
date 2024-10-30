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

        WriteDescription(this.GetType());
        WriteOwner(this.GetType());

        // Check to see which test we are running
        if (GetTestName() == "FileNameDoesExist")
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
        // Check to see which test we are running
        if (GetTestName() == "FileNameDoesExist")
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
    [DeploymentItem("FileToDeploy.txt")]
    [Description("Check to see if a file exists using the [DeploymentItem] attribute.")]
    public void FileNameDoesExistUsingDeploymentItem()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = "FileToDeploy.txt";
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($@"Checking for file: '{fileName}'
       in folder '{TestContext?.DeploymentDirectory}'");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall,
          "File '{0}' does NOT exist.", fileName);
    }

    [TestMethod]
    [DeploymentItem("FileDataRow.txt")]
    [DeploymentItem("FileDataRow2.txt")]
    [DataRow("FileDataRow.txt")]
    [DataRow("FileDataRow2.txt")]
    [Description("Check to see if a file exists using the [DataRow] attribute.")]
    public void FileNameDoesExistUsingDataRow(string fileName)
    {
        // Arrange
        FileProcess fp = new();
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($@"Checking for file: '{fileName}'
       in folder '{TestContext?.DeploymentDirectory}'");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall,
          "File '{0}' does NOT exist.", fileName);
    }

    [TestMethod]
    [DeploymentItem("FileDynamic.txt")]
    [DeploymentItem("FileDynamic2.txt")]
    [DynamicData("FileNames", typeof(TestData), DynamicDataSourceType.Method)]
    [Description("Check to see if a file exists using the [DynamicData] attribute.")]
    public void FileNameDoesExistUsingDynamicData(string fileName)
    {
        // Arrange
        FileProcess fp = new();
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($@"Checking for file: '{fileName}'
       in folder '{TestContext?.DeploymentDirectory}'");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall,
          "File '{0}' does NOT exist.", fileName);
    }

    [TestMethod]
    [Description("Check to see if a file exists.")]
    public void FileNameDoesExist()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($"Checking for File: '{fileName}'");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsTrue(fromCall,
          "File '{0}' does NOT exist.", fileName);
    }

    [TestMethod]
    [Description("Check to see if file does not exist.")]
    public void FileNameDoesNotExist()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME);
        bool fromCall;

        // Add Messages to Test Output
        TestContext?.WriteLine($"Checking file '{fileName}' does NOT exist.");

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert
        Assert.IsFalse(fromCall);
    }

    [TestMethod]
    [Description("Check for a thrown ArgumentNullException using try...catch.")]
    public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
    {
        // Arrange
        FileProcess fp;
        string fileName = string.Empty;
        bool fromCall = false;

        try
        {
            // Act
            fp = new();

            // Add Messages to Test Output
            OutputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
            TestContext?.WriteLine(OutputMessage);

            fromCall = fp.FileExists(fileName);

            // Assert: Fail as we should not get here
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
    [Description("Check for a thrown ArgumentNullException using ExpectedException.")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
    {
        // Arrange
        FileProcess fp = new();
        string fileName = string.Empty;
        bool fromCall;

        // Add Messages to Test Output
        OutputMessage = GetTestSetting<string>("EmptyFileMsg", TestConstants.EMPTY_FILE_MSG);
        TestContext?.WriteLine(OutputMessage);

        // Act
        fromCall = fp.FileExists(fileName);

        // Assert: Fail as we should not get here
        OutputMessage = GetTestSetting<string>("EmptyFileFailMsg", TestConstants.EMPTY_FILE_FAIL_MSG);
        Assert.Fail(OutputMessage);
    }
}