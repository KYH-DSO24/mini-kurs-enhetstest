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
}
