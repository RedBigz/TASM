using System;
using System.Reflection;
using System.Collections.Generic;
using Landfall.Network;
using TASM.Common;
using TASM.Common.Helpers;

namespace TASM.Modules;

public struct CommandInfo
{
    public string Name;
    public string Reference;
    public CommandPermission Permission;
    public Type Class;
}

public static class CommandList
{
    public static Dictionary<string, CommandInfo> Commands = new();
    public static Dictionary<TABGPlayerServer, CommandPermission> UserPermissions = new();

    public static void Gather(Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            var commandAttribute = type.GetCustomAttribute<CommandAttribute>();
            if (commandAttribute == null) continue;

            Logging.Log(Logging.LogLevel.Info, "Commands",
                $"Found Command {commandAttribute.Name}, Class: {type.FullName}, Reference: {commandAttribute.Reference}, Permission: {commandAttribute.Permission}");

            CommandInfo commandInfo = new()
            {
                Name = commandAttribute.Name,
                Reference = commandAttribute.Reference,
                Class = type
            };

            Commands.Add(commandAttribute.Reference, commandInfo);
        }
    }

    static bool CheckPermission(CommandPermission permission, TABGPlayerServer player)
    {
        if (UserPermissions.TryGetValue(player, out var userPermission))
            return permission >= userPermission;

        return permission == CommandPermission.Everyone;
    }

    public static void Invoke(string reference, string[] args, TABGPlayerServer player)
    {
        Logging.Log(Logging.LogLevel.Warning, "Commands",
            $"Invoking command {reference} ({args?.Length ?? 0} argument{(args?.Length != 1 ? "s" : string.Empty)})");
        if (Commands.TryGetValue(reference, out var commandInfo))
        {
            try
            {
                foreach (var method in commandInfo.Class.GetMethods())
                {
                    if (method.GetCustomAttribute<CommandEntryAttribute>() != null)
                    {
                        List<object> arguments = new();

                        arguments.AddRange(new[] { player });
                        arguments.AddRange(args!);

                        if (CheckPermission(commandInfo.Permission, player))
                            method.Invoke(null, arguments.ToArray());
                        else
                            Logging.Log(Logging.LogLevel.Error, "Commands",
                                $"{player.PlayerName} does not have permission {commandInfo.Permission}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Log(Logging.LogLevel.Error, "Commands", $"Failed to execute command {reference}: {ex.Message}");
            }
        }
        else
        {
            Logging.Log(Logging.LogLevel.Warning, "Commands", $"Command {reference} not found");
        }
    }
}