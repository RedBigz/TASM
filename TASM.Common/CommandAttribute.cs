namespace TASM.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CommandAttribute : Attribute
{
    public string Name;
    public string Reference;
    public CommandPermission Permission;

    /// <summary>
    /// This attribute lets TASM recognise a class as a command.
    /// </summary>
    /// <param name="name">Name of your command.</param>
    /// <param name="reference">How your command is executed in chat.<br /><i>e.g. hello -> /hello (in chat)</i></param>
    /// <param name="permission">What minimum permission level this command can be executed at.</param>
    public CommandAttribute(string name, string reference, CommandPermission permission)
    {
        Name = name;
        Reference = reference;
        Permission = permission;
    }
}