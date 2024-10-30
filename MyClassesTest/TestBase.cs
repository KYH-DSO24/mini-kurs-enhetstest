namespace MyClassesTest;

public class TestBase
{
    public TestContext? TestContext { get; set; }
    public string OutputMessage { get; set; } = string.Empty;

    #region GetTestSetting Method
    protected T GetTestSetting<T>(string name, T defaultValue)
    {
        T ret = defaultValue;

        try
        {
            var tmp = TestContext?.Properties[name];
            if (tmp != null)
            {
                ret = (T)Convert.ChangeType(tmp, typeof(T));
            }
        }
        catch
        {
            // Ignore exception, return the defaultValue
        }

        return ret;
    }
    #endregion

    #region GetTestName Method
    protected string GetTestName()
    {
        var ret = TestContext?.TestName;
        if (ret == null)
        {
            return string.Empty;
        }
        else
        {
            return ret.ToString();
        }
    }
    #endregion

    #region GetFileName Method
    protected string GetFileName(string name, string defaultValue)
    {
        string fileName = GetTestSetting<string>(name, defaultValue);
        fileName = fileName.Replace("[AppDataPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

        return fileName;
    }
    #endregion
}
