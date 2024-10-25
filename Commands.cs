using System;
using System.Reflection;
using System.Collections.Generic;
using Landfall.Network;

namespace TASM.Modules;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CommandAttribute : Attribute
{
    public string Name;
    public string Reference;
}

[AttributeUsage(AttributeTargets.Method)]
public class CommandEntryAttribute : Attribute
{
}

public struct CommandInfo
{
    public string Name;
    public string Reference;
    public Type Class;
}

public static class CommandList
{
    public static Dictionary<string, CommandInfo> Commands = new();

    public static void Gather()
    {
        foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
        {
            var commandAttribute = type.GetCustomAttribute<CommandAttribute>();
            if (commandAttribute == null) continue;

            Logging.Log(Logging.LogLevel.Info, "Commands",
                $"Found Command {commandAttribute.Name}, Class: {type.FullName}");

            CommandInfo commandInfo = new()
            {
                Name = commandAttribute.Name,
                Reference = commandAttribute.Reference,
                Class = type
            };

            Commands.Add(commandAttribute.Reference, commandInfo);
        }
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
                        
                        method.Invoke(null, arguments.ToArray());
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