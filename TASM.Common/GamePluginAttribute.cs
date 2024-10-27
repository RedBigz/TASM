namespace TASM.Common;

[AttributeUsage(AttributeTargets.Assembly)]
public class GamePluginAttribute : Attribute
{
    public string Name;
    public string Version;
    public string Author;

    public GamePluginAttribute(string name, string version, string author)
    {
        Name = name;
        Version = version;
        Author = author;
    }
}