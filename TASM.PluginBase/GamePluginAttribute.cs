namespace TASM.PluginBase;

[AttributeUsage(AttributeTargets.Class)]
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