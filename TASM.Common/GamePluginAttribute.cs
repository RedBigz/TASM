namespace TASM.Common;

[AttributeUsage(AttributeTargets.Assembly)]
public class GamePluginAttribute : Attribute
{
    public string Name;
    public string Version;
    public string Author;

    /// <summary>
    /// This attribute flags your assembly as a plugin.
    /// </summary>
    /// <example>
    /// <c>[assembly: GamePlugin(name: "Example", version: "1.0.0", author: "Anonymous"] </c>
    /// </example>
    /// <param name="name"></param>
    /// <param name="version"></param>
    /// <param name="author"></param>
    public GamePluginAttribute(string name, string version, string author)
    {
        Name = name;
        Version = version;
        Author = author;
    }
}