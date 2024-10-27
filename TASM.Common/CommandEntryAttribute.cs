namespace TASM.Common;

/// <summary>
/// This attribute lets TASM recognise this method as the entry point for this command.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class CommandEntryAttribute : Attribute
{
}