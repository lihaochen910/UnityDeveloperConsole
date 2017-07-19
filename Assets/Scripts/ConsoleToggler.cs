using UnityEngine;

public class ConsoleToggler : MonoBehaviour
{
    private bool                consoleEnabled;
    public ConsoleOpenAction    ConsoleOpenAction;
    public ConsoleCloseAction   ConsoleCloseAction;

    private void Awake()
    {
        var v = (Instantiate(Resources.Load<GameObject>("@ui_console/ui_console"),GameObject.Find("UI Root").transform) as GameObject).AddComponent<ConsoleGUI>();
        v.transform.localScale = Vector3.one;
        v.gameObject.SetActive(false);
        DontDestroyOnLoad(v.gameObject); 
        ConsoleOpenAction = new ConsoleOpenAction();
        ConsoleCloseAction = new ConsoleCloseAction();

        consoleEnabled = v.isActiveAndEnabled;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            ToggleConsole();
        }
    }

    private void ToggleConsole()
    {
        consoleEnabled = !consoleEnabled;

        if (consoleEnabled)
        {
            ConsoleOpenAction.Activate();
        }
        else
        {
            ConsoleCloseAction.Activate();
        }
    }
}