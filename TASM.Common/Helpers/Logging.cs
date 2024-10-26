using System;

namespace TASM.Common.Helpers;

/// <summary>
/// A log library similar to the one used by TABG's dedicated server
/// </summary>
public class Logging
{
    public enum LogLevel
    {
        Success,
        Info,
        Warning,
        Error,
    }
    
    public static void Log(LogLevel level, string context, string message)
    {
        string ansiColor = level switch
        {
            LogLevel.Success => "\x1b[32m",
            LogLevel.Info => "\x1b[34m",
            LogLevel.Warning => "\x1b[33m",
            LogLevel.Error => "\x1b[31m",
            _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
        };
        
        Console.WriteLine($"\x1b[0m[{ansiColor}{context}\x1b[0m] - \x1b[0m{message}");
    }
}