namespace VSBatchRegister.Serialize;

public class ProjectConfig
{
    #region FromConfig
    public string? DB { get; set; }
    public string? DBTest { get; set; }

    #endregion

    #region FromApplication

    public string? AppVersion { get; set; }
    public string? AppName { get; set; }

    #endregion
}