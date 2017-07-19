using System.Linq;
using DeveloperConsole.CommandFramework;

/// <summary>
/// ִ���������
/// </summary>
public class ConsoleSubmitAction : ConsoleAction
{
    public override void Activate()
    {
        if (ConsoleGUI._ins.input.isSelected)
        {
            var parts = ConsoleGUI._ins.input.value.Split(' ');
            var command = parts[0];
            var args = parts.Skip(1).ToArray();

            ConsoleLog.Log(ConsoleGUI._ins.input.value);
            /* ����ָ����ʷ��¼ */
            ConsoleCommandHistory.PushCommand(ConsoleGUI._ins.input.value);

            if (CommandsRepository._ins.HasCommand(command))
            {
                string returnInfo = CommandsRepository._ins.ExecuteCommand(command, args);
                if (returnInfo != null)
                    ConsoleLog.Log(returnInfo);
            }
            else
            {
                ConsoleLog.LogWarrning("Command '" + command + "' not found");
            }
            ConsoleGUI._ins.input.value = "";
            /* ����ָ����ʷ���� */
            ConsoleCommandHistory.ResetSelection();
        }
        else
        {
            /*���������ڷǼ���״̬���򼤻������*/
            ConsoleGUI._ins.input.isSelected = true;
        }
    }
}