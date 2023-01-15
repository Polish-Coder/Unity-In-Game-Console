using InGameConsole;
using UnityEngine;

public class ConsoleOpener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Console.OpenOrClose();   
        }
    }
}