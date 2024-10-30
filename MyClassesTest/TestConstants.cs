namespace MyClassesTest;
internal class TestConstants
{
    public const string GOOD_FILE_NAME = @"[AppDataPath]\TestFile.txt";
    public const string BAD_FILE_NAME = @"C:\NotExists.txt";
    public const string EMPTY_FILE_FAIL_MSG = "The Call to the FileExists() method did NOT throw an ArgumentNullException and it SHOULD have.";
    public const string EMPTY_FILE_MSG = "Checking for an empty file name.";
}
