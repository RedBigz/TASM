namespace TASM.Common;

/// <summary>
/// The permission levels for commands.
/// </summary>
public enum CommandPermission
{
    Everyone, // All Players
    Admin, // Admin (User logged in with admin password)
}