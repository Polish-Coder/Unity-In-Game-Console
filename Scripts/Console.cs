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
        private static TMP_InputField _input;
        private static TMP_Text _output;

        private static List<Command> _commands;
        public static List<Command> Commands => _commands;

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
            
            _commands = new List<Command>();
            RegisterCommands();
        }

        private void Start()
        {
            _input = transform.Find("Console/Input Field").GetComponent<TMP_InputField>();
            _output = transform.Find("Console/Output Field/Text").GetComponent<TMP_Text>();

            _input.onSubmit.AddListener(ExecuteCommand);
        }

        private static void RegisterCommands()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            var commandTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Command)));
            
            foreach (var commandType in commandTypes)
            {
                var command = Activator.CreateInstance(commandType) as Command;
                _commands.Add(command);
            }
        }
        
        private static void ExecuteCommand(string input)
        {
            if (_input.wasCanceled) return;

            _input.SetTextWithoutNotify("");

            Write("> " + input);

            string commandName = input.Split(' ')[0];
            
            Command command = _commands.Find(x => x.Name == commandName);

            if (command == null) return;

            string[] args = input.Split(' ').Skip(1).ToArray();
            
            command.Execute(args);
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
}