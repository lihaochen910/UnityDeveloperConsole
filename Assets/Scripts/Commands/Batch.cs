using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeveloperConsole;
using DeveloperConsole.CommandFramework;

namespace Assets.Scripts.Commands
{
    [Command("bat", "批量添加指定类型装备/物品/卡牌\nUsage:bat type (可选)(-num <Int32> -suitid <Int32> -eqtype <Int32> -ex <Int32>)", CommandType.Server)]
    class Batch : CommandBase
    {
        private const string protocol = "http";
        private const string ip = "106.75.36.113";
        private const string port = "2002";
        private const string path = "/gm/single_reward";

        public override string commandName
        {
            get
            {
                return (this.GetType().GetCustomAttributes(typeof(CommandAttribute), true)[0] as CommandAttribute).CommandName;
            }
            set { return; }
        }

        public override string commandNotes
        {
            get
            {
                return (this.GetType().GetCustomAttributes(typeof(CommandAttribute), true)[0] as CommandAttribute).Notes;
            }
            set { return; }
        }

        public override void Execute(string[] arguments)
        {
            if (arguments.Length == 0)//0个参数时显示提示
            {
                ConsoleLog.LogWarrning(commandNotes);
                return;
            }
            var type = arguments[0];

            if (type == "equip")
            {
                string[] paramsStrings = arguments.Skip(1).ToArray();
            }
            if (type == "item")
            {

            }
            if (type == "card")
            {

            }
            else
            {
                ConsoleLog.LogWarrning("参数不正确");
            }
        }

        private int getUserRID()
        {
            //return Convert.ToInt32(Tools.CallMethod("userModel", "getRID")[0]);
            return 105906188;
        }
    }
}
