using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using TMPro;

namespace InGameConsole
{
    public class Console : MonoBehaviour
    {
        private static bool _isOpen;
        
        private static TMP_InputField _input;
        private static TMP_Text _output;

        public static List<Command> Commands { get; private set; }

        private static Console _instance;

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
            
            Commands = new List<Command>();
            RegisterCommands();
        }

        private void Start()
        {
            _input = transform.Find("Console/Input Field").GetComponent<TMP_InputField>();
            _output = transform.Find("Console/Output Field/Text").GetComponent<TMP_Text>();

            _input.onSubmit.AddListener(ExecuteCommand);

            _isOpen = true;
            OpenOrClose();
        }

        private static void RegisterCommands()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            var commandTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Command)));
            
            foreach (var commandType in commandTypes)
            {
                var command = Activator.CreateInstance(commandType) as Command;
                Commands.Add(command);
            }
        }
        
        private static void ExecuteCommand(string input)
        {
            if (_input.wasCanceled) return;

            _input.SetTextWithoutNotify("");

            if(input == string.Empty) return;

            Write(TextStyle.DefaultDarker("> " + input));

            string commandName = input.Split(' ')[0].ToLower();
            
            Command command = Commands.Find(x => x.Name == commandName);

            if (command == null)
            {
                Write(TextStyle.Error("The specified command was not found."));
                
                return;
            }

            string[] args = input.Split(' ').Skip(1).ToArray();
            
            command.Execute(args);
        }

        private static void WriteDebugLogs(string text, string stackTrace, LogType type)
        {
            if(!ConsoleData.instance.DisplayStacktrace) return;

            string title = type switch
            {
                LogType.Log => TextStyle.Info(text),
                LogType.Warning => TextStyle.Warning(text),
                LogType.Error => TextStyle.FatalError(text),
                _ => TextStyle.Default(text)
            };
            
            Write(title + "\n" + TextStyle.DefaultDarker(stackTrace));
        }

        public static void Write(string text)
        {
            _output.text += text + "\n";
        }

        public static void Clear()
        {
            _output.text = "";
        }

        public static void OpenOrClose()
        {
            _isOpen = !_isOpen;
            
            _instance.transform.GetChild(0).gameObject.SetActive(_isOpen);
        }

        private void OnEnable()
        {
            Application.logMessageReceived += WriteDebugLogs;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= WriteDebugLogs;
        }
    }
}