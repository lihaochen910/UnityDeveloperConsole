using System;
using System.Net;
using System.Text;
using DeveloperConsole;
using DeveloperConsole.CommandFramework;

namespace Assets.Scripts.Commands
{
    [Command("del", "从服务器数据中删除一件装备/一个物品\n Usage:del <type> <id>", CommandType.Server)]
    class Del : CommandBase
    {
        private const string protocol = "http";
        private const string ip = "106.75.36.113";
        private const string port = "2002";
        private const string path = "/gm/";
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
            if (arguments.Length == 0)
            {
                ConsoleLog.LogWarrning(commandNotes);
                return;
            }
            if (arguments.Length != 0 && arguments.Length < 2)
            {
                ConsoleLog.LogWarrning("参数不匹配");
            }
            string type = null;
            int id = -1;

            for (int i = 0; i < arguments.Length; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        type = arguments[i];
                        break;
                    case 2:
                        int.TryParse(arguments[i], out id);
                        break;
                }
            }
            string url = protocol + "://" + ip + ':' + port + path + "delete_" + type;
            string postData = @"roleid=" + getUserRID() +
                         @"&data={""uuid"":" + id +
                         @"}";
            ConsoleLog.LogWarrning(ServerUtil.Post(url,postData));
            ConsoleLog.Println();
        }

        private int getUserRID()
        {
            //return Convert.ToInt32(Tools.CallMethod("userModel", "getRID")[0]);
            return 105906188;
        }
    }
}
