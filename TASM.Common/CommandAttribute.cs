namespace TASM.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CommandAttribute : Attribute
{
    public string Name;
    public string Reference;
    public CommandPermission Permission;

    public CommandAttribute(string name, string reference, CommandPermission permission)
    {
        Name = name;
        Reference = reference;
        Permission = permission;
    }
}