namespace TASM.PluginBase;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CommandAttribute : Attribute
{
    public string Name;
    public string Reference;
}