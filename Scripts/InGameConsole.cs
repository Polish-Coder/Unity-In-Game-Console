using UnityEngine;
using TMPro;

public class InGameConsole : MonoBehaviour
{
    private static TMP_InputField _input;
    private static TMP_Text _output;
    
    private static InGameConsole _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _input = transform.Find("Console/Input Field").GetComponent<TMP_InputField>();
        _output = transform.Find("Console/Output Field/Text").GetComponent<TMP_Text>();

        _input.onSubmit.AddListener(ExecuteCommand);
    }

    private static void ExecuteCommand(string command)
    {
        if(_input.wasCanceled) return;
        
        _input.SetTextWithoutNotify("");

        Write("> " + command);
    }

    public static void Write(string text)
    {
        _output.text += text + "\n";
    }

    public static void Clear()
    {
        _output.text = "";
    }
}