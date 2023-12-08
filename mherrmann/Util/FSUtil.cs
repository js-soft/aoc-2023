namespace Advent2023;

public class FSUtil
{
    public static string BaseDir
    {
        get => AppDomain.CurrentDomain.BaseDirectory + "../../../../";
    }

    public static string ResourceDir
    {
        get => Path.Combine(BaseDir, "res");
    }

    public static string GetProjectPath(string resource) => Path.Combine(BaseDir, resource);

    public static string GetResourcePath(string resource) => Path.Combine(ResourceDir, resource);

    public static string GetResource(string resource) => File.Exists(resource) ? resource : GetResourcePath(resource);

    public static string[] ReadResource(string resource) => File.ReadAllLines(GetResource(resource));
}
