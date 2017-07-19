using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveloperConsole.CommandFramework
{
    [CommandEntry("System")]
    class CommonCommands
    {
        [CommandEntryMethod("cls", "清空屏幕")]
        public static string Clean()
        {
            ConsoleGUI._ins.output.Clear();
            return null;
        }

        [CommandEntryMethod("about","关于信息")]
        public static string About()
        {
            ConsoleLog.Println("=====Developer Console=====");
            ConsoleLog.Println("              Kanbaru");
            ConsoleLog.Println("=====Developer Console=====");
            return null;
        }

        [CommandEntryMethod("help", "获取指令集信息")]
        public static string GetHelp()
        {
            ConsoleLog.Println("All Commands:");
            foreach (var command in CommandsRepository._ins.repository)
            {
                ConsoleLog.LogWarrning("   " + command.Key + " " + command.Value.commandNotes);
            }
            return null;
        }

        [CommandEntryMethod("ver", "获取版本号信息")]
        public static string GetVersion()
        {
            ConsoleLog.LogWarrning("Developer Console Alpha 0.1");
            return null;
        }

        [CommandEntryMethod("time", "显示当前时间")]
        public static string GetCurrentTime()
        {
            ConsoleLog.Println("当前时间: " + DateTime.Now);
            return null;
        }
    }
}
